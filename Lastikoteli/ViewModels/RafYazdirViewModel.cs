using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
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
    public class RafYazdirViewModel : BaseViewModel
    {
        public RafYazdirPage Page { get; set; }

        private DepoDizilimResponse _depoDizilimResponse;
        public DepoDizilimResponse depoDizilimResponse
        {
            get { return _depoDizilimResponse; }
            set
            {
                SetProperty(ref _depoDizilimResponse, value);
                selectedDepoBilgi.lngDepoSira = 2;
                selectedDepoBilgi.lngKod = value.lngKod;
                katList = new ObservableCollection<DepoDizilimResponse>();
                koridorList = new ObservableCollection<DepoDizilimResponse>();
                rafList = new ObservableCollection<DepoDizilimResponse>();
                siraList = new ObservableCollection<DepoDizilimResponse>();
                Device.BeginInvokeOnMainThread(async () => await DepoBilgileriGetirAsync());
            }
        }


        private DepoDizilimResponse _katDizilimResponse;
        public DepoDizilimResponse katDizilimResponse
        {
            get { return _katDizilimResponse; }
            set
            {
                SetProperty(ref _katDizilimResponse, value);
                if (_katDizilimResponse != null)
                {
                    selectedDepoBilgi.lngDepoSira = 3;
                    selectedDepoBilgi.lngKod = value.lngKod;
                    koridorList = new ObservableCollection<DepoDizilimResponse>();
                    rafList = new ObservableCollection<DepoDizilimResponse>();
                    siraList = new ObservableCollection<DepoDizilimResponse>();
                    Device.BeginInvokeOnMainThread(async () => await DepoBilgileriGetirAsync());
                }
            }
        }


        private DepoDizilimResponse _koridorDizilimResponse;
        public DepoDizilimResponse koridorDizilimResponse
        {
            get { return _koridorDizilimResponse; }
            set
            {
                SetProperty(ref _koridorDizilimResponse, value);
                if (_koridorDizilimResponse != null)
                {
                    selectedDepoBilgi.lngDepoSira = 4;
                    selectedDepoBilgi.lngKod = value.lngKod;
                    rafList = new ObservableCollection<DepoDizilimResponse>();
                    siraList = new ObservableCollection<DepoDizilimResponse>();
                    Device.BeginInvokeOnMainThread(async () => await DepoBilgileriGetirAsync());
                }
            }
        }


        private DepoDizilimResponse _rafDizilimResponse;
        public DepoDizilimResponse rafDizilimResponse
        {
            get { return _rafDizilimResponse; }
            set
            {
                SetProperty(ref _rafDizilimResponse, value);
                if (_rafDizilimResponse != null)
                {
                    selectedDepoBilgi.lngDepoSira = 5;
                    selectedDepoBilgi.lngKod = value.lngKod;
                    siraList = new ObservableCollection<DepoDizilimResponse>();
                    Device.BeginInvokeOnMainThread(async () => await DepoBilgileriGetirAsync());
                }

            }
        }


        private DepoDizilimResponse _siraDizilimResponse;
        public DepoDizilimResponse siraDizilimResponse
        {
            get
            {
                return _siraDizilimResponse;
            }
            set
            {
                SetProperty(ref _siraDizilimResponse, value);
            }
        }


        private DepoDizilimRequest _selectedDepoBilgi;
        public DepoDizilimRequest selectedDepoBilgi
        {
            get
            {
                return _selectedDepoBilgi;
            }
            set
            {
                _selectedDepoBilgi = value;
                OnPropertyChanged("selectedDepoBilgi");
            }
        }


        private IList<DepoDizilimResponse> _depoList;
        public IList<DepoDizilimResponse> depoList
        {
            get { return _depoList; }
            set { SetProperty(ref _depoList, value); }
        }


        private IList<DepoDizilimResponse> _katList;
        public IList<DepoDizilimResponse> katList
        {
            get { return _katList; }
            set { SetProperty(ref _katList, value); }
        }


        private IList<DepoDizilimResponse> _koridorList;
        public IList<DepoDizilimResponse> koridorList
        {
            get { return _koridorList; }
            set { SetProperty(ref _koridorList, value); }
        }


        private IList<DepoDizilimResponse> _rafList;
        public IList<DepoDizilimResponse> rafList
        {
            get { return _rafList; }
            set
            {
                SetProperty(ref _rafList, value);
            }
        }


        private IList<DepoDizilimResponse> _siraList;
        public IList<DepoDizilimResponse> siraList
        {
            get { return _siraList; }
            set { SetProperty(ref _siraList, value); }
        }


        private bool _hepsiniSec;

        public bool hepsiniSec
        {
            get { return _hepsiniSec; }
            set
            {
                SetProperty(ref _hepsiniSec, value);
                if (siraList != null && siraList.Count > 0 && _hepsiniSec)
                {
                    siraList.ToList().ForEach(x => x.bytSec = 1);
                    siraList = new ObservableCollection<DepoDizilimResponse>(siraList);
                }
                if (siraList != null && siraList.Count > 0 && !_hepsiniSec)
                {
                    siraList.ToList().ForEach(x => x.bytSec = 0);
                    siraList = new ObservableCollection<DepoDizilimResponse>(siraList);
                }

            }
        }



        public ICommand YazdirCommand { get; set; }

        public RafYazdirViewModel()
        {
            hepsiniSec = false;
            siraDizilimResponse = new DepoDizilimResponse();
            YazdirCommand = new Command(async () => await YazdirAsync());
            selectedDepoBilgi = new DepoDizilimRequest() { lngDistKod = App.sessionInfo.lngDistkod, lngDepoSira = 1 };
            Device.BeginInvokeOnMainThread(async () => await DepoBilgileriGetirAsync());
        }

        private async Task YazdirAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                if(siraList.Count(x=>x.bytSec==1)==0)
                {
                    await Page.DisplayAlert("Uyarı", "Yazdırılacak sıra bilgisi seçilmedi", "Tamam");
                    return;
                }

                IsBusy = true;

                var result = await ParametreService.SiraKolayKodDesenBilgiGetir();

                if (result.StatusCode != 500 && !string.IsNullOrEmpty(result.Result.yaziciDesenBilgi))
                    PopupNavigation.PushAsync(new SearchPrinterPopupPage(new PrintRequest
                    {
                        siraKolayKodEtiketBilgileri = new SiraKolayKodBilgiRequest
                        {
                            desenKodu = "",
                            rafKolayKodListesi = siraList.Where(x => x.bytSec == 1).ToList()
                        }
                    }));
                else
                    await Page.DisplayAlert("Uyarı", !string.IsNullOrEmpty(result.ErrorMessage) ? result.ErrorMessage : "Sıra kolay kod desen bilgisi alınamadı", "Tamam");

            }
            catch (Exception)
            {
                await Page.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task DepoBilgileriGetirAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var result = await DepoService.DepoBilgiGetir(selectedDepoBilgi);
                if (result.StatusCode != 500)
                {
                    if (selectedDepoBilgi.lngDepoSira == 1)
                        depoList = new ObservableCollection<DepoDizilimResponse>(result.Result);

                    if (selectedDepoBilgi.lngDepoSira == 2)
                        katList = new ObservableCollection<DepoDizilimResponse>(result.Result);

                    if (selectedDepoBilgi.lngDepoSira == 3)
                        koridorList = new ObservableCollection<DepoDizilimResponse>(result.Result);

                    if (selectedDepoBilgi.lngDepoSira == 4)
                        rafList = new ObservableCollection<DepoDizilimResponse>(result.Result);

                    if (selectedDepoBilgi.lngDepoSira == 5)
                    {
                        result.Result.ToList().ForEach(x => x.bytSec = 0);
                        siraList = new ObservableCollection<DepoDizilimResponse>(result.Result);
                    }
                }
                else
                {
                    depoList = new ObservableCollection<DepoDizilimResponse>();
                    await this.Page.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");
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

    }
}
