using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Lastikoteli.Services;
using Lastikoteli.Views;
using Lastikoteli.Models;
using Lastikoteli.Services.Concrete;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Helper.Abstract;
using Lastikoteli.Helper;
using Lastikoteli.Models.Validator.FluentValidation;

namespace Lastikoteli
{
    public partial class App : Application
    {
        public static  string Version;

        public App()
        {
            InitializeComponent();
            DependencyService.Register<AuthService>();
            DependencyService.Register<IsEmriService>();
            DependencyService.Register<SaklamaService>();
            DependencyService.Register<ParametreService>();
            DependencyService.Register<DepoService>();
            DependencyService.Register<EtiketYazdir>();
            DependencyService.Register<SaklamaBaslikRequestValidator>();
            DependencyService.Register<SeciliMarkaBilgiIslemleri>();
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
