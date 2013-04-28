using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OTAS2.Repository.Interfaces;
using OTAS2.Domain.Entities;

namespace OTAS2.Repository.Repository
{
    public class StudentRepository : IStudentRepository
    {
        IContext context;
        public StudentRepository()
            : this(new Context())
        {
        }
        public StudentRepository(IContext context)
        {
            this.context = context;
        }
        public IList<Student> GetAllStudents()
        {
            return context.Students.ToList();
        }
    }
}
