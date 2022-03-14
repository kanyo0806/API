using Microsoft.AspNetCore.Mvc;
using SovTech.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SovTech.API.Controllers
{
    [Route("api/[Swapi]")]
    [ApiController]
    public class SwapiController : ControllerBase
    {
        private readonly ISwapiService _swapiService;

        public SwapiController(ISwapiService swapiService)
        {
            _swapiService = swapiService;
        }

        [HttpGet]
        //[Route("people")]
        public async Task<IActionResult> People()
        {
            var result = await _swapiService.GetAllPeople();
            return Ok(result);
        }
    }
}
