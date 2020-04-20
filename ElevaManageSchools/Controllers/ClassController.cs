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
    public class ClassController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get([FromServices]IClassService classService, [FromQuery] PagingParameters parameters)
        {
            return Ok(await classService.Get(parameters));
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices]IClassService classService, ClassRequest request)
        {
            if (string.IsNullOrEmpty(request.Name))
                throw new ArgumentNullException(nameof(request.Name));

            if (request.SchoolId == null)
                throw new ArgumentNullException(nameof(request.SchoolId));

            return Ok(await classService.Create(request));
        }
    }
}
