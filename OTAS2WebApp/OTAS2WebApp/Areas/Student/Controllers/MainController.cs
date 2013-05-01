using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OTAS2.Repository.Repository;
using OTAS2.Domain.Entities;


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
            ValidS user = (ValidS)Session["student"];
            StudentRepository students = new StudentRepository();
            Students loggedInStudent = (from i in students.GetAllStudents()
                                        where i.USN == user.USN
                                        select i).ToList().FirstOrDefault();
            var student = (from i in students.GetAllStudents()
                           select i).ToList();
            return View("Details/Details", loggedInStudent);
                        
        }
        public ActionResult PasswordValidation(FormCollection form)
        {
            string username = form["txtUsername"];
            var password = form["txtPassword"];
            ValidSRepository valids = new ValidSRepository();
            var stud = (from i in valids.GetAllValidS()
                        where i.PassGen == password
                        where i.USN == username
                        select i).ToList();
            // Add an "incorrect password" view
            if (stud.Count == 0)
            {
                return View("Login/Incorrect");
            }
            Session["student"] = stud.FirstOrDefault();
            
            return RedirectToAction("Details");
        }
        public ActionResult Summary(FormCollection form)
        {
           // var s = Request.Form["USN"];
            var s = form["name"];
            return View();
        }

    }
}
