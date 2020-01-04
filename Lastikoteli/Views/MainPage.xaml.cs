using System;
using System.Collections.Generic;
using Lastikoteli.ViewModels;
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
    }
}
