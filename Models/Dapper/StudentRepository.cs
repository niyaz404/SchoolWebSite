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
    public class StudentRepository:IStudentRepository
    {
        private readonly string connectionString = null;
        public StudentRepository(string connection)
        {
            connectionString = connection;
        }

        public void Add(Student student)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Students (FullName, ClassId) VALUES(@FullName, @ClassId)";
                 db.ExecuteAsync(sqlQuery, student);
            }
        }

        public Student Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Student>("SELECT * FROM Students WHERE Id=@id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Student> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Student>("SELECT * FROM Students").ToList();
            }
        }
        public IEnumerable<Student> GetClass(int classId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Student>("SELECT Id,FullName, ClassId FROM Students WHERE ClassId=@classId", new { classId })
                    .ToList();
            }
        }
        public string GetClassName(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Class>("SELECT ClassName FROM Classes WHERE Id=@id", new { id }).FirstOrDefault().ClassName;
            }
        }
        public void Update(Student student)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Students SET ClassId=@ClassId WHERE Id=@Id";
                 db.ExecuteAsync(sqlQuery, student);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Students WHERE Id=@id";
                 db.ExecuteAsync(sqlQuery, new { id });
            }
        }
    }
}
