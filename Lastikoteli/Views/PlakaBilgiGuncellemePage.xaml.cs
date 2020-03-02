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
    public partial class PlakaBilgiGuncellemePage : ContentPage
    {
        public PlakaBilgiGuncellemePage()
        {
            InitializeComponent();
        }

        private void CustomButton_Clicked(object sender, EventArgs e)
        {
            var masterPage = this.Parent as TabbedPage;
            masterPage.CurrentPage = masterPage.Children[1];
        }
    }
}