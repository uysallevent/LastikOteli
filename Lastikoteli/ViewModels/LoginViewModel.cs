using Lastikoteli.Helper;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Views;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;

namespace Lastikoteli.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginPage Page { get; set; }

        private DoubleClickControl _doubleClickControl;

        private bool _isCheckStatus;

        public bool isCheckStatus
        {
            get { return _isCheckStatus; }
            set
            {
                SetProperty(ref _isCheckStatus, value);
                if (value != null)
                    Preferences.Set("rememberMe", value);
            }
        }

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
            loginRequest = new LoginRequest();
            var isCheckResult = Preferences.Get("rememberMe", false);
            if (isCheckResult)
            {
                isCheckStatus = true;
                loginRequest.kullaniciAd = Preferences.Get("userName", "");
            }

            _doubleClickControl = new DoubleClickControl(_navigation);
            gotoMainPageCommand = new Command(async () => await GotoMainPage());
        }

        private async Task GotoMainPage()
        {
            if (string.IsNullOrEmpty(loginRequest.kullaniciAd) || string.IsNullOrEmpty(loginRequest.sifre))
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", "Kullanıcı adı ve şifre alanlarını doldurunuz", "Tamam");
                return;
            }
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                var result = await AuthService.Login(loginRequest);
                if (result.StatusCode != 500)
                {
                    App.sessionInfo = result.Result;
                    if (isCheckStatus)
                        Preferences.Set("userName", loginRequest.kullaniciAd);
                    else
                        Preferences.Remove("userName");
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
