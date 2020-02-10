using Lastikoteli.Models.Complex.Response;
using Lastikoteli.ViewModels;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lastikoteli.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TakilacakLastikPopUpPage : PopupPage
    {
        TakilacakLastikPopUpViewModel _takilacakLastikPopUpViewModel;
        public TakilacakLastikPopUpPage(ObservableCollection<TakmaResponse> lastikListe)
        {
            InitializeComponent();
            BindingContext = _takilacakLastikPopUpViewModel = new TakilacakLastikPopUpViewModel(this.Navigation, lastikListe);
            //LstLastikBilgileri.ItemsSource = lastikListe;
            //(BindingContext as TakilacakLastikPopUpViewModel).TakilacakLastikListe = lastikListe;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
        }
    }
}