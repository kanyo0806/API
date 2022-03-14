using Microsoft.AspNetCore.Mvc;
using SovTech.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SovTech.API.Controllers
{
    
    [Route("api/[Chuck]")]
    [ApiController]
    public class ChuckController : ControllerBase
    {
        private readonly IChuckService _chuckService;

        public ChuckController(IChuckService chuckService)
        {
            _chuckService = chuckService;
        }

        [HttpGet]
        //[Route("categories")]
        public async Task<IActionResult> Categories()
        {
            var result = await _chuckService.GetAllCategories();
            return Ok(result);
        }
    }
}
