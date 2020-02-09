using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Lastikoteli.Models.MiyaPortal;
using Lastikoteli.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.DataGrid;
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
            (this.BindingContext as IsListesiViewModel).Page = this;
        }

        public void IsEmriList(ObservableCollection<Randevu> isEmriList)
        {
            isListesiViewModel._isListesi = isEmriList;
            LstIsList.ItemsSource = isListesiViewModel._isListesi;
        }

        private void BtnTakilacak_Clicked(object sender, EventArgs e)
        {
            LstIsList.ItemsSource = isListesiViewModel._isListesi.Where(x => x.TXTSOKMETAKMA == "T" || x.TXTSOKMETAKMA == "S/T").ToList();
        }

        private void BtnHepsi_Clicked(object sender, EventArgs e)
        {
            LstIsList.ItemsSource = isListesiViewModel._isListesi.ToList();

        }

        private void BtnSaklama_Clicked(object sender, EventArgs e)
        {
            LstIsList.ItemsSource = isListesiViewModel._isListesi.Where(x => x.TXTSOKMETAKMA == "S" || x.TXTSOKMETAKMA == "S/T").ToList();

        }
    }
}
