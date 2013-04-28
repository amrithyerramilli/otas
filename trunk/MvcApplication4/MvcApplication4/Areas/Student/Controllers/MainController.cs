using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcApplication4.Areas.Student.Controllers
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
            var a = form["txtUsername"];
            return this.RedirectToAction("Details");
        }

    }
}
