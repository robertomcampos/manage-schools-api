using ElevaManageSchools.Models;
using ElevaManageSchools.Services;
using ElevaManageSchools.Services.Paging;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace ElevaManageSchools.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices]ISchoolService schoolService, [FromQuery]PagingParameters parameters = null)
        {
            return Ok(await schoolService.Get(parameters));
        }

        [HttpGet("all")]
        public async Task<IActionResult> Get([FromServices]ISchoolService schoolService)
        {
            return Ok(await schoolService.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices]ISchoolService schoolService, SchoolRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new ArgumentNullException(nameof(request.Name));

            if (string.IsNullOrEmpty(request.Address))
                throw new ArgumentNullException(nameof(request.Address));

            return Ok(await schoolService.Create(request));
        }
    }
}
