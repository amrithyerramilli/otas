using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OTAS2.Domain.Entities;

namespace OTAS2.Repository.Interfaces
{
    public interface IStudentRepository
    {
        IList<Students> GetAllStudents();
        void UpdateStudent(Students record);
    }
}
