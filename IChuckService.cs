using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SovTech.Core.Services
{
    public interface IChuckService
    {
        Task<List<string>> GetAllCategories();
        Task<List<string>> Search(string query);
    }
}