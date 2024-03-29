﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OTAS2.Domain.Entities
{
    public class Students
    {
        [Key]
        public String USN { get; set; }
        public String Name { get; set; }
        public String Address { get; set; }
        public String email { get; set; }
        public String Sec { get; set; }      
        [NotMapped]
        public string Elective1Name { get; set; }
        public String Elective1 { get; set; }
        [NotMapped]
        public string Elective2Name { get; set; }
        public String Elective2 { get; set; }
        public String DeptID { get; set; }
        public int? sem { get; set; }
        public decimal? Phone { get; set; }
    }
}
