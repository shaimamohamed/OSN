using Core.Entities;
using Core.Model;
using Core.Model.Search;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Inerfaces
{
    public interface ISubjectService
    {
        Task<GeneralResponse<List<Subject>>> GetALLSubjects();
        Task<GeneralResponse<Subject>> GetSubjectById(int Id);
        Task<GeneralResponse<SubjectByNameandTermResponse>> GetSubjectBystudentAndTerm(SubjectByNameandTermRequest request);
        Task<GeneralResponse<Subject>> CreateSubject(Subject request);
        Task<GeneralResponse<Subject>> UpdateSubject(Subject request);
        Task<GeneralResponse<Subject>> DeleteSubject(int Id);
    }
}
