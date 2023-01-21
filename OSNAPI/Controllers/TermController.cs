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
    public class TermController : ControllerBase
    {
        private readonly ITermService _termService;
        private readonly ILogger _logger;
        public TermController(ILogger logger , ITermService termService)
        {
            _termService = _termService;
            _logger = logger;
        }

        #region Actions
        [Produces("application/json")]
        [Authorize]
        [HttpGet("GetAllTerms")]
        public async Task<IActionResult> GetAllTerms()
        {
            var Id = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out Id);

            var response = await _termService.GetALLTerms();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("GetTermById")]
        public async Task<IActionResult> GetTermById(int Id)
        {
            var userId = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out userId);

            var response = await _termService.GetTermById(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpPost("CreateNewTerm")]
        public async Task<GeneralResponse<Term>> CreateNewTerm([FromBody] Term request)
        {
            var respnose = new GeneralResponse<Term>();

            //var isValid = !string.IsNullOrEmpty(request.Name);
            //if (!isValid)
            if (!ModelState.IsValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            try
            {

                var product = await _termService.CreateTerm(request);

                if (product == null)
                {
                    respnose.Message = "Save Error";
                    return respnose;
                }

               
                var Response = new Term
                {
                    ID = product.Data.ID,
                    Name = request.Name,
                    CreatedOn = DateTime.Now,
                    CreatedBy = "",
                    UpdatedOn = DateTime.Now,
                    UpdatedBy = ""
                };

                respnose = new GeneralResponse<Term>()
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

        [HttpPut("UpdateTerm")]
        public async Task<GeneralResponse<Term>> UpdateTerm([FromBody] Term request)
        {
            var respnose = new GeneralResponse<Term>();

            //var isValid = !string.IsNullOrEmpty(request.Name);
            //if (!isValid)
            if (!ModelState.IsValid)
            {
                respnose.Message = "Validaton Error";
                return respnose;
            }

            var term = await _termService.UpdateTerm(request);

            if (term == null)
            {
                respnose.Message = "Save Error";
                return respnose;
            }

           
            respnose = new GeneralResponse<Term>()
            {
                Success = true,
                Data = term.Data
            };

            return respnose;
        }

        [HttpDelete("DeleteTerm")]
        public async Task<IActionResult> DeleteTerm(int Id)
        {
            var userId = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out userId);

            var response = await _termService.DeleteTerm(Id);

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }
        #endregion

    }
}
