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
    [Route("api/[controller]")]
    [ApiController]
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly ILogger _logger;
        public SubjectController(ILogger logger , ISubjectService subjectService)
        {
            _subjectService = subjectService;
            _logger = logger;
        }

        #region Actions
        [Produces("application/json")]
        [Authorize]
        [HttpGet("GetAllSubjects")]
        public async Task<IActionResult> GetAllSubjects()
        {
            var Id = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out Id);

            var response = await _subjectService.GetALLSubjects();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetSubjectById")]
        public async Task<IActionResult> GetSubjectById(int Id)
        {
            var userId = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out userId);

            var response = await _subjectService.GetSubjectById(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("CreateNewSubject")]
        public async Task<GeneralResponse<Subject>> CreateNewSubject([FromBody] Subject request)
        {
            var respnose = new GeneralResponse<Subject>();

            //var isValid = !string.IsNullOrEmpty(request.Name);
            //if (!isValid)
            if (!ModelState.IsValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            try
            {

                var product = await _subjectService.CreateSubject(request);

                if (product == null)
                {
                    respnose.Message = "Save Error";
                    return respnose;
                }


                var Response = new Subject
                {
                    ID = product.Data.ID,
                    Name = request.Name,
                    Description =request.Description,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "",
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = ""
                };

                respnose = new GeneralResponse<Subject>()
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

        [HttpPut("UpdateSubject")]
        public async Task<GeneralResponse<Subject>> UpdateSubject([FromBody] Subject request)
        {
            var respnose = new GeneralResponse<Subject>();

            //var isValid = !string.IsNullOrEmpty(request.Name);
            //if (!isValid)
            if (!ModelState.IsValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var subject = await _subjectService.UpdateSubject(request);

            if (subject == null)
            {
                respnose.Message = "Save Error";
                return respnose;
            }


            respnose = new GeneralResponse<Subject>()
            {
                Success = true,
                Data = subject.Data
            };

            return respnose;
        }

        [HttpDelete("DeleteSubject")]
        public async Task<IActionResult> DeleteSubject(int Id)
        {
            var userId = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out userId);

            var response = await _subjectService.DeleteSubject(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
        #endregion

    }
}
