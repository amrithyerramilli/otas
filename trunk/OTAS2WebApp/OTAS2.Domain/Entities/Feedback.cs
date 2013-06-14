using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;


namespace OTAS2.Domain.Entities
{
    [Table("Feedback")]
    public class Feedback
    {
        [Key]
        public int ID { get; set; }
        public string Value { get; set; }
        public string Suggestion { get; set; }
        
    }
}
