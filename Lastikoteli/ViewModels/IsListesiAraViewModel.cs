using System;
using System.Threading.Tasks;
using Lastikoteli.Helper;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Constant;
using Lastikoteli.Views;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class IsListesiAraViewModel : BaseViewModel
    {
        private INavigation _navigation;
        private DoubleClickControl _doubleClickControl;
        public IsEmriRequest filter { get; set; }
        public Command gotoIsListesiCommand { get; set; }
        public Command gotoYeniSaklamaCommand { get; set; }
        public Command gotoYeniTakmaCommand { get; set; }

        public IsListesiAraViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _doubleClickControl = new DoubleClickControl(_navigation);
            gotoIsListesiCommand = new Command(async () => await gotoIsListesiPage());
            gotoYeniSaklamaCommand = new Command(async () => await gotoYeniSaklamaPage());
            filter = new IsEmriRequest();
        }

        private async Task gotoIsListesiPage()
        {
            if (IsBusy)
                return;

            IsListesiFilter.Filter = new IsEmriRequest
            {
                lngDistKod = App.sessionInfo.lngDistkod,
                trhHedefTarih = filter.trhHedefTarih,
                txtMusteriErpKod = filter.txtMusteriErpKod,
                txtPlaka = filter.txtPlaka
            };
            IsListesiFilter.Paging = new PagingRequest { Sayfa = -1 };

            IsBusy = true;

            try
            {
                var result = await IsEmriService.IsEmriListesi(new IsEmriListeRequest
                {
                    Paging = IsListesiFilter.Paging,
                    Filter = IsListesiFilter.Filter
                });
                await _doubleClickControl.PushAsync(new IsListesiTabbedPage(result.Result.Data));
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

        private async Task gotoYeniSaklamaPage()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                await _doubleClickControl.PushAsync(new YeniSaklamaTabbedPage());
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
