using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
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
    public class HavuzaGidecekSaklamaPopUpViewModel : BaseViewModel
    {
        private SaklamaBilgileriResponse _saklamaBilgileriResponse;
        public SaklamaBilgileriResponse saklamaBilgileriResponse
        {
            get { return _saklamaBilgileriResponse; }
            set { SetProperty(ref _saklamaBilgileriResponse, value); }
        }


        private IList<SaklamaBilgileriResponse> _saklamaBilgileriList;
        public IList<SaklamaBilgileriResponse> saklamaBilgileriList
        {
            get { return _saklamaBilgileriList; }
            set { SetProperty(ref _saklamaBilgileriList, value); }
        }


        public ICommand RafGuncelleCommand { get; set; }

        public HavuzaGidecekSaklamaPopUpViewModel(SaklamaBilgileriResponse saklamaBilgileri)
        {
            saklamaBilgileriResponse = saklamaBilgileri;
            saklamaBilgileriList = new ObservableCollection<SaklamaBilgileriResponse>() { saklamaBilgileriResponse };
            RafGuncelleCommand = new Command(async () => await RafGuncelleAsync());
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
                    lngSaklamaKodu = saklamaBilgileriResponse.lngKod,
                    detayKodRafKodList = saklamaBilgileriResponse.Tblsaklamadetay.Select(x => new KeyValuePair<int, int?>(x.lngKod, null)).ToList()
                });

                if (result.StatusCode != 500 && result.Result)
                {
                    await App.Current.MainPage.DisplayAlert("Uyarı", "Havuza taşıma başarılı", "Tamam");
                    MessagingCenter.Send(this, "lastikHavuzaTasimaBasarili");
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
    }
}
