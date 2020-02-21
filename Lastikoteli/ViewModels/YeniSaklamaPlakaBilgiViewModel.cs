using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class YeniSaklamaPlakaBilgiViewModel : BaseViewModel
    {
        private INavigation _navigation;
        public YeniSaklamaPlakaBilgileri Page { get; set; }


        private SaklamaBaslikRequest _saklamaBaslikRequest;
        public SaklamaBaslikRequest saklamaBaslikRequest
        {
            get { return _saklamaBaslikRequest; }
            set
            {
                SetProperty<SaklamaBaslikRequest>(ref _saklamaBaslikRequest, value);
            }
        }


        public ICommand GotoMusteriPopUpCommand { get; set; }


        public YeniSaklamaPlakaBilgiViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Initializer();
            MessagingCenter.Subscribe<MusteriAraPopUpViewModel, MusteriBilgileriResponse>(this, "yeniSaklamaSecilenMusteri", (s, e) =>
            {
                saklamaBaslikRequest.TXTMUSTERIUNVAN = e.TXTUNVAN;
                saklamaBaslikRequest.LNGMUSTERIKOD = e.LNGKOD;
                OnPropertyChanged("saklamaBaslikRequest");
            });
        }




        private async Task GotoMusteriPopUpAsync()
        {
            Page.OpenPopup();
        }


        public void Initializer()
        {
            saklamaBaslikRequest = new SaklamaBaslikRequest();
            GotoMusteriPopUpCommand = new Command(async () => await GotoMusteriPopUpAsync());
        }
    }
}
