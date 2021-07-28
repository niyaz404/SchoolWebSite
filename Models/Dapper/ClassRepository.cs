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
    public class ClassRepository:IClassRepository
    {
        private readonly string connectionString = null;

        public ClassRepository(string connection)
        {
            connectionString = connection;
        }

        public void Add(Class _class)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Classes (ClassName) VALUES(@ClassName)";
                db.Execute(sqlQuery, _class);
            }
        }

        public Class Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Class>("SELECT * FROM Classes WHERE Id=@id", new { id }).FirstOrDefault();
            }
        }

        public IEnumerable<Class> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Class>("SELECT * FROM Classes");
            }
        }
        public string GetClassName(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Class>("SELECT ClassName FROM Classes WHERE Id=@id", new { id }).FirstOrDefault().ClassName;
            }
        }
        public void Update(Class _class)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Classes SET ClassName=@ClassName WHERE Id=@Id";
                db.Execute(sqlQuery, _class);
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Classes WHERE Id=@id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
