using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OTAS2.Domain.Entities;
using OTAS2.Repository.Interfaces;

namespace OTAS2.Repository.Repository
{
    public class SubjectRepository : ISubjectRepository
    {
        IContext context;
        public SubjectRepository()
            : this(new Context())
        {
        }
        public SubjectRepository(IContext context)
        {
            this.context = context;
        }
        public IList<Subject> GetAllSubjects()
        {
            return context.Subjects.ToList();
        }
    }
}
