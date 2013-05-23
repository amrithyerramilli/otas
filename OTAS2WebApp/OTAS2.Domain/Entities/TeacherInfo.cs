using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OTAS2.Domain.Entities
{
    [Table("TeacherInfo")]
    public class TeacherInfo
    {
        [Key]
        public string TeacherId { get; set; }
        public string TeacherName { get; set; }
        public string DeptId { get; set; }
        public string Designation { get; set; }
    }
}
