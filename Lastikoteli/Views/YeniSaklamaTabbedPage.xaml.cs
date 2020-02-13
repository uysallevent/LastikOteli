using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lastikoteli.Models;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.AndroidSpecific;
using Xamarin.Forms.Xaml;

namespace Lastikoteli.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class YeniSaklamaTabbedPage : Xamarin.Forms.TabbedPage
    {
        public YeniSaklamaTabbedPage()
        {
            InitializeComponent();

            BarTextColor = Color.Black;
            BarBackgroundColor = Color.FromHex("#FFF");

            this.Children.Add(new YeniSaklamaPlakaBilgileri() { Title = "Plaka Bilgileri", IconImageSource = "icon_saklama.png" });
            this.Children.Add(new YeniSaklamaMarkaBilgi() { Title = "Lastik Bilgileri", IconImageSource = "icon_takma.png" });

            On<Xamarin.Forms.PlatformConfiguration.Android>().SetToolbarPlacement(ToolbarPlacement.Bottom);
        }
    }
}
