using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Models
{
    public class StudentModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20)]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NameOfDepartment { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}
