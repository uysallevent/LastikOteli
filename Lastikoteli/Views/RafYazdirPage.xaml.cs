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
    public partial class RafYazdirPage : ContentPage
    {
        RafYazdirViewModel rafYazdirViewModel;
        public RafYazdirPage()
        {
            InitializeComponent();
            BindingContext = rafYazdirViewModel = new RafYazdirViewModel();
            (BindingContext as RafYazdirViewModel).Page = this;
        }
    }
}