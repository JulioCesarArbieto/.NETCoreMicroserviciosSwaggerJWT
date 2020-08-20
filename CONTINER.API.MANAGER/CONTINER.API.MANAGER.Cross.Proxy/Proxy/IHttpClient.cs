using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CONTINER.API.MANAGER.Cross.Proxy.Proxy
{
    public interface IHttpClient
    {
        Task<string> GetStringAsync(string uri);

        Task<HttpResponseMessage> PostAsync<T>(string uri, T item);

        Task<string> GetStringAsync(string uri, string token);

        Task<HttpResponseMessage> PostAsync<T>(string uri, T item, string token);
    }
}
