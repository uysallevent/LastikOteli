using System;
using System.Collections.Generic;
using Lastikoteli.ViewModels;
using Xamarin.Forms;

namespace Lastikoteli.Views
{
    public partial class IsListesiPage : ContentPage
    {
        IsListesiViewModel isListesiViewModel;
        public IsListesiPage()
        {
            InitializeComponent();
            BindingContext = isListesiViewModel = new IsListesiViewModel(this.Navigation);
        }
    }
}
