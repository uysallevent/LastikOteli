using Lastikoteli.ViewModels;
using Rg.Plugins.Popup.Contracts;
using Rg.Plugins.Popup.Pages;
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
    public partial class MusteriAraPopUpPage : PopupPage
    {
        MusteriAraPopUpViewModel musteriAraPopUpViewModel;
        public MusteriAraPopUpPage()
        {
            InitializeComponent();
            BindingContext = musteriAraPopUpViewModel = new MusteriAraPopUpViewModel();
            (BindingContext as MusteriAraPopUpViewModel).Page =this;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
        }
    }
}