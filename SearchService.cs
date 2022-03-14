using SovTech.Common.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SovTech.Core.Services
{
    public class SearchService : ISearchService
    {
        private readonly IChuckService _chuckService;
        private readonly ISwapiService _swapiService;

        public SearchService(IChuckService chuckService,
            ISwapiService swapiService)
        {
            _chuckService = chuckService;
            _swapiService = swapiService;
        }

        public async Task<List<string>> Search(string query)
        {
            var result = new List<string>();
            var categories = await _chuckService.Search(query);
            result.AddRange(categories);
            var people = await _swapiService.Search(query);
            result.AddRange(people);

            return result;
        }

       
    }
}
