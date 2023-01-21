using Core.Entities;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Inerfaces
{
    public interface ITermService
    {
         Task<GeneralResponse<List<Term>>> GetALLTerms();
         Task<GeneralResponse<Term>> GetTermById(int Id);
         Task<GeneralResponse<Term>> CreateTerm(Term request);
         Task<GeneralResponse<Term>> UpdateTerm(Term request);
         Task<GeneralResponse<Term>> DeleteTerm(int Id);
    }
}
