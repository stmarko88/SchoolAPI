using SchoolAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> AllDepartments { get; }
    }
}
