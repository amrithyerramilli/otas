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
            SubjectRepository subjects = new SubjectRepository();
            Students loggedInStudent = (from i in students.GetAllStudents()
                                        where i.USN == user.USN
                                        select i).ToList().FirstOrDefault();            
            if (loggedInStudent.Elective1.Count() > 0)
            {
                
                loggedInStudent.Elective1Name = (from i in subjects.GetAllSubjects()
                                                 where i.SubCode == loggedInStudent.Elective1
                                                 select i.SubName).ToList().FirstOrDefault();
                Session["Elective1Id"] = loggedInStudent.Elective1;
            }
            if (loggedInStudent.Elective2.Count() > 0)
            {
                loggedInStudent.Elective2Name = (from i in subjects.GetAllSubjects()
                                                 where i.SubCode == loggedInStudent.Elective2
                                                 select i.SubName).ToList().FirstOrDefault();
                Session["Elective2Id"] = loggedInStudent.Elective2;
            }
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
            Session["counter"] = stud.FirstOrDefault().Counter;
            // If student already given feedback, send them to thank you page.
            if (stud[0].StudentDetails == true)
            {
                return View();
            }
            
            return RedirectToAction("Details");
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Summary(FormCollection form)
        {
            IList<TeacherSummary> summary = new List<TeacherSummary>();
            try
            {
                var usn = form["USN"];
                var sem = Convert.ToInt32(form["sem"]);
                var sec = form["sec"];
                var deptId = form["deptId"];
                string elec1Id = Session["Elective1Id"].ToString();
                string elec2Id = Session["Elective2Id"].ToString();
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
                                                 i.sem == sem
                                                 where
                                                 i.Section == sec
                                                 where
                                                 i.DeptID == deptId
                                                 where
                                                 i.elective == false
                                                 select new TeacherSummary { TeacherName = o.TeacherName, SubName = m.SubName, SubCode = m.SubCode,ComboId = i.CombID , StudentUSN = usn}).ToList();
                if (elec1Id != null)
                {
                    summary.Add((from i in subComb.GetAllSubComb()
                                 join o in teachers.GetAllTeacherInfo()
                                 on
                                 i.TeacherID equals o.TeacherId
                                 join m in subjects.GetAllSubjects()
                                 on
                                 i.SubCode equals m.SubCode
                                 where
                                 i.SubCode == elec1Id
                                 select new TeacherSummary { TeacherName = o.TeacherName, SubName = m.SubName, SubCode = m.SubCode, ComboId = i.CombID, StudentUSN = usn }).ToList().FirstOrDefault());
                }
                if (elec2Id != null)
                {
                    summary.Add((from i in subComb.GetAllSubComb()
                                 join o in teachers.GetAllTeacherInfo()
                                 on
                                 i.TeacherID equals o.TeacherId
                                 join m in subjects.GetAllSubjects()
                                 on
                                 i.SubCode equals m.SubCode
                                 where
                                 i.SubCode == elec2Id
                                 select new TeacherSummary { TeacherName = o.TeacherName, SubName = m.SubName, SubCode = m.SubCode, ComboId = i.CombID, StudentUSN = usn }).ToList().FirstOrDefault());
                }
                Session["summary"] = summary;
            }
            catch (Exception ex)
            {
                
            }

            return View("Details/Summary", summary);
        }
        public ActionResult RedirectRating()
        {
            List<TeacherSummary> summary = (List<TeacherSummary>)Session["summary"];
            ValidS student = (ValidS)Session["student"];
            int? counter = student.Counter;

            return View("Rating/Rating");
        }


    }
}
