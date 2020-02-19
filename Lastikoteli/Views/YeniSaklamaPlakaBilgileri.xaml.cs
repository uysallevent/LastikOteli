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
        }

        public async void OpenPopup()
        {
            PopupNavigation.PushAsync(new MusteriAraPopUpPage());
        }

        private void CustomButton_Clicked(object sender, EventArgs e)
        {
            var masterPage = this.Parent as TabbedPage;
            masterPage.CurrentPage = masterPage.Children[1];
        }
    }
}