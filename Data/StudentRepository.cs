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

        public Student AddStudent(Student student)
        {
            _schoolDbContext.Students.Add(student);
            _schoolDbContext.SaveChanges();
            return student;
        }

        public bool DeleteStudent(int studentId)
        {
            var student = _schoolDbContext.Students.FirstOrDefault(s => s.Id == studentId);
            bool success = false;
            if (student != null)
            {
                _schoolDbContext.Remove(student);
                _schoolDbContext.SaveChanges();
                success = true;
            }
            return success;
        }

        public Student GetStudentById(int studentId)
        {
            return _schoolDbContext.Students.FirstOrDefault(s => s.Id == studentId);
        }

        public Student UpdateStudent(Student student)
        {
            Student updatedStudent = _schoolDbContext.Students.FirstOrDefault(s => s.Id == student.Id);
            if (updatedStudent != null)
            {
                updatedStudent.FirstName = student.FirstName;
                updatedStudent.LastName = student.LastName;
                updatedStudent.DepartmentId = student.DepartmentId;
                _schoolDbContext.SaveChanges();
            }
            return updatedStudent;
        }
    }
}
