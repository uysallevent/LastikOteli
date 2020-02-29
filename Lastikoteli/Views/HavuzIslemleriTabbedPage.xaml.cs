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
    public partial class HavuzIslemleriTabbedPage : Xamarin.Forms.TabbedPage
    {
        public HavuzIslemleriTabbedPage()
        {
            InitializeComponent();
            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
            BarTextColor = Color.Black;
            BarBackgroundColor = Color.FromHex("#FFF");
        }
    }
}