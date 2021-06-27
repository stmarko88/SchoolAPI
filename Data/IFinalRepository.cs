using SchoolAPI.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Data
{
    public interface IFinalRepository
    {
        IEnumerable<Final> AllFinals { get; }
        Final GetFinalById(int id);
        IEnumerable<Final> GetFinalsByStudentId(int studentId);
        Final GetFinalByStudentId(int studentId, int id);
        Final AddFinal(Final final);
        Final UpdateFinal(Final final);
        void DeleteFinal(int id);
    }
}
