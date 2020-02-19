using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lastikoteli.Models;
using Lastikoteli.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Lastikoteli.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YeniSaklamaTabbedPage : Xamarin.Forms.TabbedPage
    {

        YeniSaklamaViewModel yeniSaklamaViewModel;
        public YeniSaklamaTabbedPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            BarTextColor = Color.Black;
            BarBackgroundColor = Color.FromHex("#FFF");
            BindingContext = yeniSaklamaViewModel = new YeniSaklamaViewModel(this.Navigation);
        }
    }
}
