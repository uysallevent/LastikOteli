using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class MusteriAraPopUpViewModel : BaseViewModel
    {
        public MusteriAraPopUpPage Page { get; set; }

        private string _txtAranan;

        public string txtAranan
        {
            get { return _txtAranan; }
            set
            {
                _txtAranan = value;
                OnPropertyChanged("txtAranan");
            }
        }

        private bool _bytUnvan;
        public bool bytunvan
        {
            get { return _bytUnvan; }
            set
            {
                _bytUnvan = value;
                OnPropertyChanged("bytunvan");
            }
        }

        private bool _bytErpKod;
        public bool bytErpKod
        {
            get { return _bytErpKod; }
            set
            {
                _bytErpKod = value;
                OnPropertyChanged("bytErpKod");
            }
        }

        public ICommand musteriAraCommand { get; set; }

        private ObservableCollection<MusteriBilgileriResponse> _musteriBilgiList;

        public ObservableCollection<MusteriBilgileriResponse> musteriBilgiList
        {
            get { return _musteriBilgiList; }
            set
            {
                _musteriBilgiList = value;
                OnPropertyChanged("musteriBilgiList");
            }
        }

        private MusteriBilgileriResponse _secilenMusteri;

        public MusteriBilgileriResponse secilenMusteri
        {
            get { return _secilenMusteri; }
            set
            {
                _secilenMusteri = value;
                MessagingCenter.Send(this, "yeniSaklamaSecilenMusteri", _secilenMusteri);
                PopupNavigation.PopAsync(true);
                OnPropertyChanged("secilenMusteri");
            }
        }

        public MusteriAraPopUpViewModel()
        {
            bytunvan = true;
            bytErpKod = false;
            musteriAraCommand = new Command(async () => await musteriAraAsync());
        }

        private async Task musteriAraAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var result = await SaklamaService.MusteriListesi(
                    new SaklamaMusteriRequest
                    {
                        Filter = new CustomViewMusteriBilgileriRequest
                        {
                            LNGDISTKOD = App.sessionInfo.lngDistkod,
                            TXTERPKOD = bytErpKod ? txtAranan : null,
                            TXTUNVAN = bytunvan ? txtAranan : null
                        },
                        Paging = new PagingRequest { Sayfa = -1 }
                    });

                if (result.StatusCode != 500)
                {
                    musteriBilgiList = new ObservableCollection<MusteriBilgileriResponse>(result.Result.Data);
                }
                else
                {
                    musteriBilgiList = new ObservableCollection<MusteriBilgileriResponse>();
                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");
                }

            }
            catch (Exception)
            {
                await this.Page.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
