﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTAS2WebApp.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            return RedirectToAction("Login", "Main", new { area = "Student" });
        }

    }
}
