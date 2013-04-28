using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTAS2.Domain.Entities
{
    public class SubComb
    {
        public String CombID { get; set; }
        public String TeacherID { get; set; }
        public String SubCode { get; set; }
        public String DeptID { get; set; }
        public String Section { get; set; }

        public int? sem { get; set; }
        public float? CGPA { get; set; }
        public int? count { get; set; }
        public float? Percentile { get; set; }
        public Boolean elective { get; set; }

    }
}
