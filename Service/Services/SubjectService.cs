using Core.Entities;
using Core.Model;
using Core.Model.Search;
using Data.Inerfaces;
using Service.Inerfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class SubjectService : ISubjectService
    {
        private readonly ISubjectRepository _subjectRepository;
        private readonly IMarksRepository _marksRepository;
        public SubjectService(ISubjectRepository subjectRepository , IMarksRepository marksRepository)
        {
            _subjectRepository = subjectRepository;
            _marksRepository = marksRepository;
        }

        #region Actions
        public async Task<GeneralResponse<List<Subject>>> GetALLSubjects()
        {

            var respnose = new GeneralResponse<List<Subject>>();

            var subjects = _subjectRepository.GetALLSubjects();

            if (subjects == null || subjects.Count <= 0)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<List<Subject>>()
            {
                Success = true,
                Data = subjects
            };

            return respnose;

        }

        public async Task<GeneralResponse<SubjectByNameandTermResponse>> GetSubjectBystudentAndTerm(SubjectByNameandTermRequest request)
        {

            var respnose = new GeneralResponse<SubjectByNameandTermResponse>();

            var marks = _marksRepository.GetALLMarks()?
                        .Where(q => q.StudentId == request.Student && q.TermId == request.Term).ToList();

            if (marks == null || marks.Count <= 0)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            //List<Term> Temp = new List<Term>();
            //foreach (var item in products)
            //{
            //    var productResponse = new terms
            //    {
            //        Id = item.Id,
            //        Code = item.Code,
            //        Name = item.Name,
            //        Cost = item.Cost,
            //        Price = item.PurchaseSingleItemPrice,
            //        ImageBase64 = item.ImageBase64,
            //        CreateDate = item.CreateDate,
            //        UpdateDate = item.UpdateDate
            //    };
            //    Temp.Add(productResponse);
            //}


            respnose = new GeneralResponse<SubjectByNameandTermResponse>()
            {
                Success = true,
                Data = new SubjectByNameandTermResponse()
                {
                    marks = marks
                }
            };

            return respnose;

        }

        public async Task<GeneralResponse<Subject>> GetSubjectById(int Id)
        {

            var respnose = new GeneralResponse<Subject>();

            var isValid = Id > 0;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var subject = _subjectRepository.GetSubjectById(Id);

            if (subject == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Subject>()
            {
                Success = true,
                Data = subject
            };

            return respnose;
        }
        public async Task<GeneralResponse<Subject>> CreateSubject(Subject request)
        {

            var respnose = new GeneralResponse<Subject>();

            var isValid = request != null;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }


            var result = _subjectRepository.CreateSubject(request);

            if (result == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Subject>()
            {
                Success = true,
                Data = result
            };

            return respnose;
        }
        public async Task<GeneralResponse<Subject>> UpdateSubject(Subject request)
        {

            var respnose = new GeneralResponse<Subject>();

            var isValid = request != null;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var result = _subjectRepository.UpdateSubject(request);

            if (result == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Subject>()
            {
                Success = true,
                Data = result
            };

            return respnose;
        }
        public async Task<GeneralResponse<Subject>> DeleteSubject(int Id)
        {

            var respnose = new GeneralResponse<Subject>();

            var isValid = Id > 0;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            Subject subject = new Subject();

            subject = _subjectRepository.GetSubjectById(Id);

            if (subject == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }
            var result = _subjectRepository.DeleteSubject(Id);

            respnose = new GeneralResponse<Subject>()
            {
                Success = true,
                Data = result
            };

            return respnose;
        }
        #endregion

    }
}
