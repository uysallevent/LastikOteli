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
            DependencyService.Register<AuthService>();
            DependencyService.Register<IsEmriService>();
            DependencyService.Register<SaklamaService>();
            MainPage = new LoginPage();
            //MainPage = new YeniSaklamaTabbedPage();
        }

        public static SessionInfo sessionInfo { get; set; }

        protected override void OnStart()
        {

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
