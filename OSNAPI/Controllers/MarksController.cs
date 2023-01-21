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
    public class MarksController : ControllerBase
    {
        private readonly IMarksService _marksService;
        private readonly ILogger _logger;
        public MarksController(ILogger logger , IMarksService marksService)
        {
            _marksService = marksService;
            _logger = logger;
        }

        #region Actions
        [Produces("application/json")]
        [Authorize]
        [HttpGet("GetAllMarks")]
        public async Task<IActionResult> GetAllMarks()
        {
            var Id = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out Id);

            var response = await _marksService.GetALLMarks();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetMarksById")]
        public async Task<IActionResult> GetMarksById(int Id)
        {
            var userId = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out userId);

            var response = await _marksService.GetMarksById(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("CreateNewMarks")]
        public async Task<GeneralResponse<Marks>> CreateNewMarks([FromBody] Marks request)
        {
            var respnose = new GeneralResponse<Marks>();

            //var isValid = !string.IsNullOrEmpty(request.Name);
            //if (!isValid)
            if (!ModelState.IsValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            try
            {

                var marks = await _marksService.CreateMarks(request);

                if (marks == null)
                {
                    respnose.Message = "Save Error";
                    return respnose;
                }

                var Response = new Marks
                {
                    ID = marks.Data.ID,
                    StudyYear = request.StudyYear,
                    StudentId = request.StudentId,
                    Student = request.Student,
                    SubjectId = request.SubjectId,
                    Subject = request.Subject,
                    TermId = request.TermId,
                    Term = request.Term,
                    Mark = request.Mark,
                    Comment = request.Comment,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "",
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = ""
                };
                respnose = new GeneralResponse<Marks>()
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

        [HttpPut("UpdateMarks")]
        public async Task<GeneralResponse<Marks>> UpdateMarks([FromBody] Marks request)
        {
            var respnose = new GeneralResponse<Marks>();

           // var isValid = !string.IsNullOrEmpty(request.Name);
            //if (!isValid)
            if (!ModelState.IsValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var marks = await _marksService.UpdateMarks(request);

            if (marks == null)
            {
                respnose.Message = "Save Error";
                return respnose;
            }


            respnose = new GeneralResponse<Marks>()
            {
                Success = true,
                Data = marks.Data
            };

            return respnose;
        }

        [HttpDelete("DeleteMarks")]
        public async Task<IActionResult> DeleteMarks(int Id)
        {
            var userId = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out userId);

            var response = await _marksService.DeleteMarks(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
        #endregion

    }
}
