using SchoolAPI.Data.Entities;
using SchoolAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public DepartmentRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }
        public IEnumerable<Department> AllDepartments
        {
            get { return _schoolDbContext.Departments; }
        }
    }
}
