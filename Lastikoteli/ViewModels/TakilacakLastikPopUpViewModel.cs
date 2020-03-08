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

        [Obsolete]
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
                        txtAciklama = $"El terminali üzerinden teslimi gerçekleştirildi",
                        lngIsEmriKod = TakilacakLastikListe.FirstOrDefault().lngIsEmriKod,
                        bytDurum = 2, //Takılma operasyonunun tamamlanması durumunda BytSokmeTakma 2 ye set edilir
                        lngTip = 1    // 
                    });

                    if (result.StatusCode != 500 && result.Result)
                    {
                        var durumDegistir = await IsEmriService.IsEmriDurumuTamamla(new IsEmriDurumGuncelleRequest
                        {
                            bytDurum = 2,
                            lngDistKod = App.sessionInfo.lngDistkod,
                            lngTip = 1,
                            lngKod = TakilacakLastikListe.FirstOrDefault().lngIsEmriKod
                        });
                        await App.Current.MainPage.DisplayAlert("Uyarı", $"{TakilacakLastikListe.FirstOrDefault().lngSaklamaKod} saklama kodlu lastikler için teslim etme işlemi başarılı", "Tamam");
                    }
                    else
                        throw new Exception(result.ErrorMessage);

                    await PopupNavigation.PopAsync(true);
                    MessagingCenter.Send(this, "popAsync");

                }
                else
                    throw new Exception("Devam edebilmek için lütfen takılacak lastik/lastikleri seçin");
            }
            catch (Exception ex)
            {
                await this.Page.DisplayAlert("Uyarı", ex.Message, "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
