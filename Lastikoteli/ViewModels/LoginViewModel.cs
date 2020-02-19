using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Lastikoteli.Helper;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {

        private INavigation _navigation;
        public LoginPage Page { get; set; }

        private DoubleClickControl _doubleClickControl;
        public Command gotoMainPageCommand { get; set; }

        private LoginRequest _loginRequest;
        public LoginRequest loginRequest
        {
            get { return _loginRequest; }
            set
            {
                _loginRequest = value;
                SetProperty<LoginRequest>(ref _loginRequest, value);
            }
        }
        public LoginViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _doubleClickControl = new DoubleClickControl(_navigation);
            gotoMainPageCommand = new Command(async () => await GotoMainPage());
            loginRequest = new LoginRequest();
        }

        private async Task GotoMainPage()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var result = await AuthService.Login(loginRequest);
                if (result.StatusCode != 500)
                {
                    App.sessionInfo = result.Result;
                    await _doubleClickControl.PushModalAsync(new NavigationPage(new MainPage()));
                }
                else
                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");

            }
            catch (Exception ex)
            {
                await this.Page.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
