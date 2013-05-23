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
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Summary(FormCollection form)
        {
            IList<TeacherSummary> summary = new List<TeacherSummary>();
            try
            {
                var USN = form["USN"];
                var Sem = Convert.ToInt32(form["sem"]);
                var Sec = form["sec"];
                var DeptId = form["deptId"];
                SubCompRepository subComb = new SubCompRepository();
                SubjectRepository subjects = new SubjectRepository();
                TeacherInfoRepository teachers = new TeacherInfoRepository();
                summary = (from i in subComb.GetAllSubComb()
                                                 join o in teachers.GetAllTeacherInfo()
                                                 on
                                                 i.TeacherID equals o.TeacherId
                                                 join m in subjects.GetAllSubjects()
                                                 on
                                                 i.SubCode equals m.SubCode
                                                 where
                                                 i.sem == Sem
                                                 where
                                                 i.Section == Sec
                                                 where
                                                 i.DeptID == DeptId
                                                 select new TeacherSummary { TeacherName = o.TeacherName, SubName = m.SubName, SubCode = m.SubCode,ComboId = i.CombID , StudentUSN = USN}).ToList();               
            }
            catch (Exception ex)
            {
                
            }

            return View("Details/Summary", summary);
        }
        public ActionResult Rating()
        {
            ValidS user = (ValidS)Session["student"];
            return View("Ratings/Rating");
        }


    }
}
