using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication4.Entities;

namespace MvcApplication4.Repository.Interfaces
{
    public interface IStudentRepository
    {
        IList<string> GetAllStudents();
    }
}