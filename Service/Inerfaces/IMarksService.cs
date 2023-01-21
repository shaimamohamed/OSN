using Core.Entities;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Inerfaces
{
    public interface IMarksService
    {
        Task<GeneralResponse<List<Marks>>> GetALLMarks();
        Task<GeneralResponse<Marks>> GetMarksById(int Id);
        Task<GeneralResponse<Marks>> CreateMarks(Marks request);
        Task<GeneralResponse<Marks>> UpdateMarks(Marks request);
        Task<GeneralResponse<Marks>> DeleteMarks(int Id);
    }
}
