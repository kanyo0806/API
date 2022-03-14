using Microsoft.Extensions.Configuration;
using SovTech.Common.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SovTech.Core.Services
{
    public class SwapiService : ISwapiService
    {
        private readonly ISharedService _sharedService;
        private readonly IConfiguration _configuration;

        public SwapiService(ISharedService sharedService,
            IConfiguration config)
        {
            _configuration = config;
            _sharedService = sharedService;
        }

        public async Task<List<string>> GetAllPeople()
        {
            return await _sharedService.GetAsync<List<string>>(_configuration["Swapi:BaseAddress"], _configuration["Swapi:PeopleAddress"]);
        }

        public async Task<List<string>> Search(string query)
        {
            return await _sharedService.GetAsync<List<string>>(_configuration["Swapi:BaseAddress"], $"/?search={query}");
        }
    }
}
