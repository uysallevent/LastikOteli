using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class YeniSaklamaViewModel : BaseViewModel
    {
        private INavigation _navigation;
        public YeniSaklamaTabbedPage Page { get; set; }
        public YeniSaklamaPlakaBilgiViewModel yeniSaklamaPlakaBilgiViewModel { get; set; }
        public YeniSaklamaMarkaBilgileriViewModel yeniSaklamaMarkaBilgileriViewModel { get; set; }


        public ICommand saklamayaAlCommand { get; set; }





        public YeniSaklamaViewModel(INavigation navigation)
        {
            _navigation = navigation;
            saklamayaAlCommand = new Command(async () => await saklamayaAlAsync());
            yeniSaklamaPlakaBilgiViewModel = new YeniSaklamaPlakaBilgiViewModel(_navigation);
            yeniSaklamaMarkaBilgileriViewModel = new YeniSaklamaMarkaBilgileriViewModel(_navigation);
        }



        private async Task saklamayaAlAsync()
        {
            var baslik = yeniSaklamaPlakaBilgiViewModel.saklamaBaslikRequest;
            var detay = yeniSaklamaMarkaBilgileriViewModel.detayListe;
            var kUrun = yeniSaklamaMarkaBilgileriViewModel.kullaniciUrunBilgileri;
        }
    }
}
