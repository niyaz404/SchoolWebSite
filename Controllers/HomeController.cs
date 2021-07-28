using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySchoolWebSite.Models;
using MySchoolWebSite.Models.Abstract;
using MySchoolWebSite.Models.Dapper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Microsoft.AspNetCore.Authorization;

namespace MySchoolWebSite.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IClassRepository classRepository;
        private readonly IStudentRepository studentRepository;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IClassRepository c, IStudentRepository s)
        {
            classRepository = c;
            studentRepository = s;
        }
        public IActionResult Index()
        {
            //if (User.Identity.IsAuthenticated)
            //{
            //    return Content(User.Identity.Name);
            //}
            //return Content("не аутентифицирован");
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
