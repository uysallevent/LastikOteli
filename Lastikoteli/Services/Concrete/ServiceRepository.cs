using Lastikoteli.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lastikoteli.Services.Concrete
{
    public class ServiceRepository<T, TClient> : IDataStore<T>
                where T : class, new()
                where TClient : HttpClient, new()
    {

        public Task<T> AddItem(T model)
        {
            throw new NotImplementedException();
        }


        public Task<bool> DeleteItem(T model)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetItem(T model)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<ApiResponse>> GetList(T model)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateItem(T model)
        {
            throw new NotImplementedException();
        }
    }
}
