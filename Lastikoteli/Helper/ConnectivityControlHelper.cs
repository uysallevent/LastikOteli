using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Lastikoteli.Helper
{
    public static class ConnectivityControlHelper
    {
        public async static Task<bool> ConnectionCheck(string rootUrl, int port)
        {
            try
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

                return true;
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", ex.Message, "Tamam");
                return false;
            }
        }
    }
}
