using System;
using System.Threading.Tasks;
using Lastikoteli.Helper;
using Lastikoteli.Views;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private DoubleClickControl _doubleClickControl;
        public Command gotoIsListesiPageCommand { get; set; }


        public MainViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _doubleClickControl = new DoubleClickControl(_navigation);
            gotoIsListesiPageCommand = new Command(async () => await GotoIsListesiPage());

        }

        private async Task GotoIsListesiPage()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await _doubleClickControl.PushAsync(new IsListesiAraPage());
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
