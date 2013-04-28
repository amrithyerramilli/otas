using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTAS2.Repository.Repository;


namespace OTAS2WebApp.Areas.Student.Controllers
{
    public class MainController : Controller
    {
        //
        // GET: /Student/Login/

        public ActionResult Login()
        {
            return View("Login/Login");
        }

        public ActionResult Details()
        {
            return View("Details/Details");
                        
        }
        public ActionResult PasswordValidation(FormCollection form)
        {
            string username = form["txtUsername"];
            var password = form["txtPassword"];
            StudentRepository s = new StudentRepository();
            var studs = (from i in s.GetAllStudents()
                        where i.USN == username
                        select i).ToList();

            return this.RedirectToAction("Details");
        }

    }
}
