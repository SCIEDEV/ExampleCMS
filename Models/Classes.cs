using System;
using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class Classes
    {
        [Key]

        public int ID { get; set; }

        [Required(ErrorMessage = "Period is required.")]
        [Range(1, 10, ErrorMessage = "Period must be between 1 and 10.")]
        public int period { get; set; }

        [Required(ErrorMessage = "Class name is required.")]
        [StringLength(100, ErrorMessage = "Class name can't be longer than 100 characters.")]
        public string className { get; set; }
    }
}

// database migration