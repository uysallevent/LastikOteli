using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
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
        public YeniSaklamaPlakaBilgileri PagePlakaBilgi { get; set; }
        public YeniSaklamaMarkaBilgi PageMarkaBilgi { get; set; }

        private MarkaBilgiRequest _markaBilgiRequest { get; set; }

        public MarkaBilgiRequest markaBilgiReuqest
        {
            get
            {
                return _markaBilgiRequest;
            }
            set
            {
                _markaBilgiRequest = value;
                OnPropertyChanged("markaBilgiReuqest");

            }
        }

        private INavigation _navigation;
        public ICommand GotoMusteriPopUpCommand { get; set; }
        public ICommand MarkaBilgiGetirCommand { get; set; }
        public YeniSaklamaViewModel(INavigation navigation)
        {
            _navigation = navigation;
            GotoMusteriPopUpCommand = new Command(async () => await GotoMusteriPopUpAsync());
            MarkaBilgiGetirCommand = new Command(async () => await MarkaBilgiGetirAsync());
            markaBilgiReuqest = new MarkaBilgiRequest();
            MessagingCenter.Subscribe<MusteriAraPopUpViewModel, MusteriBilgileriResponse>(this, "yeniSaklamaSecilenMusteri", (s, e) =>
            {

            });
        }

        private async Task MarkaBilgiGetirAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var result = ParametreService.MarkaBilgiGetir(markaBilgiReuqest);
            }
            catch (Exception ex)
            {

            }
        }

        private async Task GotoMusteriPopUpAsync()
        {
            PagePlakaBilgi.OpenPopup();
        }

    }
}
