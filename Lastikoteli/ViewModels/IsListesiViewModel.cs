using Lastikoteli.Helper;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Models.Constant;
using Lastikoteli.Models.MiyaPortal;
using Lastikoteli.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace Lastikoteli.ViewModels
{
    public class IsListesiViewModel : BaseViewModel
    {
        public IsListesiPage Page { get; set; }


        private ObservableCollection<Randevu> _isListesi;
        public ObservableCollection<Randevu> isListesi
        {
            get { return _isListesi; }
            set
            {
                _isListesi = value;
                OnPropertyChanged("isListesi");
            }
        }


        private Randevu _isListesiSelected;
        public Randevu IsListesiSelected
        {
            get { return _isListesiSelected ?? new Randevu(); }
            set
            {
                if (value != null)
                {
                    _isListesiSelected = value;
                    SelectedModel = value;
                    OpenPopUpDialog(value);
                    _isListesiSelected = null;
                }
                else
                    _isListesiSelected = null;
                OnPropertyChanged("IsListesiSelected");
            }
        }

        private Randevu _selectedModel;

        public Randevu SelectedModel
        {
            get { return _selectedModel; }
            set
            {
                _selectedModel = value;
                OnPropertyChanged("SelectedModel");
            }
        }


        private async void OpenPopUpDialog(Randevu randevu)

        {
            string actionSheetResult = "";
            if (randevu.TXTSOKMETAKMA == "S")
            {
                await _doubleClickControl.PushAsync(new YeniSaklamaTabbedPage());
                MessagingCenter.Send(this, "IsEmriYeniSaklama", randevu);
            }
            else if (randevu.TXTSOKMETAKMA == "T")
            {
                await _doubleClickControl.PushAsync(new YeniTakma(
                    new TakmaRequest
                    {
                        saklamaBilgileri = new SaklamaBilgiRequest
                        {
                            lngDistKod = randevu.LNGDISTKOD,
                            lngSaklamaBaslik = randevu.LNGSAKLAMABASLIK,
                            lngIsEmriKod = randevu.LNGKOD
                        },
                        isEmriBilgileri = randevu
                    }));
            }
            else if (randevu.TXTSOKMETAKMA == "S/T")
            {
                actionSheetResult = await this.Page.DisplayActionSheet("Seçim Yapın", "İptal", null, "Saklama", "Sökme/Takma");
            }
            else if (randevu.TXTSOKMETAKMA == "Tamamlandı")
            {
                if (randevu.BYTSAKLAMA == 2 && randevu.BYTSOKMETAKMA == 2)
                    await Page.DisplayAlert("Uyarı", $"Saklama ve Sökme-Takma iş emri tamamlandı", "Tamam");
                else if (randevu.BYTSAKLAMA == 2 && randevu.BYTSOKMETAKMA == 0)
                    await Page.DisplayAlert("Uyarı", $"Saklama iş emri tamamlandı", "Tamam");
                else if (randevu.BYTSAKLAMA == 0 && randevu.BYTSOKMETAKMA == 2)
                    await Page.DisplayAlert("Uyarı", $"Sökme-Takma iş emri tamamlandı", "Tamam");

            }

            switch (actionSheetResult)
            {
                case "Saklama":

                    await _doubleClickControl.PushAsync(new YeniSaklamaTabbedPage());
                    MessagingCenter.Send(this, "IsEmriYeniSaklama", randevu);

                    break;
                case "Sökme/Takma":
                    await _doubleClickControl.PushAsync(new YeniTakma(
                        new TakmaRequest
                        {
                            saklamaBilgileri = new SaklamaBilgiRequest
                            {
                                lngDistKod = randevu.LNGDISTKOD,
                                lngSaklamaBaslik = randevu.LNGSAKLAMABASLIK,
                                lngIsEmriKod = randevu.LNGKOD
                            },
                            isEmriBilgileri = randevu
                        }));
                    break;
            }
        }

        public IsListesiViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _doubleClickControl = new DoubleClickControl(_navigation);
            pullRefreshList = new Command(async () => await isListesiGetir());
            MessagingCenter.Subscribe<YeniTakmaViewModel>(this, "refreshList", async (s) =>
             {
                 await isListesiGetir();
             });

            MessagingCenter.Subscribe<YeniSaklamaMarkaBilgileriViewModel>(this, "refreshList", async (s) =>
            {
                await isListesiGetir();
            });
        }

        public ICommand pullRefreshList { get; set; }
        private async Task isListesiGetir()
        {
            if (IsBusy)
                return;

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
                {

                    isListesi = new ObservableCollection<Randevu>(result.Result.Data);
                }
                else
                    throw new Exception("İş emri bulunamadı");
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", ex.Message, "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

    }
}
