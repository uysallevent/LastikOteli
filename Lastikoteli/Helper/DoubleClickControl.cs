using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Lastikoteli.Helper
{
    public class DoubleClickControl
    {
        private static bool Clickable = true;
        private INavigation _navigation;

        public DoubleClickControl(INavigation navigation)
        {
            _navigation = navigation;
        }

        public async Task PushModalAsync(Page sayfa)
        {
            if (Clickable)
            {
                Clickable = false;
                await _navigation.PushModalAsync(sayfa);
                await Task.Run(async () =>
                {
                    await Task.Delay(500);
                    Clickable = true;
                });
            }
        }

        public async Task PushAsync(Page sayfa)
        {
            if (Clickable)
            {
                Clickable = false;
                await _navigation.PushAsync(sayfa);
                await Task.Run(async () =>
                {
                    await Task.Delay(500);
                    Clickable = true;
                });
            }
        }

        public async Task PushAsync(PopupPage sayfa)
        {
            if (Clickable)
            {
                Clickable = false;
                await PopupNavigation.PushAsync(sayfa);
                await Task.Run(async () =>
                {
                    await Task.Delay(500);
                    Clickable = true;
                });
            }
        }
    }
}
