using Newtonsoft.Json;
using SovTech.Common.Services;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SovTech.Core.Services
{
    public class SharedService : ISharedService
    {
        public async Task<TReturn> GetAsync<TReturn>(string baseUri, string requestUri)
        {
            try
            {
                //var payload = JsonConvert.SerializeObject(request);
                //var content = new StringContent(payload, Encoding.UTF8, "application/json");
                using (var handler = new HttpClientHandler())
                using (var client = new HttpClient(handler) { BaseAddress = new Uri(baseUri) })
                {
                    var response = await client.GetAsync(requestUri);
                    var result = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<TReturn>(result);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
