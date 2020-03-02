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
    public partial class DepoIslemleriPage : ContentPage
    {
        DepoIslemleriViewModel depoIslemleriViewModel;
        public DepoIslemleriPage()
        {
            InitializeComponent();
            BindingContext = depoIslemleriViewModel = new DepoIslemleriViewModel(this.Navigation);

        }
    }
}