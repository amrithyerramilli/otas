using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication4.Repository.Interfaces;
using MvcApplication4.Entities;



namespace MvcApplication4.Repository.Repository
{
    public class StudentRepository : IStudentRepository
    {

        IContext context;

        public StudentRepository()
            :this(new Context())
        {
        }
        public StudentRepository(IContext  myContext)
        {
            this.context = myContext;
        }

        public IList<string> GetAllStudents()
        {
            var usn = (from i in context.Students.ToList()
                       select  i.USN ).ToList();

            return usn;
        }

    }
}