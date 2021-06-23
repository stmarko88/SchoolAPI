using AutoMapper;
using SchoolAPI.Models;
using SchoolAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            this.CreateMap<Student, StudentModel>()
                .ForMember(s => s.NameOfDepartment, b => b.MapFrom(c => c.Department.Name));
        }
    }
}
