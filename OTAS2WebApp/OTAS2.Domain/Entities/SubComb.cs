using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OTAS2.Domain.Entities
{
    [Table("SubComb")]
    public class SubComb
    {
        [Key]
        public String CombID { get; set; }
        public String TeacherID { get; set; }
        public String SubCode { get; set; }
        public String DeptID { get; set; }
        public String Section { get; set; }

        public int? sem { get; set; }
        public decimal? CGPA { get; set; }
        public int? count { get; set; }
        public decimal? Percentile { get; set; }
        public Boolean elective { get; set; }

    }
}
