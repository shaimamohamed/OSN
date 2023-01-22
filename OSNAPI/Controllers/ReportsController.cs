using Core.Model.Search;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Service.Inerfaces;
using Service.Services;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OSNAPI.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportsService;
       private readonly ILogger<ReportsController> _logger;
        public ReportsController( IReportsService reportsService , ILogger<ReportsController> logger)
        {
            _reportsService = reportsService;
            _logger = logger;
        }



        #region Actions

        //[Produces("application/json")]
        //[HttpGet("Report1")]
        [HttpGet]
        [Route("Report1")]
        public async Task<IActionResult> Report1()
        {
            var Id = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out Id);

            var response = await _reportsService.Report1();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("Report2")]
        public async Task<IActionResult> Report2()
        {
            var Id = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out Id);

            var response = await _reportsService.Report2();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("Report3")]
        public async Task<IActionResult> Report3()
        {
            var Id = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out Id);

            var response = await _reportsService.Report3();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        [HttpGet("Report4")]
        public async Task<IActionResult> Report4()
        {
            var Id = 0;
            int.TryParse(User?.Claims?.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier)?.Value, out Id);

            var response = await _reportsService.Report4();

            if (!response.Success)
                return BadRequest(response);

            return Ok(response);
        }

        #endregion



    }
}
