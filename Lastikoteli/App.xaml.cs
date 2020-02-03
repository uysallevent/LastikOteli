using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lastikoteli.Services;
using Lastikoteli.Views;
using Lastikoteli.Models;
using Lastikoteli.Services.Concrete;
using Lastikoteli.Models.Complex.Response;

namespace Lastikoteli
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            //DependencyService.Register<MockDataStore>();
            DependencyService.Register<AuthService>();

            MainPage = new LoginPage();
        }

        public static DistBilgi distBilgi { get; set; }
        public static TerminalGirisResponse loginInfo { get; set; }

        protected override void OnStart()
        {
            distBilgi = new DistBilgi
            {
                lngDistKod=29,
                txtDistAd="AYKO OTOM A.Ş"
            };
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
