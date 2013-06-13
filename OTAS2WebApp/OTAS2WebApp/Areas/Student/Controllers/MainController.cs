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
            if (loggedInStudent.Elective1 != null)
            {
                if (loggedInStudent.Elective1.Count() > 0)
                {

                    loggedInStudent.Elective1Name = (from i in subjects.GetAllSubjects()
                                                     where i.SubCode == loggedInStudent.Elective1
                                                     select i.SubName).ToList().FirstOrDefault();                    
                }
            }            
            if (loggedInStudent.Elective2 != null)
            {
                if (loggedInStudent.Elective2.Count() > 0)
                {
                    loggedInStudent.Elective2Name = (from i in subjects.GetAllSubjects()
                                                     where i.SubCode == loggedInStudent.Elective2
                                                     select i.SubName).ToList().FirstOrDefault();
                    Session["Elective2Id"] = loggedInStudent.Elective2;
                }
            }            
            Session["loggedInStudent"] = loggedInStudent;            
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
            if (stud[0].FG == true)
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
                Students loggedInStudent = (Students)Session["loggedInStudent"];
                string elec1Id = null;
                string elec2Id = null;
                if(loggedInStudent.Elective1 != null)
                    elec1Id = loggedInStudent.Elective1;
                if(loggedInStudent.Elective2 != null)
                    elec2Id = loggedInStudent.Elective2;
                
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
            
            if (Session["counter"] == null)
            {
                throw new Exception("Database error");
            }
            int counter = Convert.ToInt32(Session["counter"]);
            // Send user to thank you page if counter is equal to the count of subjects given feedback for           
            if (summary.Count == counter)
            {
                return View("");
            }            
                        
            return View("Ratings/Rating",summary[counter]);
        }
        public ActionResult Rating(string comboID, string options)
        {
            RID_TABLE record = new RID_TABLE();
            RID_TABLERepository RID_TABLE = new RID_TABLERepository();
            ValidSRepository validSRepository = new ValidSRepository();
            ValidS student = (ValidS)Session["student"];
            List<string> arrayOfOptions = options.Split(',').ToList();

            //Initialising Record
            record.RID = comboID;
            record.A1 = Convert.ToInt32(arrayOfOptions[0]);
            record.A2 = Convert.ToInt32(arrayOfOptions[1]);
            record.A3 = Convert.ToInt32(arrayOfOptions[2]);
            record.A4 = Convert.ToInt32(arrayOfOptions[3]);
            record.A5 = Convert.ToInt32(arrayOfOptions[4]);
            record.A6 = Convert.ToInt32(arrayOfOptions[5]);
            record.A7 = Convert.ToInt32(arrayOfOptions[6]);
            record.A8 = Convert.ToInt32(arrayOfOptions[7]);
            record.A9 = Convert.ToInt32(arrayOfOptions[8]);
            record.A10 = Convert.ToInt32(arrayOfOptions[9]);
            // Inserting record in DB
            RID_TABLE.InsertRecord(record);
            // Update session counter
            Session["counter"] = Convert.ToInt32(Session["counter"]) + 1;
            student.Counter = Convert.ToInt32(Session["counter"]);
            // Update record in DB
            validSRepository.UpdateCounter(student);
            return RedirectToAction("RedirectRating");
            
        }

    }
}
