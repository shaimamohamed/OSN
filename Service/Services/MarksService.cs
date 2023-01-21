using Core.Entities;
using Core.Model;
using Data.Inerfaces;
using Service.Inerfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MarksService : IMarksService
    {
        private readonly IMarksRepository _marksRepository;
        public MarksService(IMarksRepository marksRepository)
        {
            _marksRepository = marksRepository;
        }

        #region Actions
        public async Task<GeneralResponse<List<Marks>>> GetALLMarks()
        {

            var respnose = new GeneralResponse<List<Marks>>();

            var marks = _marksRepository.GetALLMarks();

            if (marks == null || marks.Count <= 0)
            {
                respnose.Message = "Not Found";
                return respnose;
            }


            respnose = new GeneralResponse<List<Marks>>()
            {
                Success = true,
                Data = marks
            };

            return respnose;

        }
        public async Task<GeneralResponse<Marks>> GetMarksById(int Id)
        {
            var respnose = new GeneralResponse<Marks>();

            var isValid = Id > 0;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var mark = _marksRepository.GetMarksById(Id);

            if (mark == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Marks>()
            {
                Success = true,
                Data = mark
            };

            return respnose;
        }
        public async Task<GeneralResponse<Marks>> CreateMarks(Marks request)
        {

            var respnose = new GeneralResponse<Marks>();

            var isValid = request != null;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var result = _marksRepository.CreateMarks(request);

            if (result == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Marks>()
            {
                Success = true,
                Data = result
            };

            return respnose;
        }
        public async Task<GeneralResponse<Marks>> UpdateMarks(Marks request)
        {
            var respnose = new GeneralResponse<Marks>();

            var isValid = request != null;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var result = _marksRepository.UpdateMarks(request);

            if (result == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Marks>()
            {
                Success = true,
                Data = result
            };

            return respnose;
        }
        public async Task<GeneralResponse<Marks>> DeleteMarks(int Id)
        {

            var respnose = new GeneralResponse<Marks>();

            var isValid = Id > 0;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            Marks marks = new Marks();

            marks = _marksRepository.GetMarksById(Id);

            if (marks == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }
            var result = _marksRepository.DeleteMarks(Id);

            respnose = new GeneralResponse<Marks>()
            {
                Success = true,
                Data = marks
            };

            return respnose;
        }
        #endregion

    }
}
