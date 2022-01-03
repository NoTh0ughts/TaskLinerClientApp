using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskLinerClientApp.Stores
{
    public interface IClientHub
    {
        public Task<T> GetResourceAsync<T>(string url);

        public Task<T> PostAsync<T>(string url, T resource);
    }
}
