using SchoolAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public interface IStudentRepository
    {
        IEnumerable<Student> AllStudents { get; }
        Student GetStudentById(int studentId);
        Student AddStudent(Student student);
        Student UpdateStudent(Student student);
        bool DeleteStudent(int studentId);
    }
}
