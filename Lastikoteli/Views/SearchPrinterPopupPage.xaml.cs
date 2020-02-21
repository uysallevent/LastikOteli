using Lastikoteli.ViewModels;
using Rg.Plugins.Popup.Pages;
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
    public partial class SearchPrinterPopupPage : PopupPage
    {
        SearchPrinterPopUpViewModel searchPrinterPopUpViewModel;
        public SearchPrinterPopupPage()
        {
            InitializeComponent();
            BindingContext = searchPrinterPopUpViewModel = new SearchPrinterPopUpViewModel();
            (BindingContext as SearchPrinterPopUpViewModel).Page = this;
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {

        }
    }
}