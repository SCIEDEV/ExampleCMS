using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Classes
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int period { get; set; }
        [Required]
        public string className { get; set; }
    }
}

// database migration