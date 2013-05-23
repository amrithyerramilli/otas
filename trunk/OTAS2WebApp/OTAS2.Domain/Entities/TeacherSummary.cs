using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OTAS2.Domain.Entities
{
    public class TeacherSummary
    {
        public string StudentUSN { get; set; }
        public string ComboId { get; set; }
        public string TeacherName { get; set; }
        public string SubName { get; set; }
        public string SubCode { get; set; }
    }
}
