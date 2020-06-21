using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kolokwium.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kolokwium.Controllers
{
    [Route("api/musicians")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {

        private readonly IMusicDbService _dbService;
        public MusiciansController(IMusicDbService service)
        {
            _dbService = service;
        }

        [HttpGet]
        public IActionResult TestSample()
        {
            return Ok("Dziala");
        }


    }
}