﻿using ElevaManageSchools.Models;
using ElevaManageSchools.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ElevaManageSchools.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClassController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromServices]IClassService classService)
        {
            return Ok(classService.Get());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromServices]IClassService classService, ClassRequest request)
        {
            return Ok(await classService.Create(request));
        }
    }
}