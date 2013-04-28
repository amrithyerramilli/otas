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
        public DbSet<Student> Students { get; set; }
        public Context()
            : base("Xerxes")
        {
        }
    }
}
