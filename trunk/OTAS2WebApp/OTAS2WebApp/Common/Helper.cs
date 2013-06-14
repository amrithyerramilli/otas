using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using OTAS2.Repository.Repository;
using System.Web.Mvc;
using OTAS2.Domain.Entities;


namespace OTAS2WebApp.Common
{
    public static class Helper
    {
        public static void AddEditedDetails(FormCollection form,Students student)
        {
            string name = "", add = "", email = "";
            decimal ph = 0;
            if (form["name"] != null)
            {
                name = form["name"];
            }
            if (form["add"] != null)
            {
                add = form["add"];
            }
            if (form["ph"] != null)
            {
                ph = Convert.ToDecimal(form["ph"]);
            }
            if (form["email"] != null)
            {
                email = form["email"];
            }
            if (student.Name != name || student.Address != add || student.Phone != ph || student.email != email)
            {
                StudentRepository studRepository = new StudentRepository();
                student.Name = name;
                student.Address = add;
                student.Phone = ph;
                student.email = email;
                studRepository.UpdateStudent(student);
            }

        }
    }
}