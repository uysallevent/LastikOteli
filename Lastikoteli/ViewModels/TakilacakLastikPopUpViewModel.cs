using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Lastikoteli.Helper;
using Rg.Plugins.Popup.Services;
using Rg.Plugins.Popup.Contracts;

namespace Lastikoteli.ViewModels
{
    public class TakilacakLastikPopUpViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private IPopupNavigation _popupNavigation;
        public TakilacakLastikPopUpPage Page { get; set; }

        private TakmaResponse _takilacakLastik;

        public TakmaResponse TakilacakLastik
        {
            get { return _takilacakLastik; }
            set
            {
                //_takilacakLastik = value;
                //if (value != null && _takilacakLastik.bytSec == true)
                //    _takilacakLastik.bytSec = false;
                //else
                //    _takilacakLastik.bytSec = true;

                _takilacakLastik = null;

                OnPropertyChanged("TakilacakLastik");

            }
        }

        private ObservableCollection<TakmaResponse> _takilacakLastikListe;

        public ObservableCollection<TakmaResponse> TakilacakLastikListe
        {
            get { return _takilacakLastikListe; }
            set
            {
                _takilacakLastikListe = value;
                OnPropertyChanged("TakilacakLastikListe");
            }
        }

        public ICommand LastikleriTakCommand { get; set; }

        public TakilacakLastikPopUpViewModel(INavigation navigation, ObservableCollection<TakmaResponse> takilacakListe)
        {
            _navigation = navigation;
            TakilacakLastikListe = takilacakListe;
            LastikleriTakCommand = new Command(async () => await LastikleriTakAsync());
            _doubleClickControl = new DoubleClickControl(_navigation);
        }

        private async Task LastikleriTakAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                if (TakilacakLastikListe != null && TakilacakLastikListe.Count > 0)
                {
                    var result = await SaklamaService.LastikTeslimEt(new LastikTeslimRequest
                    {
                        lngDistKod = App.sessionInfo.lngDistkod,
                        lngSaklamaBaslik = TakilacakLastikListe.FirstOrDefault().lngSaklamaKod,
                        txtKullaniciAdSoyad = $"El Terminal Kullanıcısı {App.sessionInfo.txtAdSoyad}",
                        txtAciklama = $"El terminali üzerinden teslimi gerçekleştirildi"
                    });

                    if (result.StatusCode != 500 && result.Result)
                    {
                        await App.Current.MainPage.DisplayAlert("Uyarı", $"{TakilacakLastikListe.FirstOrDefault().lngSaklamaKod} saklama kodlu lastikler için teslim etme işlemi başarılı", "Tamam");
                    }
                    else
                        await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");

                    await PopupNavigation.PopAsync(true);
                    MessagingCenter.Send(this, "popAsync");

                }
                else
                    await Page.DisplayAlert("Uyarı", "Devam edebilmek için lütfen takılacak lastik/lastikleri seçin", "Tamam");
            }
            catch (Exception)
            {
                await this.Page.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
