using Lastikoteli.Helper;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Lastikoteli.Services.Concrete
{
    public class ServiceManager
    {

        private static readonly string rootUrl = "http://104.45.22.252";
        private static readonly int port = 8089;
        //private static readonly string rootUrl = "http://52.233.133.106";//Test
        //private static readonly int port = 8087;//Test
        public readonly string apiUrl = $"{rootUrl}:{port}";

        protected HttpClient Client;
        protected static object lockObj = new object();

        public async Task<HttpClient> GetClient()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
                throw new Exception("İnternet bağlantınızı kontrol edin");

            var current = Plugin.Connectivity.CrossConnectivity.Current;
            if (current.IsConnected)
            {
                var IsServiceOn = await current.IsRemoteReachable(rootUrl, port);
                if (!IsServiceOn)
                    throw new Exception("Servise erişilemiyor");
            }

            lock (lockObj)
            {

                if (Client == null)
                {

                    Client = new HttpClient();
                    if (App.sessionInfo != null && !string.IsNullOrEmpty(App.sessionInfo.txtAccessToken))
                        Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + App.sessionInfo.txtAccessToken);
                    Client.DefaultRequestHeaders.Add("accept", "Applciation/json");
                }
            }

            return await Task.FromResult(Client);

        }
    }
}
