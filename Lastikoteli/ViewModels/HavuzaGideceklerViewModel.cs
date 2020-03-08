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
    public class HavuzaGideceklerViewModel : BaseViewModel
    {
        public HavuzaGidecekler Page { get; set; }


        private SaklamaBilgiRequest _saklamaBilgiRequest;
        public SaklamaBilgiRequest saklamaBilgiRequest
        {
            get { return _saklamaBilgiRequest; }
            set { SetProperty(ref _saklamaBilgiRequest, value); }
        }


        private IList<SaklamaBilgileriResponse> _raftakilerListesi;
        public IList<SaklamaBilgileriResponse> raftakilerListesi
        {
            get { return _raftakilerListesi; }
            set { SetProperty(ref _raftakilerListesi, value); }
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
                    var secilenKayit = raftakilerListesi.FirstOrDefault(x => x.lngKod == _secilenSaklama.lngSaklamaKodu);
                    PopupNavigation.PushAsync(new HavuzaGidecekSaklamaPopUpPage(secilenKayit));
                }
                _secilenSaklama = null;
                OnPropertyChanged("secilenSaklama");
            }
        }


        public ICommand HavuzdaKayitAramaCommand { get; set; }

        public HavuzaGideceklerViewModel()
        {
            saklamaBilgiRequest = new SaklamaBilgiRequest();
            HavuzdaKayitAramaCommand = new Command(async () => await HavuzdaKayitAramaAsync());
            MessagingCenter.Subscribe<HavuzaGidecekSaklamaPopUpViewModel>(this, "lastikHavuzaTasimaBasarili", (s) =>
            {
                saklamaListe = new ObservableCollection<LastikSaklamaBilgiResponse>();
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

                var havuzListe = RaftakiLastikler(result.Result);

                if (result.StatusCode != 500 && result.Result.Count > 0)
                {
                    raftakilerListesi = new ObservableCollection<SaklamaBilgileriResponse>(result.Result);
                    saklamaListe = new ObservableCollection<LastikSaklamaBilgiResponse>(raftakilerListesi.Select(x => new LastikSaklamaBilgiResponse { lngSaklamaKodu = x.lngKod, txtPlaka = x.txtPlaka, txtDurum = "Saklamada" }).ToList());
                }
                else
                    throw new Exception((!string.IsNullOrEmpty(result.ErrorMessage)) ? result.ErrorMessage : "Kayıt bulunamadı");

            }
            catch (Exception ex)
            {
                await Page.DisplayAlert("Uyarı", ex.Message, "Tamam");
            }
            finally
            {
                IsBusy = false;
            }

        }


        private List<SaklamaBilgileriResponse> RaftakiLastikler(List<SaklamaBilgileriResponse> list)
        {
            foreach (var item in list)
                item.Tblsaklamadetay.RemoveAll(x => x.bytHavuzda != 0);

            list.RemoveAll(x => x.Tblsaklamadetay.Count == 0);

            return list;
        }
    }
}
