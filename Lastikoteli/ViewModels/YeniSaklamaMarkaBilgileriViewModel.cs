using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xfx;

namespace Lastikoteli.ViewModels
{
    public class YeniSaklamaMarkaBilgileriViewModel : BaseViewModel
    {
        private INavigation _navigation;

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
                if (_selectedIndex != -1)
                {
                    markaBilgiReuqest.txtTaban = "";
                    markaBilgiReuqest.txtKesit = "";
                    markaBilgiReuqest.txtCap = "";
                    markaBilgiReuqest.txtMevsim = "";
                    markaBilgiReuqest.txtDesen = "";
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
                if (_selectedIndex != -1)
                {
                    markaBilgiReuqest.txtKesit = "";
                    markaBilgiReuqest.txtCap = "";
                    markaBilgiReuqest.txtMevsim = "";
                    markaBilgiReuqest.txtDesen = "";
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
                if (_selectedIndex != -1)
                {
                    markaBilgiReuqest.txtCap = "";
                    markaBilgiReuqest.txtMevsim = "";
                    markaBilgiReuqest.txtDesen = "";
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
                if (_selectedIndex != -1)
                {
                    markaBilgiReuqest.txtMevsim = "";
                    markaBilgiReuqest.txtDesen = "";
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
                if (_selectedIndex != -1)
                {
                    markaBilgiReuqest.txtDesen = "";
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
                if (_selectedIndex != -1)
                {
                    markaBilgiReuqest.txtDesen = lastikBilgileri.desenListe[_selectedIndex].txtDesen;
                    MarkaBilgiGetirCommand.Execute(true);
                }
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


        //Saklama ekleme ekranında lastik butonlarına tıklama ile lastik detay bilgilerinin ön sola eşitlenmesini engellemek için kullanılan property
        private bool _tumunuEsitle;
        public bool tumunuEsitle
        {
            get
            {
                return _tumunuEsitle;
            }
            set
            {
                _tumunuEsitle = value;
                OnPropertyChanged("tumunuEsitle");
            }
        }


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


        private SaklamaDetayRequest _detay;
        public SaklamaDetayRequest detay
        {
            get
            {
                for (int i = 0; i < 6; i++)
                {
                    if ((lngLastikYon == 0 && tumunuEsitle) || lngLastikYon == i)
                    {
                        detayListe[i].DBLDISDERINLIGI = _detay.DBLDISDERINLIGI;
                        detayListe[i].LNGDEPOSIRAKOD = _detay.LNGDEPOSIRAKOD;
                        detayListe[i].LNGLASTIKDURUM = 1;
                        detayListe[i].LNGLASTIKTIP = (i == 0) ? 2 : (i == 1) ? 1 : (i == 2) ? 3 : (i == 3) ? 4 : (i == 4) ? 5 : 6;
                        detayListe[i].LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                        detayListe[i].LNGURUNTIP = _detay.LNGURUNTIP;
                        detayListe[i].TXTRAFKOLAYKOD = _detay.TXTRAFKOLAYKOD;
                        detayListe[i].TXTDOTFABRIKA = _detay.TXTDOTFABRIKA;
                        detayListe[i].TXTDOTHAFTA = _detay.TXTDOTHAFTA;
                        detayListe[i].TXTDOTURETIM = _detay.TXTDOTURETIM;
                        if (!_detay.bytUrunTip)
                            detayListe[i].TXTURUNKOD = _detay.TXTURUNKOD;
                        else
                        {
                            detayListe[i].TXTURUNKOD = null;
                            detayListe[i].kullaniciUrunBilgileri.TXTMARKA = _detay.kullaniciUrunBilgileri.TXTMARKA;
                            detayListe[i].kullaniciUrunBilgileri.TXTTABAN = _detay.kullaniciUrunBilgileri.TXTTABAN;
                            detayListe[i].kullaniciUrunBilgileri.TXTKESIT = _detay.kullaniciUrunBilgileri.TXTKESIT;
                            detayListe[i].kullaniciUrunBilgileri.TXTCAP = _detay.kullaniciUrunBilgileri.TXTCAP;
                            detayListe[i].kullaniciUrunBilgileri.TXTMEVSIM = _detay.kullaniciUrunBilgileri.TXTMEVSIM;
                            detayListe[i].kullaniciUrunBilgileri.TXTDESEN = _detay.kullaniciUrunBilgileri.TXTDESEN;
                            detayListe[i].kullaniciUrunBilgileri.BYTDURUM = _detay.kullaniciUrunBilgileri.BYTDURUM;
                            detayListe[i].kullaniciUrunBilgileri.LNGLASTIKTIP = (i == 0) ? 2 : (i == 1) ? 1 : (i == 2) ? 3 : (i == 3) ? 4 : (i == 4) ? 5 : 6;
                            detayListe[i].kullaniciUrunBilgileri.LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                        }
                    }

                    if (lngLastikYon == i)
                    {
                        detayListe[i].ISOTL = _detay.ISOTL;
                        detayListe[i].BYTDURUM = _detay.BYTDURUM;
                        detayListe[i].TXTACIKLAMA = _detay.TXTACIKLAMA;
                    }
                }
                return _detay;
            }
            set
            {
                SetProperty<SaklamaDetayRequest>(ref _detay, value);
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


        #region BaslikBilgileri
        private SaklamaBaslikRequest _saklamaBaslikRequest;
        public SaklamaBaslikRequest saklamaBaslikRequest
        {
            get { return _saklamaBaslikRequest; }
            set
            {
                SetProperty<SaklamaBaslikRequest>(ref _saklamaBaslikRequest, value);
            }
        }
        #endregion


        public ICommand MarkaBilgiGetirCommand { get; set; }
        public ICommand DisDerinligiKontrolCommand { get; set; }
        public ICommand secilenLastikCommand { get; set; }
        public ICommand saklamayaAlCommand { get; set; }
        public ICommand GotoMusteriPopUpCommand { get; set; }
        public ICommand RafKolayKodKontrolCommand { get; set; }
        public ICommand PlakaKontrolCommand { get; set; }

        public YeniSaklamaMarkaBilgileriViewModel(INavigation navigation)
        {
            _navigation = navigation;
            Initializer();
            MarkaBilgiGetirCommand = new Command(async () => await MarkaBilgiGetirAsync());
            DisDerinligiKontrolCommand = new Command(async () => await DisDerinligiAsync());
            secilenLastikCommand = new Command((x) => secilenLastik(x));
            saklamayaAlCommand = new Command(async () => await saklamayaAlAsync());
            GotoMusteriPopUpCommand = new Command(async () => await GotoMusteriPopUpAsync());
            RafKolayKodKontrolCommand = new Command(async (x) => await RafKolayKodKontrolAsync(x));
            PlakaKontrolCommand = new Command(async (x) => await PlakaKontrolAsync(x));
            MarkaBilgiGetirCommand.Execute(true);
            MessagingCenter.Subscribe<DepoSecimPopUpViewModel, DepoDizilimResponse>(this, "selectedRaf", (s, e) =>
            {
                detay.TXTRAFKOLAYKOD = e.txtKod;
                detay.LNGDEPOSIRAKOD = e.lngKod;
                OnPropertyChanged("detay");
            });
            MessagingCenter.Subscribe<MusteriAraPopUpViewModel, MusteriBilgileriResponse>(this, "yeniSaklamaSecilenMusteri", (s, e) =>
            {
                saklamaBaslikRequest.TXTMUSTERIUNVAN = e.TXTUNVAN;
                saklamaBaslikRequest.LNGMUSTERIKOD = e.LNGKOD;
                saklamaBaslikRequest.TXTMUSTERIERPKOD = e.TXTERPKOD;
                OnPropertyChanged("saklamaBaslikRequest");
            });

        }

        private async Task PlakaKontrolAsync(object x)
        {
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                var result = await SaklamaService.PlakaSorgula(x.ToString());
                if (result.StatusCode != 500)
                {
                    _saklamaBaslikRequest.LNGMUSTERIKOD = result.Result.lngMusteriKod;
                    _saklamaBaslikRequest.TXTMUSTERIUNVAN = result.Result.txtUnvan;
                    _saklamaBaslikRequest.TXTTCKIMLIKNO = result.Result.txtTcKimlikNo;
                    _saklamaBaslikRequest.TXTVN = result.Result.txtVN;
                    _saklamaBaslikRequest.TXTSOFORADSOYAD = result.Result.txtKullaniciAdiSoyadi;
                    _saklamaBaslikRequest.TXTCEPTEL = result.Result.txtCepTelNo;
                    _saklamaBaslikRequest.TXTEMAIL = result.Result.txtEmail;
                    _saklamaBaslikRequest.TXTPLAKA = result.Result.txtPlaka;
                    OnPropertyChanged("saklamaBaslikRequest");
                }
                else
                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");

            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");

            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task RafKolayKodKontrolAsync(object x)
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                var result = await DepoService.KolayKodKontrol(new RafKolayKodKontrolRequest
                {
                    lngDistKod = App.sessionInfo.lngDistkod,
                    txtRafKolayKod = x.ToString()
                });

                if (result.StatusCode != 500)
                {
                    _detay.LNGDEPOSIRAKOD = result.Result;
                    OnPropertyChanged("detay");
                }
                else
                {
                    detay.TXTRAFKOLAYKOD = null;
                    detay.LNGDEPOSIRAKOD = null;
                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");
                }


            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task saklamayaAlAsync()
        {
            try
            {
                detayListe.ToList().ForEach(x =>
                {
                    if (x.LNGURUNTIP == 1)
                        x.kullaniciUrunBilgileri = null;
                });
                saklamaBaslikRequest.Tblsaklamadetay = detayListe.Where(x => x.BYTDURUM == 1).ToList();

                if (IsBusy)
                    return;

                IsBusy = true;
                var result = await SaklamaService.YeniSaklamaEkle(saklamaBaslikRequest);

                if (result.StatusCode != 500 && result.Result > 0)
                    await App.Current.MainPage.DisplayAlert("Uyarı", $"Lastikler {result.Result} saklama kodu ile kaydedilmiştir", "Tamam");
                else
                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");
            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
                Initializer();
            }
        }

        private void secilenLastik(object x)
        {
            tumunuEsitle = false;
            lngLastikYon = Convert.ToInt32(x);
            detay = detayListe[lngLastikYon];
            tumunuEsitle = true;
            //OnPropertyChanged("detay");
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
                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");

            }
            catch (Exception)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
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
                    if (!string.IsNullOrEmpty(markaBilgiReuqest.txtDesen))
                    {
                        _detay.TXTURUNKOD = result.Result[0].txtUrunKod;
                        OnPropertyChanged("detay");
                    }
                    else if (!string.IsNullOrEmpty(markaBilgiReuqest.txtMevsim))
                    {
                        lastikBilgileri.desenListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                        detay.TXTURUNKOD = null;
                    }
                    else if (!string.IsNullOrEmpty(markaBilgiReuqest.txtCap))
                    {
                        lastikBilgileri.mevsimListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                        lastikBilgileri.desenListe = new ObservableCollection<MarkaBilgiResponse>();
                        detay.TXTURUNKOD = null;
                    }
                    else if (!string.IsNullOrEmpty(markaBilgiReuqest.txtKesit))
                    {
                        lastikBilgileri.capListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                        lastikBilgileri.mevsimListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.desenListe = new ObservableCollection<MarkaBilgiResponse>();
                        detay.TXTURUNKOD = null;
                    }
                    else if (!string.IsNullOrEmpty(markaBilgiReuqest.txtTaban))
                    {
                        lastikBilgileri.kesitListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                        lastikBilgileri.capListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.mevsimListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.desenListe = new ObservableCollection<MarkaBilgiResponse>();
                        detay.TXTURUNKOD = null;
                    }
                    else if (!string.IsNullOrEmpty(markaBilgiReuqest.txtMarka))
                    {
                        lastikBilgileri.tabanListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                        lastikBilgileri.kesitListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.capListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.mevsimListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.desenListe = new ObservableCollection<MarkaBilgiResponse>();
                        detay.TXTURUNKOD = null;
                    }
                    else if (string.IsNullOrEmpty(markaBilgiReuqest.txtMarka))
                        lastikBilgileri.markaListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                }
                else
                {
                    markaListe = new ObservableCollection<MarkaBilgiResponse>();
                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");
                }

            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
            finally
            {
                IsBusy = false;
            }
        }


        public void Initializer()
        {
            tumunuEsitle = true;
            saklamaBaslikRequest = new SaklamaBaslikRequest() { BYTDURUM = 1, LNGDISTKOD = App.sessionInfo.lngDistkod, LNGFILOKOD = 0, LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod };
            detay = new SaklamaDetayRequest() { BYTDURUM = 1, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() };
            detayListe = new ObservableCollection<SaklamaDetayRequest>();
            detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 1, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() });
            detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 1, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() });
            detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 1, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() });
            detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 1, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() });
            detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 0, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() });
            detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 0, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() });
            markaBilgiReuqest = new MarkaBilgiRequest();
            lastikBilgileri = new LastikBilgiResponse();

            lngLastikYon = 0;
        }

        private async Task GotoMusteriPopUpAsync()
        {
            PopupNavigation.PushAsync(new MusteriAraPopUpPage());
        }
    }
}
