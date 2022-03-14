using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SovTech.Common.Services
{
    public interface ISearchService
    {
        Task<List<string>> Search(string query);
    }
}
