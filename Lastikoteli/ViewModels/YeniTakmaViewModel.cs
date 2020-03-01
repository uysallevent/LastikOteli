using Lastikoteli.Helper.Abstract;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Models.MiyaPortal;
using Lastikoteli.Views;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class YeniTakmaViewModel : BaseViewModel
    {
        public YeniTakma Page { get; set; }


        private SaklamaBilgiRequest _saklamaBilgiRequest;
        public SaklamaBilgiRequest saklamaBilgiRequest
        {
            get
            {
                if (!string.IsNullOrEmpty(_saklamaBilgiRequest.txtPlaka))
                    _saklamaBilgiRequest.lngSaklamaBaslik = null;
                else
                    _saklamaBilgiRequest.txtPlaka = "";

                return _saklamaBilgiRequest;
            }
            set
            {
                _saklamaBilgiRequest = value;
                OnPropertyChanged("SaklamaBilgiRequest");
            }
        }


        private Randevu _randevuBilgi;
        public Randevu randevuBilgi
        {
            get
            {
                return _randevuBilgi;
            }
            set
            {
                _randevuBilgi = value;
                OnPropertyChanged("randevuBilgi");
            }
        }


        private ObservableCollection<SaklamaBilgileriResponse> _saklamaBilgileriResponseList;
        public ObservableCollection<SaklamaBilgileriResponse> saklamaBilgileriResponseList
        {
            get { return _saklamaBilgileriResponseList; }
            set
            {
                _saklamaBilgileriResponseList = value;
                OnPropertyChanged("saklamaBilgileriResponseList");
            }
        }


        private SaklamaBilgileriResponse _selectedItemAdd;
        public SaklamaBilgileriResponse selectedItemAdd
        {
            get { return _selectedItemAdd; }
            set
            {
                if (value != null)
                {
                    _selectedItemAdd = value;
                    SelectedModel = value;
                    if (_selectedItemAdd.Tblsaklamadetay != null && _selectedItemAdd.Tblsaklamadetay.Count > 0)
                        this.Page.OpenPopup(TakmaModelOlustur(_selectedItemAdd));
                    else
                    {
                        randevuBilgi.TXTPLAKA = _selectedItemAdd.txtPlaka;
                        randevuBilgi.LNGKOD = _selectedItemAdd.lngKod;
                        Device.BeginInvokeOnMainThread(async () =>
                        {
                            var ask = await Page.DisplayAlert("Uyarı", "Lastiklerin takma işlemini tamamlamak istiyormusunuz", "Evet", "Hayır");
                            if (ask)
                            {
                                await IsEmriDurumDegistir();
                            }
                        });

                    }
                    _selectedItemAdd = null;
                }
                else
                    _selectedItemAdd = null;

                OnPropertyChanged("selectedItemAdd");
            }
        }


        public SaklamaBilgileriResponse SelectedModel { get; set; }

        public ICommand SaklamaBilgiGetirCommand { get; set; }


        public YeniTakmaViewModel(INavigation navigation, TakmaRequest request)
        {
            _navigation = navigation;
            //Saklamabilgileri, isemribilgilerinin null olma durumu direk olarak Takma adımıyla sayfaya gelinmesiyle olur. Bu durumda teslim işleminden sonra bu sayfada kalınır
            //Bu ikilinin null gelmeme durumunda bu sayfaya iş emri listesinden gelinmiş dmektir bu durumda teslim işleminin ardından iş listesine geri dönülür.
            if ((request.saklamaBilgileri != null && request.saklamaBilgileri.lngSaklamaBaslik != null) || (request.isEmriBilgileri != null && request.isEmriBilgileri.LNGKOD != 0))
            {
                saklamaBilgiRequest = request.saklamaBilgileri;
                randevuBilgi = request.isEmriBilgileri;
                MessagingCenter.Subscribe<TakilacakLastikPopUpViewModel>(this, "popAsync", (s) =>
                {
                    Device.BeginInvokeOnMainThread(() => _navigation.PopAsync(true));
                    MessagingCenter.Send(this, "refreshList");
                });
            }
            else
            {
                saklamaBilgiRequest = new SaklamaBilgiRequest();
                randevuBilgi = new Randevu();
                MessagingCenter.Subscribe<TakilacakLastikPopUpViewModel>(this, "popAsync", (s) =>
                {
                    saklamaBilgileriResponseList.Remove(SelectedModel);
                    saklamaBilgileriResponseList = new ObservableCollection<SaklamaBilgileriResponse>(saklamaBilgileriResponseList);
                });
            }


            if (request.saklamaBilgileri != null && saklamaBilgiRequest.lngSaklamaBaslik != null && saklamaBilgiRequest.lngSaklamaBaslik != 0)
                Device.BeginInvokeOnMainThread(async () => await SaklamaBilgiGetirAsync());

            if (request.isEmriBilgileri != null && randevuBilgi.LNGKOD != 0 && !string.IsNullOrEmpty(randevuBilgi.TXTPLAKA))
                Device.BeginInvokeOnMainThread(async () => await IsEmriBilgileriGetirAsync());

            SaklamaBilgiGetirCommand = new Command(async () => await SaklamaBilgiGetirAsync());

        }

        private async Task SaklamaBilgiGetirAsync()
        {
            try
            {
                if ((saklamaBilgiRequest.lngSaklamaBaslik == 0 || saklamaBilgiRequest.lngSaklamaBaslik == null) && string.IsNullOrEmpty(saklamaBilgiRequest.txtPlaka))
                {
                    DependencyService.Get<IToastService>().ToastMessage("Arama için plaka ya da saklama no girin");
                    return;
                }

                if (IsBusy)
                    return;

                IsBusy = true;

                saklamaBilgiRequest.lngDistKod = App.sessionInfo.lngDistkod;
                var result = await SaklamaService.SaklamadaKayitArama(saklamaBilgiRequest);

                if (result.StatusCode != 500)
                {
                    saklamaBilgileriResponseList = new ObservableCollection<SaklamaBilgileriResponse>(result.Result);
                }
                else
                {
                    saklamaBilgileriResponseList = new ObservableCollection<SaklamaBilgileriResponse>();
                    //await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");
                    IsBusy = false;
                    randevuBilgi = new Randevu { TXTPLAKA = saklamaBilgiRequest.txtPlaka };
                    await IsEmriBilgileriGetirAsync();
                }

            }
            catch (Exception ex)
            {
                await this.Page.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task IsEmriBilgileriGetirAsync()
        {
            try
            {
                if (string.IsNullOrEmpty(randevuBilgi.TXTPLAKA))
                {
                    DependencyService.Get<IToastService>().ToastMessage("Arama için plaka ya da saklama no girin");
                    return;
                }

                if (IsBusy)
                    return;

                IsBusy = true;

                var result = await IsEmriService.PlakayaGoreIsEmriListesiGetir(new SaklamaPlakaSorgulaRequest
                {
                    lngDistKod = App.sessionInfo.lngDistkod,
                    txtPlaka = randevuBilgi.TXTPLAKA
                });

                if (result.StatusCode != 500)
                {
                    //İş emrinden plaka göre gelen liste iş emri ekranında datagridde gösterilebilmek için saklamabilgileriresponse modeline döndürülüyor
                    var list = result.Result.Select(x => new SaklamaBilgileriResponse
                    {
                        txtPlaka = x.txtPlaka,
                        lngKod = x.lngKod
                    }).ToList();

                    saklamaBilgileriResponseList = new ObservableCollection<SaklamaBilgileriResponse>(list);
                }
                else
                {
                    saklamaBilgileriResponseList = new ObservableCollection<SaklamaBilgileriResponse>();
                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");
                }
            }
            catch (Exception ex)
            {
                await this.Page.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task IsEmriDurumDegistir()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var result = await IsEmriService.IsEmriDurumuTamamla(new IsEmriDurumGuncelleRequest
                {
                    bytDurum = 2,
                    lngDistKod = App.sessionInfo.lngDistkod,
                    lngKod = randevuBilgi.LNGKOD,
                    lngTip = 1
                });

                if (result.StatusCode != 500 && result.Result)
                {
                    await App.Current.MainPage.DisplayAlert("Uyarı", "İş emri tamamlandı", "Tamam");
                    saklamaBilgileriResponseList.Remove(saklamaBilgileriResponseList.FirstOrDefault(x => x.lngKod == randevuBilgi.LNGKOD));
                    saklamaBilgileriResponseList = new ObservableCollection<SaklamaBilgileriResponse>(saklamaBilgileriResponseList);
                }
                else
                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");
            }
            catch (Exception ex)
            {
                await this.Page.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private ObservableCollection<TakmaResponse> TakmaModelOlustur(SaklamaBilgileriResponse saklamaBilgileri)
        {
            var response = new ObservableCollection<TakmaResponse>();
            foreach (var item in saklamaBilgileri.Tblsaklamadetay)
            {
                var marka = (item.markaListe != null && item.markaListe.Count > 0) ? item.markaListe.FirstOrDefault(x => x.Value == true).Key : item.txtMarka;
                var taban = (item.tabanListe != null && item.tabanListe.Count > 0) ? item.tabanListe.FirstOrDefault(x => x.Value == true).Key : item.txtTaban;
                var kesit = (item.kesitListe != null && item.kesitListe.Count > 0) ? item.kesitListe.FirstOrDefault(x => x.Value == true).Key : item.txtKesit;
                var cap = (item.capListe != null && item.capListe.Count > 0) ? item.capListe.FirstOrDefault(x => x.Value == true).Key : item.txtCap;
                var mevsim = (item.mevsimListe != null && item.mevsimListe.Count > 0) ? item.mevsimListe.FirstOrDefault(x => x.Value == true).Key : item.txtMevsim;
                var desen = (item.desenListe != null && item.desenListe.Count > 0) ? item.desenListe.FirstOrDefault(x => x.Value == true).Key : item.txtMevsim;

                response.Add(new TakmaResponse
                {
                    lngIsEmriKod = saklamaBilgiRequest.lngIsEmriKod ?? 0,
                    lngSaklamaKod = saklamaBilgileri.lngKod,
                    txtPozisyon = item.txtLastikYon,
                    txtRaf = item.txtRafKolayKod,
                    txtLastik = $"{marka} {taban}/{kesit}R{cap} {mevsim} {desen}",
                    lngOTL = item.txtLastikDurum == "ÖTL YE ALINDI" ? 1 : 0,
                    bytOTL = item.txtLastikDurum == "ÖTL YE ALINDI" ? true : false,
                    bytSec = item.txtLastikDurum == "ÖTL YE ALINDI" ? false : true,
                }); ;
            }

            return response;
        }

    }
}
