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
    public class LastikEtiketYazdirViewModel : BaseViewModel
    {

        private IList<LastikEtikEtiResponse> _lastikDesenListe;
        public IList<LastikEtikEtiResponse> lastikDesenListe
        {
            get { return _lastikDesenListe; }
            set { SetProperty(ref _lastikDesenListe, value); }
        }


        private LastikEtikEtiResponse _secilmisSaklama;
        public LastikEtikEtiResponse secilmisSaklama
        {
            get { return _secilmisSaklama; }
            set
            {
                SetProperty(ref _secilmisSaklama, value);
                _secilmisSaklama = null;

            }
        }

        private int _saklamaKodu;

        public int saklamaKodu
        {
            get { return _saklamaKodu; }
            set { SetProperty(ref _saklamaKodu, value); }
        }


        public ICommand lastikEtiketBilgiAraCommand { get; set; }
        public ICommand lastikEtiketBilgiYazdirCommand { get; set; }

        public LastikEtiketYazdirViewModel()
        {
            lastikEtiketBilgiAraCommand = new Command(async () => await LastikEtiketBilgiAraAsync());
            lastikEtiketBilgiYazdirCommand = new Command(async () => await lastikEtiketBilgiYazdirAsync());
        }

        private async Task lastikEtiketBilgiYazdirAsync()
        {

            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                if(lastikDesenListe.Count==null&& lastikDesenListe.Count==0)
                {
                    await App.Current.MainPage.DisplayAlert("Uyarı", "Lastik etiket bilgisi bulunamadı", "Tamam");
                    return;
                }

                var result = await ParametreService.DesenBilgileriGetir(new DesenRequest
                {
                    lngDistKod = App.sessionInfo.lngDistkod,
                    lngSaklamaBaslik = saklamaKodu,
                });

                if (result.StatusCode != 500 && result.Result != null && result.Result.Count > 0)
                    PopupNavigation.PushAsync(new SearchPrinterPopupPage(new PrintRequest
                    {
                        lastikEtiketlerBilgi = result.Result.ToList(),
                        siraKolayKodEtiketBilgileri = null
                    }));
                else
                    await App.Current.MainPage.DisplayAlert("Uyarı", !string.IsNullOrEmpty(result.ErrorMessage) ? result.ErrorMessage : "Lastik etiket bilgisi bulunamadı", "Tamam");

            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task LastikEtiketBilgiAraAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var result = await ParametreService.DesenBilgileriGetir(new Models.Complex.Request.DesenRequest
                {
                    lngDistKod = App.sessionInfo.lngDistkod,
                    lngSaklamaBaslik = saklamaKodu
                });

                if (result.StatusCode != 500 && result.Result.Count > 0)
                    lastikDesenListe = new ObservableCollection<LastikEtikEtiResponse>(result.Result.Select(x => new LastikEtikEtiResponse { lngSaklamaKod = saklamaKodu, lngLastikAdet = result.Result.Count, lastikYonBilgisi = x.Key }).Distinct());
                else
                    await App.Current.MainPage.DisplayAlert("Uyarı", !string.IsNullOrEmpty(result.ErrorMessage) ? result.ErrorMessage : "Saklama etiket bilgisi bulunamadı", "Tamam");
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
