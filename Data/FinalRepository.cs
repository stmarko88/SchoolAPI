using Microsoft.EntityFrameworkCore;
using SchoolAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public class FinalRepository : IFinalRepository
    {
        private readonly SchoolDbContext _schoolDbContext;

        public FinalRepository(SchoolDbContext schoolDbContext)
        {
            _schoolDbContext = schoolDbContext;
        }

        public IEnumerable<Final> AllFinals
        {
            get { return _schoolDbContext.Finals.Include(f => f.Course); }
        }

        public Final GetFinalById(int id)
        {
            var final = AllFinals.FirstOrDefault(f => f.Id == id);
            return final;
        }

        public IEnumerable<Final> GetFinalsByStudentId(int studentId)
        {
            IEnumerable<Final> finals = AllFinals.Where(s => s.StudentId == studentId);
            return finals;
        }

        public Final AddFinal(Final final)
        {
            _schoolDbContext.Finals.Add(final);
            _schoolDbContext.SaveChanges();
            return final;
        }

        public Final GetFinalByStudentId(int studentId, int id)
        {
            Final final = AllFinals.FirstOrDefault(s => s.StudentId == studentId && s.Id == id);
            return final;
        }

        public Final UpdateFinal(Final final)
        {
            Final updatedFinal = _schoolDbContext.Finals.FirstOrDefault(f => f.Id == final.Id);
            if (updatedFinal != null)
            {
                updatedFinal.Mark = final.Mark;
                updatedFinal.Name = final.Name;
                _schoolDbContext.SaveChanges();
            }
            return updatedFinal;
        }

        public void DeleteFinal(int id)
        {
            Final final = _schoolDbContext.Finals.FirstOrDefault(f => f.Id == id);
            if (final != null)
            {
                _schoolDbContext.Finals.Remove(final);
                _schoolDbContext.SaveChanges();
            }
        }
    }
}
