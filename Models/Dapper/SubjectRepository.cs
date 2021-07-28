using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchoolWebSite.Domains.Entities;
using Dapper;
using MySchoolWebSite.Models.Abstract;

namespace MySchoolWebSite.Models.Dapper
{
    public class SubjectRepository:ISubjectRepository
    {
        private readonly string connectionString = null;

        public SubjectRepository(string connection)
        {
            connectionString = connection;
        }

        public void Add(Subject subject)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Subjects (Name) VALUES(@Name)";
                 db.ExecuteAsync(sqlQuery, subject);
            } 
        }

        public Subject Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Subject>("SELECT * FROM Subjects WHERE Id=@id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Subject> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Subject>("SELECT * FROM Subjects").ToList();
            }
        }
        public string GetClassName(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Class>("SELECT ClassName FROM Classes WHERE Id=@id", new { id }).FirstOrDefault().ClassName;
            }
        }
        public void Update(Subject subject)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Subjects SET (Name=@Name) WHERE Id=@Id";
                 db.ExecuteAsync(sqlQuery, subject);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Subjects WHERE Id=@id";
                 db.ExecuteAsync(sqlQuery, new { id });
            }
        }
    }
}
