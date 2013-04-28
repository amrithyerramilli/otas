using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcApplication4.Entities;

namespace MvcApplication4.Repository.Interfaces
{
    public interface IContext
    {
        DbSet<Student> Students {get;set;}        
    }
}