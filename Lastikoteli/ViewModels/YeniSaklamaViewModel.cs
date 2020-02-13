using Lastikoteli.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class YeniSaklamaViewModel : BaseViewModel
    {
        private INavigation _navigation;
        public YeniSaklamaPlakaBilgileri PagePlakaBilgi { get; set; }
        public YeniSaklamaMarkaBilgi PageMarkaBilgi { get; set; }

        public ICommand GotoMusteriPopUpCommand { get; set; }
        public YeniSaklamaViewModel(INavigation navigation)
        {
            _navigation = navigation;
            GotoMusteriPopUpCommand = new Command(async () => GotoMusteriPopUpAsync());
        }

        private async Task GotoMusteriPopUpAsync()
        {
            PagePlakaBilgi.OpenPopup();
        }
    }
}
