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
    public class DepoIslemleriViewModel : BaseViewModel
    {

        private DoubleClickControl _doubleClickControl;

        private INavigation _navigation;

        public DepoIslemleriPage Page { get; set; }


        private SaklamaBilgiRequest _saklamaBilgiRequest;
        public SaklamaBilgiRequest saklamaBilgiRequest
        {
            get { return _saklamaBilgiRequest; }
            set { SetProperty(ref _saklamaBilgiRequest, value); }
        }


        private IList<SaklamaBilgileriResponse> _saklamadakilerListesi;
        public IList<SaklamaBilgileriResponse> saklamadakilerListesi
        {
            get { return _saklamadakilerListesi; }
            set { SetProperty(ref _saklamadakilerListesi, value); }
        }


        private IList<LastikSaklamaBilgiResponse> _saklamaListe;
        public IList<LastikSaklamaBilgiResponse> saklamaListe
        {
            get { return _saklamaListe; }
            set { SetProperty(ref _saklamaListe, value); }
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
                    PopupNavigation.PushAsync(new LastikRafIslemleriPopUpPage(secilenKayit));
                }
                _secilenSaklama = null;
                OnPropertyChanged("secilenSaklama");
            }
        }


        public ICommand saklamadaKayitAramaCommand { get; set; }
        public ICommand gotoRafEtiketiYazdirCommand { get; set; }
        public ICommand gotoLastikEtiketiYazdirCommand { get; set; }

        public DepoIslemleriViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _doubleClickControl = new DoubleClickControl(_navigation);
            saklamaBilgiRequest = new SaklamaBilgiRequest();
            saklamadaKayitAramaCommand = new Command(async () => await saklamadaKayitAramaAsync());
            gotoRafEtiketiYazdirCommand = new Command(async () => await gotoRafEtiketiYazdirAsync());
            gotoLastikEtiketiYazdirCommand = new Command(async () => await gotoLastikEtiketiYazdirAsync());
            MessagingCenter.Subscribe<LastikRafIslemleriPopUpViewModel, int>(this, "guncellenenRafSaklama", (s, e) =>
            {
                if (saklamaListe != null)
                    saklamaListe = new ObservableCollection<LastikSaklamaBilgiResponse>(saklamaListe.Where(x => x.lngSaklamaKodu != e).ToList());
            });
        }

        private async Task gotoLastikEtiketiYazdirAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await _doubleClickControl.PushAsync(new LastikEtiketYazdirPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", $"Bir hata oluştu {ex.Message}", "Tamam");

            }
            finally
            {
                IsBusy = false;
            }
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
                    await App.Current.MainPage.DisplayAlert("Uyarı", (!string.IsNullOrEmpty(result.ErrorMessage)) ? result.ErrorMessage : "Kayıt bulunamadı", "Tamam");
                }

            }
            catch (Exception)
            {

            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task gotoRafEtiketiYazdirAsync()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                await _doubleClickControl.PushAsync(new RafYazdirPage());
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", $"Bir hata oluştu {ex.Message}", "Tamam");

            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
