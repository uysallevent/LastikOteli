using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lastikoteli.Services.Concrete
{
    public class ServiceManager
    {

        public readonly string APIUrl = "http://52.233.133.106:8087";
        //public readonly string APIUrl = "http://192.168.1.78:45457";
        //public readonly string APIUrl = "http://192.168.0.23:45455";
        protected HttpClient Client;
        protected static object lockObj = new object();

        public async Task<HttpClient> GetClient()
        {
            lock (lockObj)
            {
                if (Client == null)
                {
                    Client = new HttpClient();
                    Client.Timeout = TimeSpan.FromMinutes(60);
                    Client.DefaultRequestHeaders.Add("accept", "Applciation/json");
                }
            }

            return await Task.FromResult(Client);
        }
    }
}
