using Lastikoteli.ViewModels;
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
    public partial class DepoSecimPopUpPage : PopupPage
    {
        DepoSecimPopUpViewModel depoSecimPopUpViewModel;
        public DepoSecimPopUpPage()
        {
            InitializeComponent();
            BindingContext = depoSecimPopUpViewModel = new DepoSecimPopUpViewModel();
            (BindingContext as DepoSecimPopUpViewModel).Page = this;
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            await PopupNavigation.PopAsync(true);
        }

    }
}