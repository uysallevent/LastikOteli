using Lastikoteli.ViewModels;
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
    public partial class KayitGuncellemePage : ContentPage
    {
        KayitGuncellemeViewModel kayitGuncellemeViewModel;
        public KayitGuncellemePage()
        {
            InitializeComponent();
            BindingContext = kayitGuncellemeViewModel = new KayitGuncellemeViewModel(this.Navigation);
            (BindingContext as KayitGuncellemeViewModel).Page = this;
        }
    }
}