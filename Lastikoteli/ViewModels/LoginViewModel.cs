using System;
using System.Threading.Tasks;
using Lastikoteli.Helper;
using Lastikoteli.Views;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private INavigation _navigation;
        private DoubleClickControl _doubleClickControl;
        public Command gotoMainPageCommand { get; set; }

        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _doubleClickControl = new DoubleClickControl(_navigation);
            gotoMainPageCommand = new Command(async () => await GotoMainPage());
        }


        private async Task GotoMainPage()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await _doubleClickControl.PushModalAsync(new NavigationPage(new MainPage()));
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
