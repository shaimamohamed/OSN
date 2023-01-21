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
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        #region Student Actions
        public async Task<GeneralResponse<List<Student>>> GetALLStudents()
        {

            var respnose = new GeneralResponse<List<Student>>();

            var students = _studentRepository.GetALLStudents();

            if (students == null || students.Count <= 0)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<List<Student>>()
            {
                Success = true,
                Data = students
            };

            return respnose;

        }
        public async Task<GeneralResponse<StuentByNameResponse>> GetStuentByName(StuentByNameRequest request)
        {

            var respnose = new GeneralResponse<StuentByNameResponse>();

            var studentt = _studentRepository.GetALLStudents()?.SingleOrDefault(n => n.Name.ToLower().Trim().Contains(request.StudentName.ToLower().Trim()));

            if (studentt == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<StuentByNameResponse>()
            {
                Success = true,
                Data = new StuentByNameResponse()
                {
                    student = studentt,
                    //parents = studentt.Parents.ToList()
                }
            };

            return respnose;

        }
        public async Task<GeneralResponse<Student>> GetStudentById(int Id)
        {

            var respnose = new GeneralResponse<Student>();

            var isValid = Id > 0;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var student = _studentRepository.GetStudentById(Id);

            if (student == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Student>()
            {
                Success = true,
                Data = student
            };

            return respnose;
        }
        public async Task<GeneralResponse<Student>> CreateStudent(Student request)
        {

            var respnose = new GeneralResponse<Student>();

            var isValid = request != null;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var result = _studentRepository.CreateStudent(request);

            if (result == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Student>()
            {
                Success = true,
                Data = result
            };

            return respnose;
        }
        public async Task<GeneralResponse<Student>> UpdateStudent(Student request)
        {

            var respnose = new GeneralResponse<Student>();

            var isValid = request != null;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var result = _studentRepository.UpdateStudent(request);

            if (result == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Student>()
            {
                Success = true,
                Data = result
            };

            return respnose;
        }
        public async Task<GeneralResponse<Student>> DeleteStudent(int Id)
        {

            var respnose = new GeneralResponse<Student>();

            var isValid = Id > 0;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            Student student = new Student();

            student = _studentRepository.GetStudentById(Id);

            if (student == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }
            var result = _studentRepository.DeleteStudent(Id);

            respnose = new GeneralResponse<Student>()
            {
                Success = true,
                Data = result
            };

            return respnose;
        }
        #endregion

        #region Parents Actions
        public async Task<GeneralResponse<List<Parent>>> GetALLParents()
        {

            var respnose = new GeneralResponse<List<Parent>>();

            var parents = _studentRepository.GetALLParents();

            if (parents == null || parents.Count <= 0)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<List<Parent>>()
            {
                Success = true,
                Data = parents
            };

            return respnose;

        }
        public async Task<GeneralResponse<Parent>> GetParentById(int Id)
        {
            var respnose = new GeneralResponse<Parent>();

            var isValid = Id > 0;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var parent = _studentRepository.GetParentById(Id);

            if (parent == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Parent>()
            {
                Success = true,
                Data = parent
            };

            return respnose;
        }
        public async Task<GeneralResponse<Parent>> CreateParent(Parent request)
        {

            var respnose = new GeneralResponse<Parent>();

            var isValid = request != null;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var result = _studentRepository.CreateParent(request);

            if (result == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Parent>()
            {
                Success = true,
                Data = result
            };

            return respnose;
        }
        public async Task<GeneralResponse<Parent>> UpdateParent(Parent request)
        {

            var respnose = new GeneralResponse<Parent>();

            var isValid = request != null;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var result = _studentRepository.UpdateParent(request);

            if (result == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }

            respnose = new GeneralResponse<Parent>()
            {
                Success = true,
                Data = result
            };

            return respnose;
        }
        public async Task<GeneralResponse<Parent>> DeleteParent(int Id)
        {

            var respnose = new GeneralResponse<Parent>();

            var isValid = Id > 0;
            if (!isValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            Parent parent = new Parent();

            parent = _studentRepository.GetParentById(Id);

            if (parent == null)
            {
                respnose.Message = "Not Found";
                return respnose;
            }
            var result = _studentRepository.DeleteParent(Id);

            respnose = new GeneralResponse<Parent>()
            {
                Success = true,
                Data = result
            };

            return respnose;
        }
        #endregion

    }
}
