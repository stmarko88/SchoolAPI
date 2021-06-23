using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public StudentRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        public IEnumerable<Student> AllStudents
        {
            get { return _schoolDbContext.Students.Include(s => s.Department); }
        }

        public Student GetStudentById(int studentId)
        {
            return _schoolDbContext.Students.FirstOrDefault(s => s.Id == studentId);
        }
    }
}
