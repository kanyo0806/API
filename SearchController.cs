using Microsoft.AspNetCore.Mvc;
using SovTech.Common.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace SovTech.API.Controllers
{
    [Route("api/[Search]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;

        public SearchController(ISearchService searchService)
        {
            _searchService = searchService;
        }

        [HttpGet]
        //[Route("search")]
        public async Task<IActionResult> Search(string query)
        {
            var result = await _searchService.Search(query);
            return Ok(result);
        }
    }
}
