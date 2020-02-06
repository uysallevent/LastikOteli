using System;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class IsListesiViewModel : BaseViewModel
    {
        private INavigation _navigation;

        public IsListesiViewModel(INavigation navigation)
        {
            _navigation = navigation;

            var result = IsEmriService.IsEmriListesi(new Models.Complex.Request.IsEmriListeRequest
            {
                Paging = new Models.Complex.Request.PagingRequest { Sayfa = 1 },
                Filter = new Models.Complex.Request.IsEmriRequest
                {
                    lngDistKod=App.sessionInfo.lngDistkod,
                    trhBasTarih=new DateTime(2018,1,1,0,0,0),
                    trhBitTarih= new DateTime(2022, 1, 1, 0, 0, 0),
                }

            });
        }
    }
}
