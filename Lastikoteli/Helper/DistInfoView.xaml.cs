using System;
using System.Collections.Generic;
using Lastikoteli.ViewModels;
using Xamarin.Forms;

namespace Lastikoteli.Helper
{
    public partial class DistInfoView : ContentView
    {
        DistInfoViewModel distInfoViewModel;
        public DistInfoView()
        {
            InitializeComponent();
            BindingContext = distInfoViewModel = new DistInfoViewModel(this.Navigation);
        }
    }
}
