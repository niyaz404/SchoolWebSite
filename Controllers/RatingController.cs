using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using MySchoolWebSite.Domains.Entities;
using MySchoolWebSite.Models.Abstract;

namespace MySchoolWebSite.Controllers
{
    public class RatingController : Controller
    {
        private readonly IClassRepository classRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IRatingRepository ratingRepository;
        private readonly ILearningProgramRepository lpRepository;
        public RatingController(IClassRepository c, IStudentRepository s, IRatingRepository r, ILearningProgramRepository lp)
        {
            classRepository = c;
            studentRepository = s;
            ratingRepository = r;
            lpRepository = lp;
        }
        public IActionResult Marks()
        {
            ViewBag.Classes = classRepository.GetAll();
            ViewBag.Subjects = lpRepository.GetSubjects(ViewBag.Classes[0].Id);
            return View();
        }

        public JsonResult GetLPId(int classId, int subjectId)
        {
            return Json(lpRepository.GetLPId(classId, subjectId));
        }
        public JsonResult GetMark(int studentId, int lpId, int index)
        {
            return Json(ratingRepository.GetMarkByDate(studentId, lpId, index));
        }

        public JsonResult GetBySubject(int lpId)
        {
            return Json(ratingRepository.GetBySubject(lpId));
        }
        public JsonResult GetSubjects(int classId)
        {
            var s= new JsonResult(lpRepository.GetSubjects(classId));
            return new JsonResult(lpRepository.GetSubjects(classId));
        }

        public (int, int,int) SplitId(string id)
        {
            string[] _id = id.Split("_");
            int studentdId = Convert.ToInt32(_id[0]);
            int index = Convert.ToInt32(_id[1]);
            int lpId= Convert.ToInt32(_id[2]);
            return (studentdId, index,lpId);
        }
        
        [Authorize(Roles = "admin,Учитель,Завуч,Директор")]
        public string UpdateMark(string id, int value)
        {
            var data = SplitId(id);
            try
            {
                ratingRepository.UpdateMark(data.Item1,data.Item2, data.Item3,value);
            }
            catch (Exception e)
            {
                return "unsuccessfully";
            }
            return "ok";
        }
        [Authorize(Roles = "admin,Учитель,Завуч,Директор")]
        public string PostMark(string id, int value)
        {
            var data = SplitId(id);
            try
            {
                ratingRepository.Add(new Rating() { StudentId = data.Item1, Index = data.Item2, LPId = data.Item3, Mark = value});
            }
            catch (Exception e)
            {
                return "unsuccessfully";
            }
            return "ok";
        }
    }
}
