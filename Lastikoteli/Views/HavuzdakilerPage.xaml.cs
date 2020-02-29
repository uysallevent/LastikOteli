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
    public partial class HavuzdakilerPage : ContentPage
    {
        HavuzdakilerViewModel havuzdakilerViewModel;
        public HavuzdakilerPage()
        {
            InitializeComponent();
            BindingContext = havuzdakilerViewModel = new HavuzdakilerViewModel();
            (BindingContext as HavuzdakilerViewModel).Page = this;
        }
    }
}