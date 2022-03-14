using Microsoft.Extensions.Configuration;
using SovTech.Common.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SovTech.Core.Services
{
    public class ChuckService : IChuckService
    {
        private readonly ISharedService _sharedService;
        private readonly IConfiguration _configuration;

        public ChuckService(ISharedService sharedService,
            IConfiguration config)
        {
            _configuration = config;
            _sharedService = sharedService;
        }

        public async Task<List<string>> GetAllCategories()
        {
            return await _sharedService.GetAsync<List<string>>(_configuration["Chucknorris:BaseAddress"], _configuration["Chucknorris:CategoryAddress"]);
        }

        public async Task<List<string>> Search(string query)
        {
            return await _sharedService.GetAsync<List<string>>(_configuration["Chucknorris:BaseAddress"], $"{_configuration["Chucknorris:SearchAddress"]}?query={query}");
        }
    }
}
