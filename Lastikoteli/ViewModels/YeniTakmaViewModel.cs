using Lastikoteli.Helper.Abstract;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
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

        private INavigation _navigation;
        public YeniTakma Page { get; set; }
        private SaklamaBilgiRequest _saklamaBilgiRequest;

        public SaklamaBilgiRequest SaklamaBilgiRequest
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
                    this.Page.OpenPopup(TakmaModelOlustur(_selectedItemAdd));
                    _selectedItemAdd = null;
                }
                else
                    _selectedItemAdd = null;

                OnPropertyChanged("selectedItemAdd");
            }
        }
        public SaklamaBilgileriResponse SelectedModel { get; set; }

        public ICommand SaklamaBilgiGetirCommand { get; set; }
        public YeniTakmaViewModel(INavigation navigation, SaklamaBilgiRequest request)
        {
            _navigation = navigation;
            SaklamaBilgiRequest = request;
            if (SaklamaBilgiRequest.lngSaklamaBaslik != null && SaklamaBilgiRequest.lngSaklamaBaslik != 0)
                Device.BeginInvokeOnMainThread(async () => await SaklamaBilgiGetirAsync());

            SaklamaBilgiGetirCommand = new Command(async () => await SaklamaBilgiGetirAsync());
            MessagingCenter.Subscribe<TakilacakLastikPopUpViewModel>(this, "popAsync", (s) =>
            {
                Device.BeginInvokeOnMainThread(() => _navigation.PopAsync(true));
                MessagingCenter.Send(this, "refreshList");
            });
        }
        private async Task SaklamaBilgiGetirAsync()
        {
            try
            {
                if ((SaklamaBilgiRequest.lngSaklamaBaslik == 0 || SaklamaBilgiRequest.lngSaklamaBaslik == null) && string.IsNullOrEmpty(SaklamaBilgiRequest.txtPlaka))
                {
                    DependencyService.Get<IToastService>().ToastMessage("Arama için plaka ya da saklama no girin");
                    return;
                }

                if (IsBusy)
                    return;

                IsBusy = true;

                SaklamaBilgiRequest.lngDistKod = App.sessionInfo.lngDistkod;
                var result = await SaklamaService.SaklamadaKayitArama(SaklamaBilgiRequest);

                if (result.StatusCode != 500)
                {
                    saklamaBilgileriResponseList = new ObservableCollection<SaklamaBilgileriResponse>(result.Result);
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
        private ObservableCollection<TakmaResponse> TakmaModelOlustur(SaklamaBilgileriResponse saklamaBilgileri)
        {
            var response = new ObservableCollection<TakmaResponse>();
            foreach (var item in saklamaBilgileri.Tblsaklamadetay)
            {
                var marka = item.markaListe.FirstOrDefault(x => x.Value == true).Key;
                var taban = item.tabanListe.FirstOrDefault(x => x.Value == true).Key;
                var kesit = item.kesitListe.FirstOrDefault(x => x.Value == true).Key;
                var cap = item.capListe.FirstOrDefault(x => x.Value == true).Key;
                var mevsim = item.mevsimListe.FirstOrDefault(x => x.Value == true).Key;
                var desen = item.desenListe.FirstOrDefault(x => x.Value == true).Key;

                response.Add(new TakmaResponse
                {
                    lngIsEmriKod = SaklamaBilgiRequest.lngIsEmriKod ?? 0,
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
