using System;
using System.Security.Policy;
using System.Threading.Tasks;
using RestClient.Net;
using Urls;

namespace TaskLinerClientApp.Stores
{
    public class ClientHub : IClientHub
    {
        private readonly IClient _client;

        public ClientHub(IClient client)
        {
            _client = client;
        }


        public async Task<T> GetResourceAsync<T>(string url)
        {
            var resource = await _client.GetAsync<T>(url);

            return resource;
        }

        public async Task<T> PostAsync<T>(string url, T resource)
        {
            var result = await _client.PostAsync<T, T>(resource, url);

            return result;
        }
    }
}
