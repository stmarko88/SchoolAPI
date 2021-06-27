using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class FinalModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        public DateTime Date { get; set; }
        [Range(5, 10)]
        public int Mark { get; set; }
        public int CourseId { get; set; }
        public CourseModel Course { get; set; }
        public int StudentId { get; set; }
    }
}
