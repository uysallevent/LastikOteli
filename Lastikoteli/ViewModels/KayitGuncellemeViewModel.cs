using Lastikoteli.Helper;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using Rg.Plugins.Popup.Services;
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
    public class KayitGuncellemeViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private DoubleClickControl _doubleClickControl;
        public KayitGuncellemePage Page { get; set; }


        private SaklamaBilgiRequest _saklamaBilgiRequest;
        public SaklamaBilgiRequest saklamaBilgiRequest
        {
            get { return _saklamaBilgiRequest; }
            set { SetProperty(ref _saklamaBilgiRequest, value); }
        }



        private LastikSaklamaBilgiResponse _secilenSaklama;
        public LastikSaklamaBilgiResponse secilenSaklama
        {
            get { return _secilenSaklama; }
            set
            {
                SetProperty(ref _secilenSaklama, value);
                if (_secilenSaklama != null)
                {
                    var secilenKayit = saklamadakilerListesi.FirstOrDefault(x => x.lngKod == _secilenSaklama.lngSaklamaKodu);
                    Device.BeginInvokeOnMainThread(async()=>await _doubleClickControl.PushAsync(new KayitGuncellemeTabbedPage(new KayitGuncelleRequest { lngDistKod = App.sessionInfo.lngDistkod, lngSaklamaKod = secilenKayit.lngKod })));
                }
                _secilenSaklama = null;
                OnPropertyChanged("secilenSaklama");
            }
        }


        private IList<LastikSaklamaBilgiResponse> _saklamaListe;
        public IList<LastikSaklamaBilgiResponse> saklamaListe
        {
            get { return _saklamaListe; }
            set { SetProperty(ref _saklamaListe, value); }
        }


        private IList<SaklamaBilgileriResponse> _saklamadakilerListesi;
        public IList<SaklamaBilgileriResponse> saklamadakilerListesi
        {
            get { return _saklamadakilerListesi; }
            set { SetProperty(ref _saklamadakilerListesi, value); }
        }


        public ICommand saklamadaKayitAramaCommand { get; set; }

        public KayitGuncellemeViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _doubleClickControl = new DoubleClickControl(_navigation);
            saklamadaKayitAramaCommand = new Command(async () => await saklamadaKayitAramaAsync());
            saklamaBilgiRequest = new SaklamaBilgiRequest();

        }

        private async Task saklamadaKayitAramaAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                saklamaBilgiRequest.lngDistKod = App.sessionInfo.lngDistkod;
                var result = await SaklamaService.SaklamadaKayitArama(saklamaBilgiRequest);


                if (result.StatusCode != 500 && result.Result.Count > 0)
                {
                    saklamadakilerListesi = new ObservableCollection<SaklamaBilgileriResponse>(result.Result);
                    saklamaListe = new ObservableCollection<LastikSaklamaBilgiResponse>(saklamadakilerListesi.Select(x => new LastikSaklamaBilgiResponse { lngSaklamaKodu = x.lngKod, txtPlaka = x.txtPlaka, txtDurum = "Saklamada" }).ToList());
                }
                else
                {
                    saklamaListe = new ObservableCollection<LastikSaklamaBilgiResponse>();
                    await Page.DisplayAlert("Uyarı", (!string.IsNullOrEmpty(result.ErrorMessage)) ? result.ErrorMessage : "Kayıt bulunamadı", "Tamam");
                }

            }
            catch (Exception)
            {
                await Page.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
