using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SovTech.Common.Services
{
    public interface ISharedService
    {
        Task<TReturn> GetAsync<TReturn>(string baseUri, string requestUri);
    }
}
