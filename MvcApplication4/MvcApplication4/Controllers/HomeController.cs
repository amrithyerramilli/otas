using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcApplication4.Repository.Repository;
using MvcApplication4.Entities;

namespace MvcApplication4.Controllers
{
    public class HomeController : Controller
    {        
        public ActionResult Index()
        {
            StudentRepository students = new StudentRepository();
            List<string> studs = students.GetAllStudents().ToList();
            ViewBag.studs = studs;
            ViewBag.a = 5;
            return View("Index",studs);
        }

    }
}
