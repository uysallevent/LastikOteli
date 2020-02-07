using System;
using System.Collections.Generic;
using Lastikoteli.ViewModels;
using Xamarin.Forms;

namespace Lastikoteli.Views
{
    public partial class IsListesiAraPage : ContentPage
    {
        IsListesiAraViewModel isListesiAraViewModel;
        public IsListesiAraPage()
        {

            InitializeComponent();
            BindingContext = isListesiAraViewModel = new IsListesiAraViewModel(this.Navigation);
        }
    }
}
