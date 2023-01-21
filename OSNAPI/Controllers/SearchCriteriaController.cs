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
using Core.Model.Search;

namespace OSNAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchCriteriaController : ControllerBase
    {
        private readonly IStudentService _studentService;
        private readonly ISubjectService _subjectService;
        private readonly ILogger _logger;
        public SearchCriteriaController(ILogger logger, IStudentService studentService, ISubjectService subjectService)
        {
            _studentService = studentService;
            _subjectService = subjectService;
            _logger = logger;
        }

        #region Actions
        [Produces("application/json")]
        [HttpGet("GetStudentByName")]
        public async Task<IActionResult> GetStudentByName(string Name)
        {
            var customerId = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out customerId);

            var response = await _studentService.GetStuentByName(new StuentByNameRequest() { StudentName = Name});

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetSubjectByNameAndTermRequest")]
        public async Task<IActionResult> GetSubjectByNameandTermRequest(SubjectByNameandTermRequest request)
        {
            var customerId = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out customerId);

            var response = await _subjectService.GetSubjectBystudentAndTerm(
                           new SubjectByNameandTermRequest() { Student = request.Student, Term = request.Term });

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        #endregion


    }
}
