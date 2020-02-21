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

        private void CustomButton_Clicked(object sender, EventArgs e)
        {
            PopupNavigation.PushAsync(new SearchPrinterPopupPage());

        }
    }
}
