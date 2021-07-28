using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchoolWebSite.Domains.Entities;

namespace MySchoolWebSite.Models.Abstract
{
    public interface IRatingRepository:IGenericRepository<Rating>
    {
        Task<Rating> GetMark(int studentId, int LPId, int index);
        IEnumerable<Rating> GetByStudentAndSubject(int studentId, int LPId);
        IEnumerable<Rating> GetBySubject(int LPId);
        Rating GetMarkByDate(int studentId, int lpId, int index);
        void UpdateMark(int studentId, int index, int lpId, int mark);
    }
}
