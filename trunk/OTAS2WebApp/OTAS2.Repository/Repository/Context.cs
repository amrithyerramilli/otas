using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using OTAS2.Domain.Entities;
using OTAS2.Repository.Interfaces;

namespace OTAS2.Repository.Repository
{
    public class Context : DbContext,IContext 
    {
        public DbSet<Students> Students { get; set; }
        public DbSet<ValidS> ValidS { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<SubComb> SubComb { get; set; }
        public DbSet<TeacherInfo> TeacherInfo { get; set; }
        public DbSet<RID_TABLE> RID_TABLE { get; set; }
        public Context()
            : base("Xerxes")
        {
        }
    }
}
