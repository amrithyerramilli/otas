using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcApplication4.Entities;
using MvcApplication4.Repository.Interfaces;

namespace MvcApplication4.Repository.Repository
{
    public class Context : DbContext,IContext
    {
        public DbSet<Student> Students { get; set; }
        public Context()
            : base("STUD")
        {

        }
    }
}