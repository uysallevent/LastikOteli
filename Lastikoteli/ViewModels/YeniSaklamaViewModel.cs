using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
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
    public class YeniSaklamaViewModel : BaseViewModel
    {
        private INavigation _navigation;


        public YeniSaklamaPlakaBilgileri PagePlakaBilgi { get; set; }
        public YeniSaklamaMarkaBilgi PageMarkaBilgi { get; set; }


        private MarkaBilgiRequest _markaBilgiRequest;
        public MarkaBilgiRequest markaBilgiReuqest
        {
            get
            {
                return _markaBilgiRequest;
            }
            set
            {
                _markaBilgiRequest = value;
                OnPropertyChanged("markaBilgiReuqest");

            }
        }


        private SaklamaBaslikRequest _saklamaBaslikRequest;
        public SaklamaBaslikRequest saklamaBaslikRequest
        {
            get { return _saklamaBaslikRequest; }
            set
            {
                _saklamaBaslikRequest = value;
                OnPropertyChanged("saklamaBaslikRequest");
            }
        }


        private ObservableCollection<SaklamaDetayRequest> _detayListe;
        public ObservableCollection<SaklamaDetayRequest> detayListe
        {
            get
            {
                return _detayListe;
            }
            set
            {
                _detayListe = value;
                OnPropertyChanged("detayListe");
            }
        }


        private SaklamaDetayRequest _detay;
        public SaklamaDetayRequest detay
        {
            get
            {
                if (lngLastikYon == 0)
                {
                    if (detayListe.Count == 0)
                        detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 1, BYTHAVUZDA = 1 });

                    detayListe[lngLastikYon].BYTDURUM = _detay.BYTDURUM;
                    detayListe[lngLastikYon].DBLDISDERINLIGI = _detay.DBLDISDERINLIGI;
                    detayListe[lngLastikYon].ISOTL = _detay.ISOTL;
                    detayListe[lngLastikYon].LNGDEPOSIRAKOD = _detay.LNGDEPOSIRAKOD;
                    detayListe[lngLastikYon].LNGLASTIKDURUM = 1;
                    detayListe[lngLastikYon].LNGLASTIKTIP = 2;//ÖnSol
                    detayListe[lngLastikYon].LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                    detayListe[lngLastikYon].LNGURUNTIP = detay.LNGURUNTIP;
                    detayListe[lngLastikYon].TXTACIKLAMA = detay.TXTACIKLAMA;
                    detayListe[lngLastikYon].TXTDOTFABRIKA = detay.TXTDOTFABRIKA;
                    detayListe[lngLastikYon].TXTDOTHAFTA = detay.TXTDOTHAFTA;
                    detayListe[lngLastikYon].TXTDOTURETIM = detay.TXTDOTURETIM;
                    detayListe[lngLastikYon].TXTURUNKOD = detay.TXTURUNKOD;
                }
                else if (lngLastikYon == 1)
                {
                    if (detayListe.Count == 1)
                        detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 1, BYTHAVUZDA = 1 });

                    detayListe[lngLastikYon].BYTDURUM = _detay.BYTDURUM;
                    detayListe[lngLastikYon].DBLDISDERINLIGI = _detay.DBLDISDERINLIGI;
                    detayListe[lngLastikYon].ISOTL = _detay.ISOTL;
                    detayListe[lngLastikYon].LNGDEPOSIRAKOD = _detay.LNGDEPOSIRAKOD;
                    detayListe[lngLastikYon].LNGLASTIKDURUM = 1;
                    detayListe[lngLastikYon].LNGLASTIKTIP = 1;//ÖnSağ
                    detayListe[lngLastikYon].LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                    detayListe[lngLastikYon].LNGURUNTIP = detay.LNGURUNTIP;
                    detayListe[lngLastikYon].TXTACIKLAMA = detay.TXTACIKLAMA;
                    detayListe[lngLastikYon].TXTDOTFABRIKA = detay.TXTDOTFABRIKA;
                    detayListe[lngLastikYon].TXTDOTHAFTA = detay.TXTDOTHAFTA;
                    detayListe[lngLastikYon].TXTDOTURETIM = detay.TXTDOTURETIM;
                    detayListe[lngLastikYon].TXTURUNKOD = detay.TXTURUNKOD;
                }
                return _detay;
            }
            set
            {
                SetProperty<SaklamaDetayRequest>(ref _detay, value);
            }
        }


        private KullaniciUrunRequest _kullaniciUrunBilgileri;
        public KullaniciUrunRequest kullaniciUrunBilgileri
        {
            get
            {
                return _kullaniciUrunBilgileri;
            }
            set
            {
                SetProperty<KullaniciUrunRequest>(ref _kullaniciUrunBilgileri, value);
            }

        }


        private int _selectedIndex;
        public int selectedMarkaIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                if (_selectedIndex != null && _selectedIndex != -1)
                {
                    markaBilgiReuqest.txtMarka = lastikBilgileri.markaListe[_selectedIndex].txtMarka;
                    MarkaBilgiGetirCommand.Execute(true);
                }
                OnPropertyChanged("selectedMarkaIndex");

            }
        }
        public int selectedTabanIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                if (_selectedIndex != null && _selectedIndex != -1)
                {
                    markaBilgiReuqest.txtTaban = lastikBilgileri.tabanListe[_selectedIndex].txtTaban;
                    MarkaBilgiGetirCommand.Execute(true);
                }
                OnPropertyChanged("selectedTabanIndex");

            }
        }
        public int selectedKesitIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                if (_selectedIndex != null && _selectedIndex != -1)
                {
                    markaBilgiReuqest.txtKesit = lastikBilgileri.kesitListe[_selectedIndex].txtKesit;
                    MarkaBilgiGetirCommand.Execute(true);
                }
                OnPropertyChanged("selectedKesitIndex");

            }
        }
        public int selectedCapIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                if (_selectedIndex != null && _selectedIndex != -1)
                {
                    markaBilgiReuqest.txtCap = lastikBilgileri.capListe[_selectedIndex].txtCap;
                    MarkaBilgiGetirCommand.Execute(true);
                }
                OnPropertyChanged("selectedCapIndex");
            }
        }
        public int selectedMevsimIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                if (_selectedIndex != null && _selectedIndex != -1)
                {
                    markaBilgiReuqest.txtMevsim = lastikBilgileri.mevsimListe[_selectedIndex].txtMevsim;
                    MarkaBilgiGetirCommand.Execute(true);
                }
                OnPropertyChanged("selectedMevsimIndex");

            }
        }
        public int selectedDesenIndex
        {
            get
            {
                return _selectedIndex;
            }
            set
            {
                _selectedIndex = value;
                if (_selectedIndex != null && _selectedIndex != -1)
                    detay.TXTURUNKOD = lastikBilgileri.desenListe[_selectedIndex].txtUrunKod;
                OnPropertyChanged("selectedDesenIndex");

            }
        }


        private bool _bytUrunTip;
        public bool bytUrunTip
        {
            get
            {
                return _bytUrunTip;
            }
            set
            {
                _bytUrunTip = value;
                OnPropertyChanged("bytUrunTip");
            }
        }


        private int _lngLastikYon;
        public int lngLastikYon
        {
            get
            {
                return _lngLastikYon;
            }
            set
            {
                _lngLastikYon = value;
                OnPropertyChanged("lngLastikYon");
            }
        }


        private ObservableCollection<MarkaBilgiResponse> _markaListe;
        public ObservableCollection<MarkaBilgiResponse> markaListe
        {
            get
            {
                return _markaListe;
            }

            set
            {

                _markaListe = value;
                OnPropertyChanged("markaListe");
            }
        }


        private LastikBilgiResponse _lastikBilgileri;
        public LastikBilgiResponse lastikBilgileri
        {
            get
            {
                return _lastikBilgileri;
            }

            set
            {
                _lastikBilgileri = value;
                OnPropertyChanged("lastikBilgileri");
            }
        }

        public YeniSaklamaMarkaBilgi Page { get; set; }



        public ICommand GotoMusteriPopUpCommand { get; set; }
        public ICommand MarkaBilgiGetirCommand { get; set; }
        public ICommand DisDerinligiKontrolCommand { get; set; }
        public ICommand secilenLastikCommand { get; set; }
        public ICommand saklamayaAlCommand { get; set; }


        public YeniSaklamaViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Initializer();
            MarkaBilgiGetirCommand.Execute(true);
            MessagingCenter.Subscribe<MusteriAraPopUpViewModel, MusteriBilgileriResponse>(this, "yeniSaklamaSecilenMusteri", (s, e) =>
            {

            });

            MessagingCenter.Subscribe<DepoSecimPopUpViewModel, DepoDizilimResponse>(this, "selectedRaf", (s, e) =>
            {

            });
        }

        public void Initializer()
        {
            saklamaBaslikRequest = new SaklamaBaslikRequest()
            {
                detayListe = new ObservableCollection<SaklamaDetayRequest>()
            };
            detayListe = new ObservableCollection<SaklamaDetayRequest>();
            detay = new SaklamaDetayRequest();
            kullaniciUrunBilgileri = new KullaniciUrunRequest();
            markaBilgiReuqest = new MarkaBilgiRequest();
            lastikBilgileri = new LastikBilgiResponse();
            GotoMusteriPopUpCommand = new Command(async () => await GotoMusteriPopUpAsync());
            MarkaBilgiGetirCommand = new Command(async () => await MarkaBilgiGetirAsync());
            DisDerinligiKontrolCommand = new Command(async () => await DisDerinligiAsync());
            secilenLastikCommand = new Command((x) => secilenLastik(x));
            //saklamayaAlCommand = new Command(async () => await saklamayaAlAsync());
            lngLastikYon = 0;
        }

        private async Task saklamayaAlAsync()
        {

        }

        private void secilenLastik(object x)
        {
            lngLastikYon = Convert.ToInt32(x);
        }

        private async Task DisDerinligiAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var result = await SaklamaService.YasalDisDerinligiGetir();
                if (result.StatusCode != 500)
                {

                }
                else
                    await this.Page.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");

            }
            catch (Exception)
            {
                await this.Page.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
        }

        private async Task MarkaBilgiGetirAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                markaBilgiReuqest.lngUrunTip = !bytUrunTip ? 1 : 2;
                var result = await ParametreService.MarkaBilgiGetir(markaBilgiReuqest);
                if (result.StatusCode != 500)
                {
                    if (lastikBilgileri.markaListe == null || lastikBilgileri.markaListe.Count == 0)
                        lastikBilgileri.markaListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                    else if (lastikBilgileri.markaListe.Count > 0 && (lastikBilgileri.tabanListe == null || lastikBilgileri.tabanListe.Count == 0))
                        lastikBilgileri.tabanListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                    else if (lastikBilgileri.markaListe.Count > 0 && lastikBilgileri.tabanListe.Count > 0 && (lastikBilgileri.kesitListe == null || lastikBilgileri.kesitListe.Count == 0))
                        lastikBilgileri.kesitListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                    else if (lastikBilgileri.markaListe.Count > 0 && lastikBilgileri.tabanListe.Count > 0 && lastikBilgileri.kesitListe.Count > 0 && (lastikBilgileri.capListe == null || lastikBilgileri.capListe.Count == 0))
                        lastikBilgileri.capListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                    else if (lastikBilgileri.markaListe.Count > 0 && lastikBilgileri.tabanListe.Count > 0 && lastikBilgileri.kesitListe.Count > 0 && lastikBilgileri.capListe.Count > 0 && (lastikBilgileri.mevsimListe == null || lastikBilgileri.mevsimListe.Count == 0))
                        lastikBilgileri.mevsimListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                    else if (lastikBilgileri.markaListe.Count > 0 && lastikBilgileri.tabanListe.Count > 0 && lastikBilgileri.kesitListe.Count > 0 && lastikBilgileri.capListe.Count > 0 && lastikBilgileri.mevsimListe.Count > 0 && (lastikBilgileri.desenListe == null || lastikBilgileri.desenListe.Count == 0))
                        lastikBilgileri.desenListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                }
                else
                {
                    markaListe = new ObservableCollection<MarkaBilgiResponse>();
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

        private async Task GotoMusteriPopUpAsync()
        {
            PagePlakaBilgi.OpenPopup();
        }

    }
}
