using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lastikoteli.Models.MiyaPortal;
using Lastikoteli.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

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

        public void IsEmriList(InfiniteScrollCollection<Randevu> isEmriList)
        {
            LstIsList.ItemsSource = isEmriList;
        }


    }
}
