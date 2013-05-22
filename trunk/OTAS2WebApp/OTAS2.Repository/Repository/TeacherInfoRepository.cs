using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OTAS2.Domain.Entities;
using OTAS2.Repository.Interfaces;

namespace OTAS2.Repository.Repository
{
    public class TeacherInfoRepository : ITeacherInfoRepository
    {
        IContext context;
        public TeacherInfoRepository()
            : this(new Context())
        {
        }
        public TeacherInfoRepository(IContext context)
        {
            this.context = context;
        }
        public IList<TeacherInfo> GetAllTeacherInfo()
        {
            return context.TeacherInfo.ToList();
        }
    }
}
