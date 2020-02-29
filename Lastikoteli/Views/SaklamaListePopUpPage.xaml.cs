using Lastikoteli.Models.Complex.Response;
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
    public partial class SaklamaListePopUpPage : PopupPage
    {
        SaklamaListePopUpViewModel saklamaListePopUpViewModel;
        public SaklamaListePopUpPage(IList<LastikSaklamaBilgiResponse> saklamaListe)
        {
            InitializeComponent();
            BindingContext = saklamaListePopUpViewModel = new SaklamaListePopUpViewModel(saklamaListe);
        }
    }
}