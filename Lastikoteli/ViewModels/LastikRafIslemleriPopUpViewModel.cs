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
    public class LastikRafIslemleriPopUpViewModel : BaseViewModel
    {

        private SaklamaBilgileriResponse _saklamaBilgileri;
        public SaklamaBilgileriResponse saklamaBilgileri
        {
            get { return _saklamaBilgileri; }
            set
            {
                SetProperty(ref _saklamaBilgileri, value);
            }
        }


        private ObservableCollection<DetayListeResponse> _lastikListe;
        public ObservableCollection<DetayListeResponse> lastikListe
        {
            get { return _lastikListe; }
            set { SetProperty(ref _lastikListe, value); }
        }


        private DetayListeResponse _detayListeResponse;
        public DetayListeResponse detayListeResponse
        {
            get { return _detayListeResponse; }
            set
            {
                SetProperty(ref _detayListeResponse, value);
                RafSecCommand.Execute(true);

            }
        }


        public ICommand RafSecCommand { get; set; }
        public ICommand RafKolayKodKontrolCommand { get; set; }
        public ICommand RafGuncelleCommand { get; set; }

        public LastikRafIslemleriPopUpViewModel(SaklamaBilgileriResponse saklamaBilgileriResponse)
        {
            saklamaBilgileri = saklamaBilgileriResponse;
            lastikListe = new ObservableCollection<DetayListeResponse>(saklamaBilgileriResponse.Tblsaklamadetay);
            RafSecCommand = new Command(async () => await RafSecAsync());
            RafKolayKodKontrolCommand = new Command(async (x) => await RafKolayKodKontrolAsync(x));
            RafGuncelleCommand = new Command(async () => await RafGuncelleAsync());

            MessagingCenter.Subscribe<DepoSecimPopUpViewModel, DepoDizilimResponse>(this, "selectedRaf", (s, e) =>
            {
                var secilenLastik = detayListeResponse;
                lastikListe.ToList().ForEach(x =>
                {
                    if (x.lngKod == secilenLastik.lngKod)
                    {
                        x.lngDepoSiraKod = e.lngKod;
                        x.txtRafKolayKod = e.txtAd;
                    }
                });
                lastikListe = new ObservableCollection<DetayListeResponse>(lastikListe);
            });

        }

        private async Task RafGuncelleAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var result = await SaklamaService.ElTerminaliLastikRafGuncelle(new LastikRafGuncelleRequest
                {
                    lngDistKod = App.sessionInfo.lngDistkod,
                    lngSaklamaKodu = saklamaBilgileri.lngKod,
                    detayKodRafKodList = lastikListe.Select(x => new KeyValuePair<int, int>(x.lngKod, x.lngDepoSiraKod ?? 0)).ToList()
                });

                if (result.StatusCode != 500 && result.Result)
                {
                    await App.Current.MainPage.DisplayAlert("Uyarı", "Raf güncelleme başarılı", "Tamam");
                    MessagingCenter.Send(this, "guncellenenRafSaklama", saklamaBilgileri.lngKod);
                    await PopupNavigation.PopAsync(true);
                }
                else
                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task RafSecAsync()
        {
            await PopupNavigation.PushAsync(new DepoSecimPopUpPage());

        }

        private async Task RafKolayKodKontrolAsync(object x)
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                var result = await DepoService.KolayKodKontrol(new RafKolayKodKontrolRequest
                {
                    lngDistKod = App.sessionInfo.lngDistkod,
                    txtRafKolayKod = x.ToString()
                });

                if (result.StatusCode != 500)
                {
                    saklamaBilgileri.Tblsaklamadetay.ForEach(y =>
                    {
                        y.lngDepoSiraKod = result.Result;
                    });

                }
                else
                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");

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
