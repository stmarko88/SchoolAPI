using AutoMapper;
using SchoolAPI.Models;
using SchoolAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public class SchoolProfile : Profile
    {
        public SchoolProfile()
        {
            this.CreateMap<StudentModel, Student>();
            this.CreateMap<Student, StudentModel>()
                .ForMember(s => s.NameOfDepartment, b => b.MapFrom(c => c.Department.Name));

            this.CreateMap<Final, FinalModel>()
                .ReverseMap();

            this.CreateMap<Course, CourseModel>()
                .ReverseMap();
        }
    }
}
