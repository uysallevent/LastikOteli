using System;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Lastikoteli.Services.Concrete
{
    public class ServiceManager
    {

        public readonly string APIUrl = "http://52.233.133.106:8087";
        //public readonly string APIUrl = "http://192.168.1.105:45455";
        //public readonly string APIUrl = "http://192.168.0.23:45455";
        protected HttpClient Client;
        protected static object lockObj = new object();

        public async Task<HttpClient> GetClient()
        {
            //if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            //    await App.Current.MainPage.DisplayAlert("Uyarı", "Internet bağlantınızı kontrol ediniz", "Tamam");

            //var current = Plugin.Connectivity.CrossConnectivity.Current;
            //if (current.IsConnected)
            //{
            //    var IsServiceOn = await current.IsRemoteReachable("http://52.233.133.105", 8087);
            //    if (!IsServiceOn)
            //    {
            //        await App.Current.MainPage.DisplayAlert("Uyarı", "Servise erişilemiyor", "Tamam");
            //    }
            //}

            lock (lockObj)
            {

                if (Client == null)
                {

                    Client = new HttpClient();
                    Client.Timeout = TimeSpan.FromSeconds(20);
                    Client.DefaultRequestHeaders.Add("accept", "Applciation/json");
                }
            }

            return await Task.FromResult(Client);
        }
    }
}
