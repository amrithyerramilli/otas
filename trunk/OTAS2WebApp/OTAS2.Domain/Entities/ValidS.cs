using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OTAS2.Domain.Entities
{
    public class ValidS
    {
        [Key]
        public string USN { get; set; }
        public Boolean FG { get; set; }
        public int? Counter { get; set; }
        public string PassGen { get; set; }
        public Boolean StudentDetails { get; set; }
    }
}
