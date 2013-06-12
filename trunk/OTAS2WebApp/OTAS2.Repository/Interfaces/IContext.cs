using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Web;
using OTAS2.Domain.Entities;

namespace OTAS2.Repository.Interfaces
{
    public interface IContext
    {
        DbSet<Students> Students { get; set; }
        DbSet<ValidS> ValidS { get; set; }
        DbSet<Subject> Subjects { get; set; }
        DbSet<SubComb> SubComb { get; set; }
        DbSet<TeacherInfo> TeacherInfo { get; set; }
        DbSet<RID_TABLE> RID_TABLE { get; set; }
    }
}
