using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySchoolWebSite.Domains.Entities;
using MySchoolWebSite.Models.Abstract;
using MySchoolWebSite.Models.Dapper;
using Newtonsoft.Json;

namespace MySchoolWebSite.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IClassRepository classRepository;
        private readonly IStudentRepository studentRepository;
        private readonly IRatingRepository ratingRepository;
        private readonly ILearningProgramRepository lpRepository;
        public StudentsController(IClassRepository c, IStudentRepository s, IRatingRepository r, ILearningProgramRepository lp)
        {
            classRepository = c;
            studentRepository = s;
            ratingRepository = r;
            lpRepository = lp;
        }
        public IActionResult List()
        {
            ViewBag.Classes = classRepository.GetAll();
            return View();
        }
        public JsonResult GetStudents(int classId)
        {
            //JsonResult j = Json(studentRepository.GetClass(classId));
            //string s = JsonConvert.SerializeObject(studentRepository.GetClass(classId));
            var js= new JsonResult(studentRepository.GetClass(classId));
            return new JsonResult(studentRepository.GetClass(classId));
            //return Json(studentRepository.GetClass(classId));
        }
        //[HttpPost("{studentId}")]
        [HttpGet]
        public IActionResult Profile(int studentId)
        {
            Student student = studentRepository.Get(studentId);
            ViewBag.Subjects = lpRepository.GetSubjects(student.ClassId);
            return View(student);
        }
        public JsonResult GetRating(int studentId, int subjectId)
        {
            return Json(ratingRepository.GetByStudentAndSubject(studentId,subjectId));
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
