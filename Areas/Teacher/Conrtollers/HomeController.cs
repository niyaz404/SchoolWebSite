﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySchoolWebSite.Areas.Admin.Conrtollers
{
    [Area("Teacher")]
    public class HomeController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            return View();
        }
    }
}
