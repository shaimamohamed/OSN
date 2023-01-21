using Core.Entities;
using Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Inerfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OSNAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ILogger _logger;
        public StudentController(ILogger logger , IStudentService studentService)
        {
            _studentService = studentService;
            _logger = logger;
        }

        #region Students Actions
        [Produces("application/json")]
        [Authorize]
        [HttpGet("GetAllStudents")]
        public async Task<IActionResult> GetAllStudent()
        {
            var Id = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out Id);

            var response = await _studentService.GetALLStudents();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetStudentById")]
        public async Task<IActionResult> GetStudentById(int Id)
        {
            var userId = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out userId);

            var response = await _studentService.GetStudentById(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("CreateNewStudent")]
        public async Task<GeneralResponse<Student>> CreateNewStudent([FromBody] Student request)
        {
            var respnose = new GeneralResponse<Student>();

            //var isValid = !string.IsNullOrEmpty(request.Name);
            //if (!isValid)
            if (!ModelState.IsValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            try
            {

                var stuent = await _studentService.CreateStudent(request);

                if (stuent == null)
                {
                    respnose.Message = "Save Error";
                    return respnose;
                }


                var Response = new Student
                {
                    ID = stuent.Data.ID,
                    Name = request.Name,
                    CurrentTermID = request.CurrentTermID,
                    Email = request.Email,
                    Mobile = request.Mobile,
                    DOB = request.DOB,
                    Gender = request.Gender,
                    //Parents = request.Parents,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "",
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = ""
                };

                respnose = new GeneralResponse<Student>()
                {
                    Success = true,
                    Data = Response
                };

            }
            catch (Exception e)
            {
                _logger.LogError("an Error Occured while saving a product .." + e.Message);
                throw;

            }

            return respnose;
        }

        [HttpPut("UpdateStudent")]
        public async Task<GeneralResponse<Student>> UpdateStudent([FromBody] Student request)
        {
            var respnose = new GeneralResponse<Student>();

            //var isValid = !string.IsNullOrEmpty(request.Name);
            //if (!isValid)
            if (!ModelState.IsValid){
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var student = await _studentService.UpdateStudent(request);

            if (student == null)
            {
                respnose.Message = "Save Error";
                return respnose;
            }


            respnose = new GeneralResponse<Student>()
            {
                Success = true,
                Data = student.Data
            };

            return respnose;
        }

        [HttpDelete("DeleteStudent")]
        public async Task<IActionResult> DeleteStudent(int Id)
        {
            var userId = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out userId);

            var response = await _studentService.DeleteStudent(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
        #endregion

        #region Parents Actions
        [Produces("application/json")]
        [Authorize]
        [HttpGet("GetAllParents")]
        public async Task<IActionResult> GetAllParent()
        {
            var Id = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out Id);

            var response = await _studentService.GetALLParents();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetParentById")]
        public async Task<IActionResult> GetParentById(int Id)
        {
            var userId = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out userId);

            var response = await _studentService.GetParentById(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("CreateNewParent")]
        public async Task<GeneralResponse<Parent>> CreateNewParent([FromBody] Parent request)
        {
            var respnose = new GeneralResponse<Parent>();

            //var isValid = !string.IsNullOrEmpty(request.Name);
            //if (!isValid)
            if (!ModelState.IsValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            try
            {

                var stuent = await _studentService.CreateParent(request);

                if (stuent == null)
                {
                    respnose.Message = "Save Error";
                    return respnose;
                }


                var Response = new Parent
                {
                    ID = stuent.Data.ID,
                    Name = request.Name,
                    Email = request.Email,
                    Mobile = request.Mobile,
                    DOB = request.DOB,
                    Type = request.Type,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "",
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = ""
                };

                respnose = new GeneralResponse<Parent>()
                {
                    Success = true,
                    Data = Response
                };

            }
            catch (Exception e)
            {
                _logger.LogError("an Error Occured while saving a product .." + e.Message);
                throw;

            }

            return respnose;
        }

        [HttpPut("UpdateParent")]
        public async Task<GeneralResponse<Parent>> UpdateParent([FromBody] Parent request)
        {
            var respnose = new GeneralResponse<Parent>();

            //var isValid = !string.IsNullOrEmpty(request.Name);
            //if (!isValid)
            if (!ModelState.IsValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var parent = await _studentService.UpdateParent(request);

            if (parent == null)
            {
                respnose.Message = "Save Error";
                return respnose;
            }


            respnose = new GeneralResponse<Parent>()
            {
                Success = true,
                Data = parent.Data
            };

            return respnose;
        }

        [HttpDelete("DeleteParent")]
        public async Task<IActionResult> DeleteParent(int Id)
        {
            var userId = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out userId);

            var response = await _studentService.DeleteParent(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
        #endregion

    }
}
