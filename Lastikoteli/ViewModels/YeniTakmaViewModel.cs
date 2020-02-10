using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Linq;

namespace Lastikoteli.ViewModels
{
    public class YeniTakmaViewModel : BaseViewModel
    {

        private INavigation _navigation;
        public YeniTakma Page { get; set; }

        private IList<SaklamaBilgileriResponse> _saklamaBilgileriResponseList;
        public IList<SaklamaBilgileriResponse> saklamaBilgileriResponseList
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

        private Command SaklamaBilgiGetirCommand { get; set; }
        public YeniTakmaViewModel(INavigation navigation, int lngSaklamaBaslik)
        {
            _navigation = navigation;
            if (lngSaklamaBaslik != 0)
                Device.BeginInvokeOnMainThread(async () => await SaklamaBilgiGetirAsync(lngSaklamaBaslik));
        }

        private async Task SaklamaBilgiGetirAsync(int lngSaklamaBaslik)
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var result = await SaklamaService.SaklamaBilgiGetir(new SaklamaBilgiRequest
                {
                    lngDistKod = App.sessionInfo.lngDistkod,
                    lngSaklamaBaslik = lngSaklamaBaslik
                });
                if (result.StatusCode != 500)
                {
                    saklamaBilgileriResponseList = new ObservableCollection<SaklamaBilgileriResponse>();
                    saklamaBilgileriResponseList.Add(result.Result);
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
                var marka = item.markaListe.FirstOrDefault(x => x.Value == true).Key;
                var taban = item.tabanListe.FirstOrDefault(x => x.Value == true).Key;
                var kesit = item.kesitListe.FirstOrDefault(x => x.Value == true).Key;
                var cap = item.capListe.FirstOrDefault(x => x.Value == true).Key;
                var mevsim = item.mevsimListe.FirstOrDefault(x => x.Value == true).Key;
                var desen = item.desenListe.FirstOrDefault(x => x.Value == true).Key;

                response.Add(new TakmaResponse
                {
                    lngSaklamaKod = saklamaBilgileri.lngKod,
                    txtPozisyon = item.txtLastikYon,
                    txtRaf = item.txtRafKolayKod,
                    txtLastik = $"{marka} {taban}/{kesit}R{cap} {mevsim} {desen}",
                    lngOTL = item.txtLastikDurum == "ÖTL YE ALINDI" ? 1 : 0
                }); ;
            }

            return response;
        }


    }
}
