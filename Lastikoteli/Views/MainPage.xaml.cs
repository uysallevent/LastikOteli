using System;
using System.Collections.Generic;
using Lastikoteli.ViewModels;
using Rg.Plugins.Popup.Services;
using Xamarin.Forms;

namespace Lastikoteli.Views
{
    public partial class MainPage : ContentPage
    {
        MainViewModel mainViewModel;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = mainViewModel = new MainViewModel(this.Navigation);
        }

        protected override bool OnBackButtonPressed()
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                var result = await DisplayAlert("Uyarı", "Giriş ekranına dönmek istediğinize eminmisiniz ?", "Evet", "Hayır");
                if (result)
                    App.Current.MainPage = new LoginPage();
            });
            return true;
        }

    }
}
