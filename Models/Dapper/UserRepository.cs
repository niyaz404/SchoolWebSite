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
    public class UserRepository: IUserRepository
    {
        private readonly string connectionString = null;

        public UserRepository(string connection)
        {
            connectionString = connection;
        }

        public User Get(string email, string password)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT * FROM Users WHERE Email=@email AND Password=@password", new { email, password}).FirstOrDefault();
            }
        }

        //public Task<User> GetByEmail(string email)
        //{
        //    var t = Task<User>.Run(() =>
        //    {
        //        using (IDbConnection db = new SqlConnection(connectionString))
        //        {
        //            return db.Query<User>("SELECT Email FROM Users WHERE Email=@email", new {email}).FirstOrDefault();
        //        }
        //    });
        //    return t;
        //}
        public User GetByEmail(string email)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<User>("SELECT Email FROM Users WHERE Email=@email", new { email }).FirstOrDefault();
            }
        }

        public async Task<int> Add(User user)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                string sql = "INSERT INTO Users (Email, Password, RoleId) VALUES (@Email, @Password, @RoleId)";
                return await db.ExecuteAsync(sql, user);
            }
        }
    }
}
