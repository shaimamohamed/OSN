using Core.Entities;
using Data.Inerfaces;
using Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.Inerfaces;

namespace Service.Services
{
    public class TermService : ITermService
    {
        private readonly ITermRepository _termRepository;
        public TermService(ITermRepository termRepository)
        {
            _termRepository = termRepository;
        }

        #region Actions
        public async Task<GeneralResponse<List<Term>>> GetALLTerms()
        {

            var respnose = new GeneralResponse<List<Term>>();

            var terms = _termRepository.GetALLTerms();

            if (terms == null || terms.Count <= 0)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<List<Term>>()
            {
                Success = true,
                Data = terms
            };

            return respnose;

        }
        public async Task<GeneralResponse<Term>> GetTermById(int Id)
        {

            var respnose = new GeneralResponse<Term>();

            var isValid = Id > 0;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var term = _termRepository.GetTermById(Id);

            if (term == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Term>()
            {
                Success = true,
                Data = term
            };

            return respnose;
        }
        public async Task<GeneralResponse<Term>> CreateTerm(Term request)
        {

            var respnose = new GeneralResponse<Term>();

            var isValid = request != null;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var result = _termRepository.CreateTerm(request);

            if (result == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Term>()
            {
                Success = true,
                Data = result
            };

            return respnose;
        }
        public async Task<GeneralResponse<Term>> UpdateTerm(Term request)
        {

            var respnose = new GeneralResponse<Term>();

            var isValid = request != null;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            
            var result = _termRepository.UpdateTerm(request);

            if (result == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Term>()
            {
                Success = true,
                Data = result
            };

            return respnose;
        }
        public async Task<GeneralResponse<Term>> DeleteTerm(int Id)
        {

            var respnose = new GeneralResponse<Term>();

            var isValid = Id > 0;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            Term term = new Term();

            term = _termRepository.GetTermById(Id);

            if (term == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }
            var result = _termRepository.DeleteTerm(Id);

            respnose = new GeneralResponse<Term>()
            {
                Success = true,
                Data = term
            };

            return respnose;
        }
        #endregion
    }
}
