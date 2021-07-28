using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchoolWebSite.Domains.Entities;
using MySchoolWebSite.Models.Abstract;

namespace MySchoolWebSite.Models.Dapper
{
    public class RatingRepository: IRatingRepository
    {
        private readonly string connectionString = null;

        public RatingRepository(string connection)
        {
            connectionString = connection;
        }

        public void Add(Rating rating)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "INSERT INTO Rating (Mark,StudentId,LPId,[Index]) VALUES(@Mark,@StudentId,@LPId,@Index)";
                db.Execute(sqlQuery, rating);
            }
        }

        public Rating Get(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Rating>("SELECT * FROM Rating WHERE Id=@id", new { id }).FirstOrDefault();
            }
        }

        public Rating GetMarkByDate(int studentId, int lpId, int index)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Rating>(
                    "SELECT Mark FROM Rating WHERE (StudentId=@studentId) AND (LPId=@lpId) AND ([Index]=@index)",
                    new {studentId, lpId, index}).FirstOrDefault();
            }
        }
        public async Task<Rating> GetMark(int studentId, int lpId, int index/*DateTime date*/)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return await db.QueryFirstOrDefaultAsync<Rating>("SELECT * FROM Rating WHERE StudentId=@studentId AND LPId=@lpId AND[Index]=@index)", new { studentId, lpId, index /*date.Date */});
            }
        }

        public IEnumerable<Rating> GetAll()
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Rating>("SELECT * FROM Rating").ToList();
            }
        }
        public IEnumerable<Rating> GetByStudentAndSubject(int studentId, int lpId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Rating>("SELECT Mark, [Index] FROM Rating WHERE StudentId=@studentId AND LPId=@lpId", new { studentId, lpId }).ToList();
            }
        }
        public IEnumerable<Rating> GetBySubject(int lpId)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                return db.Query<Rating>("SELECT StudentId, Mark, [Index] FROM Rating WHERE LPId=@lpId", new { lpId }).ToList();
            }
        }
        public void Update(Rating rating)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Rating SET (Mark=@Mark, StudentId=@StudentId, LPId=@LPId, [Index]=@Index) WHERE Id=@Id";
                db.Execute(sqlQuery, rating);
            }
        }
        public void UpdateMark(int studentId, int index,int lpId, int mark)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "UPDATE Rating SET Mark=@mark WHERE StudentId=@studentId AND LPId=@lpId AND [Index]=@index";
                db.Execute(sqlQuery, new{studentId,index,lpId,mark});
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection db = new SqlConnection(connectionString))
            {
                var sqlQuery = "DELETE FROM Rating WHERE Id=@id";
                db.Execute(sqlQuery, new { id });
            }
        }
    }
}
