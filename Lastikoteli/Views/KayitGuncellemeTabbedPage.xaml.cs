using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Lastikoteli.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class KayitGuncellemeTabbedPage : Xamarin.Forms.TabbedPage
    {
        KayitGuncellemeTabbedViewModel kayitGuncellemeTabbedViewModel;
        public KayitGuncellemeTabbedPage(KayitGuncelleRequest request)
        {
            InitializeComponent();

            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            BarTextColor = Color.Black;
            BarBackgroundColor = Color.FromHex("#FFF");
            BindingContext = kayitGuncellemeTabbedViewModel = new KayitGuncellemeTabbedViewModel(this.Navigation, request);
        }
    }
}