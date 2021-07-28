using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using MySchoolWebSite.Domains.Entities;
using MySchoolWebSite.Models.Abstract;

namespace MySchoolWebSite.Models.Dapper
{
    public class RoleRepository:IRoleRepository
    {
        private readonly string connectionString = null;

        public RoleRepository(string connection)
        {
            connectionString = connection;
        }

        public Role Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Role>("Select * FROM Roles WHERE Id=@id", new {id}).FirstOrDefault();
            }
        }

        public IEnumerable<Role> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Role>("Select * FROM Roles").ToList();
            }
        }
    }
}
