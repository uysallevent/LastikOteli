using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Lastikoteli.Helper
{
    public static class ConnectivityControlHelper
    {
        public async static Task<bool> ConnectionCheck()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", "Internet bağlantınızı kontrol ediniz", "Tamam");
                return false;
            }

            var current = Plugin.Connectivity.CrossConnectivity.Current;
            if (current.IsConnected)
            {
                var IsServiceOn = await current.IsRemoteReachable("http://52.233.133.105", 8087);
                if (!IsServiceOn)
                {
                    await App.Current.MainPage.DisplayAlert("Uyarı", "Servise erişilemiyor", "Tamam");
                    return false;
                }
            }

            return true;
        }
    }
}
