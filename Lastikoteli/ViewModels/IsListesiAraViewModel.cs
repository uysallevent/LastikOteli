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
        private IsEmriRequest _filter;
        public IsEmriRequest filter
        {
            get
            {
                return _filter;
            }
            set
            {
                SetProperty(ref _filter, value);
            }
        }

        public Command gotoIsListesiCommand { get; set; }
        public Command gotoYeniSaklamaCommand { get; set; }
        public Command gotoYeniTakmaCommand { get; set; }

        public IsListesiAraPage Page { get; set; }

        public IsListesiAraViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _doubleClickControl = new DoubleClickControl(_navigation);
            gotoIsListesiCommand = new Command(async () => await gotoIsListesiPage());
            gotoYeniSaklamaCommand = new Command(async () => await gotoYeniSaklamaPage());
            gotoYeniTakmaCommand = new Command(async () => await gotoYeniTakmaPage());
            filter = new IsEmriRequest();
            MessagingCenter.Subscribe<PlakaView, string>(this, "plakaBarcode", (s, e) =>
            {
                filter.txtPlaka = e;
                OnPropertyChanged("filter");
            });
        }

        private async Task gotoIsListesiPage()
        {
            if (IsBusy)
                return;

            IsListesiFilter.Filter = new IsEmriRequest
            {
                lngDistKod = App.sessionInfo.lngDistkod,
                trhHedefTarih = filter.trhHedefTarih ?? DateTime.Now,
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
                if (result.Result.Data != null && result.Result.Data.Count > 0)
                    await _doubleClickControl.PushAsync(new IsListesiTabbedPage(result.Result.Data));
                else
                    await this.Page.DisplayAlert("Uyarı", "İş emri bulunamadı", "Tamam");
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

        private async Task gotoYeniTakmaPage()
        {
            if (IsBusy)
                return;

            IsBusy = true;
            try
            {
                await _doubleClickControl.PushAsync(new YeniTakma(new TakmaRequest()));
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
