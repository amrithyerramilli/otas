using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OTAS2.Repository.Interfaces;
using OTAS2.Domain.Entities;
using System.Data;

namespace OTAS2.Repository.Repository
{
    public class StudentRepository : IStudentRepository
    {
        Context context;
        public StudentRepository()
            : this(new Context())
        {
        }
        public StudentRepository(Context context)
        {
            this.context = context;
        }
        public IList<Students> GetAllStudents()
        {
            return context.Students.ToList();
        }
        public void UpdateStudent(Students record)
        {
            context.Entry(record).State = EntityState.Modified;
            Save();
        }
        public void Save()
        {
            try
            {
                context.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
