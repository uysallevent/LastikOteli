using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Constant;
using Lastikoteli.Models.MiyaPortal;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace Lastikoteli.ViewModels
{
    public class IsListesiViewModel : BaseViewModel
    {
        private INavigation _navigation;
        //public ObservableCollection<Randevu> isListesi { get; set; }
        public InfiniteScrollCollection<Randevu> isListesi { get; set; }

        public IsListesiViewModel(INavigation navigation)
        {
            _navigation = navigation;

            isListesi = new InfiniteScrollCollection<Randevu>
            {
                OnLoadMore = async () =>
                {
                    IsBusy = true;
                    IsListesiFilter.Paging.Sayfa++;
                    var list = await IsEmriService.IsEmriListesi(new IsEmriListeRequest
                    {
                        Paging = new PagingRequest { Sayfa = IsListesiFilter.Paging.Sayfa },
                        Filter = new IsEmriRequest
                        {
                            lngDistKod = App.sessionInfo.lngDistkod,
                            trhHedefTarih = IsListesiFilter.Filter.trhHedefTarih,
                            txtMusteriErpKod = IsListesiFilter.Filter.txtMusteriErpKod,
                            txtPlaka = IsListesiFilter.Filter.txtPlaka
                        }
                    });

                    IsBusy = false;
                    return list.Result.Data;
                },
                OnCanLoadMore = () =>
                {
                    return isListesi.Count < 50;
                }
            };
        }

        private async Task DownloadDataAsync()
        {
            
            var items = await IsEmriService.IsEmriListesi(new IsEmriListeRequest
            {
                Paging = IsListesiFilter.Paging,
                Filter = IsListesiFilter.Filter
            });

            isListesi.AddRange(items.Result.Data);
        }
    }
}
