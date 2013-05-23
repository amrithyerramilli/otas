using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OTAS2.Domain.Entities
{
    [Table("Subject")]
    public class Subject
    {
        [Key]
        public string SubCode { get; set; }
        public string SubName { get; set; }
        public int Sem { get; set; }
        public string DeptId { get; set; }
        public int? elective { get; set; }
    }
}
