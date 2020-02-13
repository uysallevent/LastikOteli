using Lastikoteli.ViewModels;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Lastikoteli.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YeniSaklamaPlakaBilgileri : ContentPage
    {
        YeniSaklamaViewModel yeniSaklamaViewModel;
        public YeniSaklamaPlakaBilgileri()
        {
            InitializeComponent();
            BindingContext = yeniSaklamaViewModel = new YeniSaklamaViewModel(this.Navigation);
            (BindingContext as YeniSaklamaViewModel).PagePlakaBilgi = this;
        }

        public async void OpenPopup()
        {
            PopupNavigation.PushAsync(new MusteriAraPopUpPage());
        }
    }
}