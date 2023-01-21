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
    public interface IStudentService
    {
        Task<GeneralResponse<List<Student>>> GetALLStudents();
        Task<GeneralResponse<Student>> GetStudentById(int Id);
        Task<GeneralResponse<StuentByNameResponse>> GetStuentByName(StuentByNameRequest request);
        Task<GeneralResponse<Student>> CreateStudent(Student request);
        Task<GeneralResponse<Student>> UpdateStudent(Student request);
        Task<GeneralResponse<Student>> DeleteStudent(int Id);

        Task<GeneralResponse<List<Parent>>> GetALLParents();
        Task<GeneralResponse<Parent>> GetParentById(int Id);
        Task<GeneralResponse<Parent>> CreateParent(Parent request);
        Task<GeneralResponse<Parent>> UpdateParent(Parent request);
        Task<GeneralResponse<Parent>> DeleteParent(int Id);

    }
}
