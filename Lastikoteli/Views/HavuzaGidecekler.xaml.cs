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
    public partial class HavuzaGidecekler : ContentPage
    {
        HavuzaGideceklerViewModel havuzaGideceklerViewModel;
        public HavuzaGidecekler()
        {
            InitializeComponent();
            BindingContext = havuzaGideceklerViewModel = new HavuzaGideceklerViewModel();
            (BindingContext as HavuzaGideceklerViewModel).Page = this;
        }
    }
}