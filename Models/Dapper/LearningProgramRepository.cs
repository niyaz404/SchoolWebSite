using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using MySchoolWebSite.Domains.Entities;
using MySchoolWebSite.Models.Abstract;

namespace MySchoolWebSite.Models.Dapper
{
    public class LearningProgramRepository:ILearningProgramRepository
    {
        private readonly string connectionString = null;

        public LearningProgramRepository(string connection)
        {
            connectionString = connection;
        }

        public void Add(LearningProgram lp)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO LearningProgram (SubjectId, StudentId) VALUES(@SubjectId, @StudentId)";
                db.Execute(sqlQuery, lp);
            }
        }

        public LearningProgram Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<LearningProgram>("SELECT * FROM LearningProgram WHERE Id=@id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<LearningProgram> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<LearningProgram>("SELECT * FROM LearningProgram").ToList();
            }
        }

        public int GetLPId(int classId, int subjectId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<int>("SELECT Id FROM LearningProgram WHERE ClassId=@classId AND SubjectId=@subjectId", new { classId,subjectId }).FirstOrDefault();
            }
        }
        public IEnumerable<LearningProgram> GetSubjects(int classId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<LearningProgram>("SELECT Id, SubjectId, SubjectName FROM LearningProgram WHERE ClassId=@classId",new{classId}).ToList();
            }
        }
        public string GetClassName(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Class>("SELECT ClassName FROM Classes WHERE Id=@id", new { id }).FirstOrDefault().ClassName;
            }
        }
        public void Update(LearningProgram lp)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE LearningProgram SET (SubjectId=@SubjectId, StudentId=@StudentId) WHERE Id=@Id";
                db.ExecuteAsync(sqlQuery, lp);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM LearningProgram WHERE Id=@id";
                db.ExecuteAsync(sqlQuery, new { id });
            }
        }
    }
}
