﻿using System;
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
    }
}