using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySchoolWebSite.Domains.Entities;

namespace MySchoolWebSite.Models.Abstract
{
    public interface ILearningProgramRepository:IGenericRepository<LearningProgram>
    {
        IEnumerable<LearningProgram> GetSubjects(int classId);
        public int GetLPId(int classId, int subjectId);
    }
}
