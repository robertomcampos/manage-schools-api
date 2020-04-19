using ElevaManageSchools.Models;
using ElevaManageSchools.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElevaManageSchools.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SchoolController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices]ISchoolService schoolService)
        {
            return Ok(schoolService.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices]ISchoolService schoolService, SchoolRequest request)
        {
            return Ok(await schoolService.Create(request));
        }
    }
}
