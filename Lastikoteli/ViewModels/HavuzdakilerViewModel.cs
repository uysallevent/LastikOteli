using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Rg.Plugins.Popup.Services;

namespace Lastikoteli.ViewModels
{
    public class HavuzdakilerViewModel : BaseViewModel
    {
        public HavuzdakilerPage Page { get; set; }


        private SaklamaBilgiRequest _saklamaBilgiRequest;
        public SaklamaBilgiRequest saklamaBilgiRequest
        {
            get { return _saklamaBilgiRequest; }
            set { SetProperty(ref _saklamaBilgiRequest, value); }
        }


        private IList<SaklamaBilgileriResponse> _havuzdakilerListesi;
        public IList<SaklamaBilgileriResponse> havuzdakilerListesi
        {
            get { return _havuzdakilerListesi; }
            set { SetProperty(ref _havuzdakilerListesi, value); }
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
                    var secilenKayit = havuzdakilerListesi.FirstOrDefault(x => x.lngKod == _secilenSaklama.lngSaklamaKodu);
                    PopupNavigation.PushAsync(new LastikRafIslemleriPopUpPage(secilenKayit));
                }
                _secilenSaklama = null;
            }
        }


        public ICommand HavuzdaKayitAramaCommand { get; set; }
        public HavuzdakilerViewModel()
        {
            saklamaBilgiRequest = new SaklamaBilgiRequest();
            HavuzdaKayitAramaCommand = new Command(async () => await HavuzdaKayitAramaAsync());
            MessagingCenter.Subscribe<LastikRafIslemleriPopUpViewModel, int>(this, "guncellenenRafSaklama", (s, e) =>
            {
                saklamaListe = new ObservableCollection<LastikSaklamaBilgiResponse>(saklamaListe.Where(x => x.lngSaklamaKodu != e).ToList());
            });
        }

        private async Task HavuzdaKayitAramaAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;
                saklamaBilgiRequest.lngDistKod = App.sessionInfo.lngDistkod;
                var result = await SaklamaService.SaklamadaKayitArama(saklamaBilgiRequest);

                var havuzListe = HavuzdakiLastikler(result.Result);

                if (result.StatusCode != 500 && result.Result.Count > 0)
                {
                    havuzdakilerListesi = new ObservableCollection<SaklamaBilgileriResponse>(result.Result);
                    saklamaListe = new ObservableCollection<LastikSaklamaBilgiResponse>(havuzdakilerListesi.Select(x => new LastikSaklamaBilgiResponse { lngSaklamaKodu = x.lngKod, txtPlaka = x.txtPlaka, txtDurum = "Havuzda" }).ToList());
                }
                else
                    await Page.DisplayAlert("Uyarı", (!string.IsNullOrEmpty(result.ErrorMessage)) ? result.ErrorMessage : "Kayıt bulunamadı", "Tamam");

            }
            catch (Exception)
            {


            }
            finally
            {
                IsBusy = false;
            }

        }


        private List<SaklamaBilgileriResponse> HavuzdakiLastikler(List<SaklamaBilgileriResponse> list)
        {
            foreach (var item in list)
                item.Tblsaklamadetay.RemoveAll(x => x.bytHavuzda != 1);

            list.RemoveAll(x => x.Tblsaklamadetay.Count == 0);

            return list;
        }
    }
}
