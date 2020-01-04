using System;
using System.Threading.Tasks;
using Lastikoteli.Helper;
using Lastikoteli.Views;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class IsListesiAraViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private DoubleClickControl _doubleClickControl;

        public Command gotoIsListesiCommand { get; set; }
        public Command gotoYeniSaklamaCommand { get; set; }
        public Command gotoYeniTakmaCommand { get; set; }

        public IsListesiAraViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _doubleClickControl = new DoubleClickControl(_navigation);
            gotoIsListesiCommand = new Command(async () => await gotoIsListesiPage());
            gotoYeniSaklamaCommand = new Command(async () => await gotoYeniSaklamaPage());

        }

        private async Task gotoIsListesiPage()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                await _doubleClickControl.PushAsync(new IsListesiTabbedPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", $"Bir hata oluştu {ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task gotoYeniSaklamaPage()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                await _doubleClickControl.PushAsync(new YeniSaklamaTabbedPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", $"Bir hata oluştu {ex.Message}", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
