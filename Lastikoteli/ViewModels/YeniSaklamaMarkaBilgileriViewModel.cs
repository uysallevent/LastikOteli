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
using System.Collections.Generic;
using Lastikoteli.Helper.Abstract;
using Lastikoteli.Models.MiyaPortal;
using Lastikoteli.Models.Validator.FluentValidation;
using FluentValidation;
using System.Web;
using Lastikoteli.Helper;

namespace Lastikoteli.ViewModels
{
    public class YeniSaklamaMarkaBilgileriViewModel : BaseViewModel
    {
        private MarkaBilgiResponse _selectedMarka;
        public MarkaBilgiResponse selectedMarka
        {
            get
            {
                if (lngLastikYon == 1 && _selectedMarka != null)
                    onSag[0] = _selectedMarka.txtMarka;
                if (lngLastikYon == 2 && _selectedMarka != null && tumunuEsitle)
                {
                    onSol[0] = _selectedMarka.txtMarka;
                    onSag[0] = _selectedMarka.txtMarka;
                    arkaSag[0] = _selectedMarka.txtMarka;
                    arkaSol[0] = _selectedMarka.txtMarka;
                    digerSag[0] = _selectedMarka.txtMarka;
                    digerSol[0] = _selectedMarka.txtMarka;

                }
                if (lngLastikYon == 3 && _selectedMarka != null)
                    arkaSag[0] = _selectedMarka.txtMarka;
                if (lngLastikYon == 4 && _selectedMarka != null)
                    arkaSol[0] = _selectedMarka.txtMarka;
                if (lngLastikYon == 5 && _selectedMarka != null)
                    digerSag[0] = _selectedMarka.txtMarka;
                if (lngLastikYon == 6 && _selectedMarka != null)
                    digerSol[0] = _selectedMarka.txtMarka;
                return _selectedMarka;
            }
            set
            {
                SetProperty(ref _selectedMarka, value);
                if (_selectedMarka != null)
                {
                    markaBilgiReuqest.txtTaban = "";
                    markaBilgiReuqest.txtKesit = "";
                    markaBilgiReuqest.txtCap = "";
                    markaBilgiReuqest.txtMevsim = "";
                    markaBilgiReuqest.txtDesen = "";
                    markaBilgiReuqest.txtMarka = _selectedMarka.txtMarka;

                    MarkaBilgiGetirCommand.Execute(true);
                }
            }
        }


        private MarkaBilgiResponse _selectedTaban;
        public MarkaBilgiResponse selectedTaban
        {
            get
            {
                if (lngLastikYon == 1 && _selectedTaban != null)
                    onSag[1] = _selectedTaban.txtTaban;
                if (lngLastikYon == 2 && _selectedTaban != null && tumunuEsitle)
                {
                    onSol[1] = _selectedTaban.txtTaban;
                    onSag[1] = _selectedTaban.txtTaban;
                    arkaSol[1] = _selectedTaban.txtTaban;
                    arkaSag[1] = _selectedTaban.txtTaban;
                    digerSag[1] = _selectedTaban.txtTaban;
                    digerSol[1] = _selectedTaban.txtTaban;
                }
                if (lngLastikYon == 3 && _selectedTaban != null)
                    arkaSag[1] = _selectedTaban.txtTaban;
                if (lngLastikYon == 4 && _selectedTaban != null)
                    arkaSol[1] = _selectedTaban.txtTaban;
                if (lngLastikYon == 5 && _selectedTaban != null)
                    digerSag[1] = _selectedTaban.txtTaban;
                if (lngLastikYon == 6 && _selectedTaban != null)
                    digerSol[1] = _selectedTaban.txtTaban;
                return _selectedTaban;
            }
            set
            {
                SetProperty(ref _selectedTaban, value);
                if (_selectedTaban != null)
                {
                    markaBilgiReuqest.txtKesit = "";
                    markaBilgiReuqest.txtCap = "";
                    markaBilgiReuqest.txtMevsim = "";
                    markaBilgiReuqest.txtDesen = "";
                    markaBilgiReuqest.txtTaban = _selectedTaban.txtTaban;
                    MarkaBilgiGetirCommand.Execute(true);
                }
            }
        }


        private MarkaBilgiResponse _selectedKesit;
        public MarkaBilgiResponse selectedKesit
        {
            get
            {

                if (lngLastikYon == 1 && _selectedKesit != null)
                    onSag[2] = _selectedKesit.txtKesit;
                if (lngLastikYon == 2 && _selectedKesit != null && tumunuEsitle)
                {
                    onSol[2] = _selectedKesit.txtKesit;
                    onSag[2] = _selectedKesit.txtKesit;
                    arkaSol[2] = _selectedKesit.txtKesit;
                    arkaSag[2] = _selectedKesit.txtKesit;
                    digerSag[2] = _selectedKesit.txtKesit;
                    digerSol[2] = _selectedKesit.txtKesit;

                }
                if (lngLastikYon == 3 && _selectedKesit != null)
                    arkaSag[2] = _selectedKesit.txtKesit;
                if (lngLastikYon == 4 && _selectedKesit != null)
                    arkaSol[2] = _selectedKesit.txtKesit;
                if (lngLastikYon == 5 && _selectedKesit != null)
                    digerSag[2] = _selectedKesit.txtKesit;
                if (lngLastikYon == 6 && _selectedKesit != null)
                    digerSol[2] = _selectedKesit.txtKesit;
                return _selectedKesit;
            }
            set
            {
                SetProperty(ref _selectedKesit, value);
                if (_selectedKesit != null)
                {
                    markaBilgiReuqest.txtCap = "";
                    markaBilgiReuqest.txtMevsim = "";
                    markaBilgiReuqest.txtDesen = "";
                    markaBilgiReuqest.txtKesit = _selectedKesit.txtKesit;
                    MarkaBilgiGetirCommand.Execute(true);
                }
            }
        }


        private MarkaBilgiResponse _selectedCap;
        public MarkaBilgiResponse selectedCap
        {
            get
            {
                if (lngLastikYon == 1 && _selectedCap != null)
                    onSag[3] = _selectedCap.txtCap;
                if (lngLastikYon == 2 && _selectedCap != null && tumunuEsitle)
                {
                    onSol[3] = _selectedCap.txtCap;
                    onSag[3] = _selectedCap.txtCap;
                    arkaSol[3] = _selectedCap.txtCap;
                    arkaSag[3] = _selectedCap.txtCap;
                    digerSag[3] = _selectedCap.txtCap;
                    digerSol[3] = _selectedCap.txtCap;

                }
                if (lngLastikYon == 3 && _selectedCap != null)
                    arkaSag[3] = _selectedCap.txtCap;
                if (lngLastikYon == 4 && _selectedCap != null)
                    arkaSol[3] = _selectedCap.txtCap;
                if (lngLastikYon == 5 && _selectedCap != null)
                    digerSag[3] = _selectedCap.txtCap;
                if (lngLastikYon == 6 && _selectedCap != null)
                    digerSol[3] = _selectedCap.txtCap;
                return _selectedCap;
            }
            set
            {
                SetProperty(ref _selectedCap, value);
                if (_selectedCap != null)
                {
                    markaBilgiReuqest.txtMevsim = "";
                    markaBilgiReuqest.txtDesen = "";
                    markaBilgiReuqest.txtCap = _selectedCap.txtCap;
                    MarkaBilgiGetirCommand.Execute(true);
                }
            }
        }


        private MarkaBilgiResponse _selectedMevsim;
        public MarkaBilgiResponse selectedMevsim
        {
            get
            {
                if (lngLastikYon == 1 && _selectedMevsim != null)
                    onSag[4] = _selectedMevsim.txtMevsim;
                if (lngLastikYon == 2 && _selectedMevsim != null && tumunuEsitle)
                {
                    onSol[4] = _selectedMevsim.txtMevsim;
                    onSag[4] = _selectedMevsim.txtMevsim;
                    arkaSol[4] = _selectedMevsim.txtMevsim;
                    arkaSag[4] = _selectedMevsim.txtMevsim;
                    digerSag[4] = _selectedMevsim.txtMevsim;
                    digerSol[4] = _selectedMevsim.txtMevsim;
                }
                if (lngLastikYon == 3 && _selectedMevsim != null)
                    arkaSag[4] = _selectedMevsim.txtMevsim;
                if (lngLastikYon == 4 && _selectedMevsim != null)
                    arkaSol[4] = _selectedMevsim.txtMevsim;
                if (lngLastikYon == 5 && _selectedMevsim != null)
                    digerSag[4] = _selectedMevsim.txtMevsim;
                if (lngLastikYon == 6 && _selectedMevsim != null)
                    digerSol[4] = _selectedMevsim.txtMevsim;
                return _selectedMevsim;
            }
            set
            {
                SetProperty(ref _selectedMevsim, value);
                if (_selectedMevsim != null)
                {
                    markaBilgiReuqest.txtDesen = "";
                    markaBilgiReuqest.txtMevsim = _selectedMevsim.txtMevsim;
                    MarkaBilgiGetirCommand.Execute(true);
                }
            }
        }


        private MarkaBilgiResponse _selectedDesen;
        public MarkaBilgiResponse selectedDesen
        {
            get
            {
                if (lngLastikYon == 1 && _selectedDesen != null)
                    onSag[5] = _selectedDesen.txtDesen;
                if (lngLastikYon == 2 && _selectedDesen != null && tumunuEsitle)
                {
                    onSol[5] = _selectedDesen.txtDesen;
                    onSag[5] = _selectedDesen.txtDesen;
                    arkaSol[5] = _selectedDesen.txtDesen;
                    arkaSag[5] = _selectedDesen.txtDesen;
                    digerSol[5] = _selectedDesen.txtDesen;
                    digerSag[5] = _selectedDesen.txtDesen;
                }
                if (lngLastikYon == 3 && _selectedDesen != null)
                    arkaSag[5] = _selectedDesen.txtDesen;
                if (lngLastikYon == 4 && _selectedDesen != null)
                    arkaSol[5] = _selectedDesen.txtDesen;
                if (lngLastikYon == 5 && _selectedDesen != null)
                    digerSag[5] = _selectedDesen.txtDesen;
                if (lngLastikYon == 6 && _selectedDesen != null)
                    digerSol[5] = _selectedDesen.txtDesen;
                return _selectedDesen;
            }
            set
            {
                SetProperty(ref _selectedDesen, value);
                if (_selectedDesen != null)
                {
                    markaBilgiReuqest.txtDesen = HttpUtility.UrlEncode(_selectedDesen.txtDesen);
                    MarkaBilgiGetirCommand.Execute(true);
                }
            }
        }


        private int _selectedMarkaIndex;
        public int selectedMarkaIndex
        {
            get
            {
                return _selectedMarkaIndex;
            }
            set
            {
                _selectedMarkaIndex = value;
                OnPropertyChanged("selectedMarkaIndex");

            }
        }

        private int _selectedTabanIndex;
        public int selectedTabanIndex
        {
            get
            {
                return _selectedTabanIndex;
            }
            set
            {
                _selectedTabanIndex = value;

                OnPropertyChanged("selectedTabanIndex");

            }
        }

        private int _selectedKesitIndex;
        public int selectedKesitIndex
        {
            get
            {

                return _selectedKesitIndex;
            }
            set
            {
                _selectedKesitIndex = value;
                OnPropertyChanged("selectedKesitIndex");

            }
        }

        private int _selectedCapIndex;
        public int selectedCapIndex
        {
            get
            {
                return _selectedCapIndex;
            }
            set
            {
                _selectedCapIndex = value;

                OnPropertyChanged("selectedCapIndex");
            }
        }

        private int _selectedMevsimIndex;
        public int selectedMevsimIndex
        {
            get
            {
                return _selectedMevsimIndex;
            }
            set
            {
                _selectedMevsimIndex = value;

                OnPropertyChanged("selectedMevsimIndex");

            }
        }

        private int _selectedDesenIndex;
        public int selectedDesenIndex
        {
            get
            {
                return _selectedDesenIndex;
            }
            set
            {
                _selectedDesenIndex = value;
                OnPropertyChanged("selectedDesenIndex");

            }
        }


        public decimal dblDisDerinligi { get; set; }


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
        /// <summary>
        /// 1-ÖnSağ
        /// 2-ÖnSol
        /// 3-ArkaSağ
        /// 4-ArkaSol
        /// 5-DiğerSağ1
        /// 6-DiğerSol1
        /// </summary>
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


        //Saklama ekleme ekranında lastik butonlarına tıklama ile lastik 
        //detay bilgilerinin ön sola eşitlenmesini engellemek için kullanılan property
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


        private Randevu _randevuBilgi;
        public Randevu randevuBilgi
        {
            get { return _randevuBilgi; }
            set
            {
                _randevuBilgi = value;
                OnPropertyChanged("randevuBilgi");
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
                    //Ön sol lastik seçili ise tüm lastik bilgileri aynı olacak şekilde ayarlanır
                    if ((lngLastikYon == 2 && tumunuEsitle) || lngLastikYon == i + 1)
                    {
                        detayListe[i].bytUrunTip = _detay.bytUrunTip;
                        detayListe[i].txtDisDerinligi = _detay.txtDisDerinligi;//Model içerisinde string alınan alan dblDisDerinligi alanına parsa ediliyor
                        detayListe[i].LNGDEPOSIRAKOD = _detay.LNGDEPOSIRAKOD;
                        detayListe[i].LNGLASTIKDURUM = (_detay.ISOTL == 0) ? 1 : 3; //1 lastiğin saklamada olma durumu. 3 lastiğin ÖTL olma durumu
                        detayListe[i].LNGLASTIKTIP = i + 1;
                        detayListe[i].LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                        detayListe[i].LNGURUNTIP = _detay.LNGURUNTIP;
                        detayListe[i].TXTRAFKOLAYKOD = _detay.TXTRAFKOLAYKOD;
                        detayListe[i].TXTDOTFABRIKA = _detay.TXTDOTFABRIKA;
                        detayListe[i].TXTDOTHAFTA = _detay.TXTDOTHAFTA;
                        detayListe[i].TXTDOTURETIM = _detay.TXTDOTURETIM;
                        detayListe[i].BYTHAVUZDA = (string.IsNullOrEmpty(_detay.TXTRAFKOLAYKOD)) ? 1 : 0;
                        if (!_detay.bytUrunTip)
                            detayListe[i].TXTURUNKOD = _detay.TXTURUNKOD;
                        else
                        {
                            detayListe[i].kullaniciUrunBilgileri.TXTMARKA = _detay.kullaniciUrunBilgileri.TXTMARKA;
                            detayListe[i].kullaniciUrunBilgileri.TXTTABAN = _detay.kullaniciUrunBilgileri.TXTTABAN;
                            detayListe[i].kullaniciUrunBilgileri.TXTKESIT = _detay.kullaniciUrunBilgileri.TXTKESIT;
                            detayListe[i].kullaniciUrunBilgileri.TXTCAP = _detay.kullaniciUrunBilgileri.TXTCAP;
                            detayListe[i].kullaniciUrunBilgileri.TXTMEVSIM = _detay.kullaniciUrunBilgileri.TXTMEVSIM;
                            detayListe[i].kullaniciUrunBilgileri.TXTDESEN = _detay.kullaniciUrunBilgileri.TXTDESEN;
                            detayListe[i].kullaniciUrunBilgileri.LNGLASTIKTIP = lngLastikYon;
                            detayListe[i].kullaniciUrunBilgileri.LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                        }
                    }

                    if (lngLastikYon == i + 1)
                    {
                        detayListe[i].ISOTL = _detay.ISOTL;
                        detayListe[i].BYTDURUM = _detay.BYTDURUM;
                        detayListe[i].TXTACIKLAMA = _detay.TXTACIKLAMA;
                        detayListe[i].kullaniciUrunBilgileri.BYTDURUM = _detay.BYTDURUM;

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


        #region SeciliMarkaIndexler
        public string[] onSol { get; set; }
        public string[] onSag { get; set; }
        public string[] arkaSol { get; set; }
        public string[] arkaSag { get; set; }
        public string[] digerSol { get; set; }
        public string[] digerSag { get; set; }
        #endregion


        public ICommand MarkaBilgiGetirCommand { get; set; }
        public ICommand DisDerinligiKontrolCommand { get; set; }
        public ICommand secilenLastikCommand { get; set; }
        public ICommand saklamayaAlCommand { get; set; }
        public ICommand GotoMusteriPopUpCommand { get; set; }
        public ICommand RafKolayKodKontrolCommand { get; set; }
        public ICommand PlakaKontrolCommand { get; set; }
        public ICommand AracUzerindekilerCommand { get; set; }
        public ICommand HaftaKontrolCommand { get; set; }

        public YeniSaklamaMarkaBilgileriViewModel(INavigation navigation)
        {
            Initializer();
            _navigation = navigation;
            _doubleClickControl = new DoubleClickControl(navigation);
            MarkaBilgiGetirCommand = new Command(async () => await MarkaBilgiGetirAsync());
            DisDerinligiKontrolCommand = new Command(async (x) => await DisDerinligiAsync(x));
            secilenLastikCommand = new Command((x) => secilenLastik(x));
            saklamayaAlCommand = new Command(async () => await saklamayaAlAsync());
            GotoMusteriPopUpCommand = new Command(async () => await GotoMusteriPopUpAsync());
            RafKolayKodKontrolCommand = new Command(async (x) => await RafKolayKodKontrolAsync(x));
            PlakaKontrolCommand = new Command(async (x) => await PlakaKontrolAsync(x));
            AracUzerindekilerCommand = new Command(async (x) => await AracUzerindekilerAsync(x));
            HaftaKontrolCommand = new Command((x) => HaftaKontrolAsync(x));
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
            MessagingCenter.Subscribe<IsListesiViewModel, Randevu>(this, "IsEmriYeniSaklama", (s, m) =>
            {
                saklamaBaslikRequest.TXTPLAKA = m.TXTPLAKA;
                randevuBilgi = m;
                OnPropertyChanged("saklamaBaslikRequest");
                Device.BeginInvokeOnMainThread(async () => await PlakaKontrolAsync(m.TXTPLAKA));
            });

        }

        private void HaftaKontrolAsync(object x)
        {
            if (x.ToString().Length != 4)
            {
                DependencyService.Get<IToastService>().ToastMessage($"Hafta bilgisi 4 karakter olmalıdır");
                detay.TXTDOTHAFTA = null;
                OnPropertyChanged("detay");
            }
        }

        private async Task AracUzerindekilerAsync(object x)
        {
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                var result = await SaklamaService.AracUzerindekileriGetir(new SaklamaPlakaSorgulaRequest
                {
                    lngDistKod = App.sessionInfo.lngDistkod,
                    txtPlaka = x.ToString()
                });

                if (result.StatusCode != 500 && result.Result.Count > 0)
                {
                    for (int i = 0; i < result.Result.Count; i++)
                    {
                        if (result.Result[i].lngLastikTip == 1)
                        {
                            lastikBilgileri.markaListe = new ObservableCollection<MarkaBilgiResponse>(result.Result[i].markaList);
                            lastikBilgileri.tabanListe = new ObservableCollection<MarkaBilgiResponse>(result.Result[i].tabanList);
                            lastikBilgileri.kesitListe = new ObservableCollection<MarkaBilgiResponse>(result.Result[i].kesitList);
                            lastikBilgileri.capListe = new ObservableCollection<MarkaBilgiResponse>(result.Result[i].capList);
                            lastikBilgileri.mevsimListe = new ObservableCollection<MarkaBilgiResponse>(result.Result[i].mevsimList);
                            lastikBilgileri.desenListe = new ObservableCollection<MarkaBilgiResponse>(result.Result[i].desenList);
                        }
                    }
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

        private async Task PlakaKontrolAsync(object x)
        {
            try
            {
                if (IsBusy)
                    return;
                IsBusy = true;
                var result = await SaklamaService.PlakaSorgula(new SaklamaPlakaSorgulaRequest
                {
                    lngDistKod = App.sessionInfo.lngDistkod,
                    txtPlaka = x.ToString()
                });

                if (result.StatusCode != 500)
                {
                    _saklamaBaslikRequest.LNGMUSTERIKOD = result.Result.lngMusteriKod;
                    _saklamaBaslikRequest.TXTMUSTERIUNVAN = result.Result.txtUnvan;
                    _saklamaBaslikRequest.TXTMUSTERIERPKOD = result.Result.txtErpKod;
                    _saklamaBaslikRequest.TXTTCKIMLIKNO = result.Result.txtTcKimlikNo;
                    _saklamaBaslikRequest.TXTVN = result.Result.txtVN;
                    _saklamaBaslikRequest.TXTSOFORADSOYAD = result.Result.txtKullaniciAdiSoyadi;
                    _saklamaBaslikRequest.TXTCEPTEL = result.Result.txtCepTelNo;
                    _saklamaBaslikRequest.TXTEMAIL = result.Result.txtEmail;
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
                    OnPropertyChanged("detay");
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
                    else
                        x.TXTURUNKOD = null;

                });
                saklamaBaslikRequest.Tblsaklamadetay = detayListe.Where(x => x.BYTDURUM == 1).ToList();

                if (MuhtelifKayitKontrol(saklamaBaslikRequest))
                {
                    var soru = await App.Current.MainPage.DisplayPromptAsync("Uyarı", "Muhtelif Lasitk Adedi Girin", "Tamam", "İptal", "Max 6 lastik girebilirsiniz", 1, keyboard: Keyboard.Numeric);

                    if (!string.IsNullOrEmpty(soru))
                    {
                        saklamaBaslikRequest.LNGADET = Convert.ToInt32(soru);
                        saklamaBaslikRequest.Tblsaklamadetay.ForEach(x => x.TXTACIKLAMA = "Muhtelif kayıt");
                    }
                    else
                        return;
                }

                var validationresult = saklamayaAlValidator.Validate(saklamaBaslikRequest);
                if (!validationresult.IsValid)
                {
                    await App.Current.MainPage.DisplayAlert("Uyarı", $"{String.Join("", validationresult.Errors.Select(x => "- " + x.ErrorMessage + Environment.NewLine).Distinct())}", "Tamam");
                    return;
                }

                if (IsBusy)
                    return;

                IsBusy = true;
                var result = await SaklamaService.YeniSaklamaEkle(saklamaBaslikRequest);

                if (result.StatusCode != 500 && result.Result > 0)
                {
                    await App.Current.MainPage.DisplayAlert("Uyarı", $"Lastikler {result.Result} saklama kodu ile kaydedilmiştir", "Tamam");

                    Initializer();
                    IsBusy = false;
                    MarkaBilgiGetirCommand.Execute(true);

                    MessagingCenter.Send(this, "tabPageBack");
                    if (randevuBilgi != null)
                    {
                        IsBusy = false;
                        await IsEmriDurumDegistir();
                    }

                }
                else
                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");
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

        private void secilenLastik(object x)
        {
            tumunuEsitle = false;
            var oncekiLastikYon = lngLastikYon;
            lngLastikYon = Convert.ToInt32(x);

            //devam butonu ile yada marka bilgiler güncelleme sayfası görünür olduğunda yön ürün kodu kontrolüne takılmaması için 0 gönderiliyor.0 olma durumu 2 olma durumu ile aynıdır
            if (lngLastikYon == 0)
            {
                if (!string.IsNullOrEmpty(onSol[0]))
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        tumunuEsitle = false;
                        for (int i = 0; i < onSol.Length; i++)
                        {
                            markaBilgiReuqest.txtDesen = (i == 5) ? onSol[5] : "";
                            markaBilgiReuqest.txtMevsim = (i == 4 || i == 5) ? onSol[4] : "";
                            markaBilgiReuqest.txtCap = (i == 3 || i == 4 || i == 5) ? onSol[3] : "";
                            markaBilgiReuqest.txtKesit = (i == 2 || i == 3 || i == 4 || i == 5) ? onSol[2] : "";
                            markaBilgiReuqest.txtTaban = (i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? onSol[1] : "";
                            markaBilgiReuqest.txtMarka = (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? onSol[0] : "";

                            IsBusy = false;
                            await MarkaBilgiGetirAsync();

                            if (i == 0)
                                selectedMarkaIndex = lastikBilgileri.markaListe.IndexOf(lastikBilgileri.markaListe.FirstOrDefault(y => y.txtMarka == onSol[i]));
                            if (i == 1)
                                selectedTabanIndex = lastikBilgileri.tabanListe.IndexOf(lastikBilgileri.tabanListe.FirstOrDefault(y => y.txtTaban == onSol[i]));
                            if (i == 2)
                                selectedKesitIndex = lastikBilgileri.kesitListe.IndexOf(lastikBilgileri.kesitListe.FirstOrDefault(y => y.txtKesit == onSol[i]));
                            if (i == 3)
                                selectedCapIndex = lastikBilgileri.capListe.IndexOf(lastikBilgileri.capListe.FirstOrDefault(y => y.txtCap == onSol[i]));
                            if (i == 4)
                                selectedMevsimIndex = lastikBilgileri.mevsimListe.IndexOf(lastikBilgileri.mevsimListe.FirstOrDefault(y => y.txtMevsim == onSol[i]));
                            if (i == 5)
                                selectedDesenIndex = lastikBilgileri.desenListe.IndexOf(lastikBilgileri.desenListe.FirstOrDefault(y => y.txtDesen == onSol[i]));
                        }
                        tumunuEsitle = true;
                    });
                else if (detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
                {
                    selectedMarkaIndex = -1;
                    selectedTabanIndex = -1;
                    selectedKesitIndex = -1;
                    selectedCapIndex = -1;
                    selectedMevsimIndex = -1;
                    selectedDesenIndex = -1;
                }

                lngLastikYon = 2;
            }
            detay = detayListe[lngLastikYon - 1];

            if (lngLastikYon == 1)
            {
                if (!string.IsNullOrEmpty(onSol[0]) && detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        tumunuEsitle = false;

                        for (int i = 0; i < onSag.Length; i++)
                        {
                            markaBilgiReuqest.txtDesen = (i == 5) ? onSag[5] : "";
                            markaBilgiReuqest.txtMevsim = (i == 4 || i == 5) ? onSag[4] : "";
                            markaBilgiReuqest.txtCap = (i == 3 || i == 4 || i == 5) ? onSag[3] : "";
                            markaBilgiReuqest.txtKesit = (i == 2 || i == 3 || i == 4 || i == 5) ? onSag[2] : "";
                            markaBilgiReuqest.txtTaban = (i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? onSag[1] : "";
                            markaBilgiReuqest.txtMarka = (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? onSag[0] : "";
                            IsBusy = false;
                            await MarkaBilgiGetirAsync();

                            if (i == 0)
                                selectedMarkaIndex = lastikBilgileri.markaListe.IndexOf(lastikBilgileri.markaListe.FirstOrDefault(y => y.txtMarka == onSag[i]));
                            if (i == 1)
                                selectedTabanIndex = lastikBilgileri.tabanListe.IndexOf(lastikBilgileri.tabanListe.FirstOrDefault(y => y.txtTaban == onSag[i]));
                            if (i == 2)
                                selectedKesitIndex = lastikBilgileri.kesitListe.IndexOf(lastikBilgileri.kesitListe.FirstOrDefault(y => y.txtKesit == onSag[i]));
                            if (i == 3)
                                selectedCapIndex = lastikBilgileri.capListe.IndexOf(lastikBilgileri.capListe.FirstOrDefault(y => y.txtCap == onSag[i]));
                            if (i == 4)
                                selectedMevsimIndex = lastikBilgileri.mevsimListe.IndexOf(lastikBilgileri.mevsimListe.FirstOrDefault(y => y.txtMevsim == onSag[i]));
                            if (i == 5)
                                selectedDesenIndex = lastikBilgileri.desenListe.IndexOf(lastikBilgileri.desenListe.FirstOrDefault(y => y.txtDesen == onSag[i]));
                        }
                        tumunuEsitle = true;
                    });
                else if (detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
                {
                    selectedMarkaIndex = -1;
                    selectedTabanIndex = -1;
                    selectedKesitIndex = -1;
                    selectedCapIndex = -1;
                    selectedMevsimIndex = -1;
                    selectedDesenIndex = -1;
                }
            }

            if (lngLastikYon == 2)
            {
                if (!string.IsNullOrEmpty(onSol[0]) && detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        tumunuEsitle = false;
                        for (int i = 0; i < onSol.Length; i++)
                        {
                            markaBilgiReuqest.txtDesen = (i == 5) ? onSol[5] : "";
                            markaBilgiReuqest.txtMevsim = (i == 4 || i == 5) ? onSol[4] : "";
                            markaBilgiReuqest.txtCap = (i == 3 || i == 4 || i == 5) ? onSol[3] : "";
                            markaBilgiReuqest.txtKesit = (i == 2 || i == 3 || i == 4 || i == 5) ? onSol[2] : "";
                            markaBilgiReuqest.txtTaban = (i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? onSol[1] : "";
                            markaBilgiReuqest.txtMarka = (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? onSol[0] : "";

                            IsBusy = false;
                            await MarkaBilgiGetirAsync();

                            if (i == 0)
                                selectedMarkaIndex = lastikBilgileri.markaListe.IndexOf(lastikBilgileri.markaListe.FirstOrDefault(y => y.txtMarka == onSol[i]));
                            if (i == 1)
                                selectedTabanIndex = lastikBilgileri.tabanListe.IndexOf(lastikBilgileri.tabanListe.FirstOrDefault(y => y.txtTaban == onSol[i]));
                            if (i == 2)
                                selectedKesitIndex = lastikBilgileri.kesitListe.IndexOf(lastikBilgileri.kesitListe.FirstOrDefault(y => y.txtKesit == onSol[i]));
                            if (i == 3)
                                selectedCapIndex = lastikBilgileri.capListe.IndexOf(lastikBilgileri.capListe.FirstOrDefault(y => y.txtCap == onSol[i]));
                            if (i == 4)
                                selectedMevsimIndex = lastikBilgileri.mevsimListe.IndexOf(lastikBilgileri.mevsimListe.FirstOrDefault(y => y.txtMevsim == onSol[i]));
                            if (i == 5)
                                selectedDesenIndex = lastikBilgileri.desenListe.IndexOf(lastikBilgileri.desenListe.FirstOrDefault(y => y.txtDesen == onSol[i]));
                        }
                        tumunuEsitle = true;
                    });
                else if (detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
                {
                    selectedMarkaIndex = -1;
                    selectedTabanIndex = -1;
                    selectedKesitIndex = -1;
                    selectedCapIndex = -1;
                    selectedMevsimIndex = -1;
                    selectedDesenIndex = -1;
                }
            }

            if (lngLastikYon == 3)
            {
                if (!string.IsNullOrEmpty(arkaSag[0]) && detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        tumunuEsitle = false;
                        for (int i = 0; i < arkaSag.Length; i++)
                        {
                            markaBilgiReuqest.txtDesen = (i == 5) ? arkaSag[5] : "";
                            markaBilgiReuqest.txtMevsim = (i == 4 || i == 5) ? arkaSag[4] : "";
                            markaBilgiReuqest.txtCap = (i == 3 || i == 4 || i == 5) ? arkaSag[3] : "";
                            markaBilgiReuqest.txtKesit = (i == 2 || i == 3 || i == 4 || i == 5) ? arkaSag[2] : "";
                            markaBilgiReuqest.txtTaban = (i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? arkaSag[1] : "";
                            markaBilgiReuqest.txtMarka = (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? arkaSag[0] : "";

                            IsBusy = false;
                            await MarkaBilgiGetirAsync();

                            if (i == 0)
                                selectedMarkaIndex = lastikBilgileri.markaListe.IndexOf(lastikBilgileri.markaListe.FirstOrDefault(y => y.txtMarka == arkaSag[i]));
                            if (i == 1)
                                selectedTabanIndex = lastikBilgileri.tabanListe.IndexOf(lastikBilgileri.tabanListe.FirstOrDefault(y => y.txtTaban == arkaSag[i]));
                            if (i == 2)
                                selectedKesitIndex = lastikBilgileri.kesitListe.IndexOf(lastikBilgileri.kesitListe.FirstOrDefault(y => y.txtKesit == arkaSag[i]));
                            if (i == 3)
                                selectedCapIndex = lastikBilgileri.capListe.IndexOf(lastikBilgileri.capListe.FirstOrDefault(y => y.txtCap == arkaSag[i]));
                            if (i == 4)
                                selectedMevsimIndex = lastikBilgileri.mevsimListe.IndexOf(lastikBilgileri.mevsimListe.FirstOrDefault(y => y.txtMevsim == arkaSag[i]));
                            if (i == 5)
                                selectedDesenIndex = lastikBilgileri.desenListe.IndexOf(lastikBilgileri.desenListe.FirstOrDefault(y => y.txtDesen == arkaSag[i]));
                        }
                        tumunuEsitle = true;
                    });
                else if (detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
                {
                    selectedMarkaIndex = -1;
                    selectedTabanIndex = -1;
                    selectedKesitIndex = -1;
                    selectedCapIndex = -1;
                    selectedMevsimIndex = -1;
                    selectedDesenIndex = -1;
                }
            }

            if (lngLastikYon == 4)
            {
                if (!string.IsNullOrEmpty(arkaSol[0]) && detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        tumunuEsitle = false;
                        for (int i = 0; i < arkaSol.Length; i++)
                        {
                            markaBilgiReuqest.txtDesen = (i == 5) ? arkaSol[5] : "";
                            markaBilgiReuqest.txtMevsim = (i == 4 || i == 5) ? arkaSol[4] : "";
                            markaBilgiReuqest.txtCap = (i == 3 || i == 4 || i == 5) ? arkaSol[3] : "";
                            markaBilgiReuqest.txtKesit = (i == 2 || i == 3 || i == 4 || i == 5) ? arkaSol[2] : "";
                            markaBilgiReuqest.txtTaban = (i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? arkaSol[1] : "";
                            markaBilgiReuqest.txtMarka = (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? arkaSol[0] : "";

                            IsBusy = false;
                            await MarkaBilgiGetirAsync();

                            if (i == 0)
                                selectedMarkaIndex = lastikBilgileri.markaListe.IndexOf(lastikBilgileri.markaListe.FirstOrDefault(y => y.txtMarka == arkaSol[i]));
                            if (i == 1)
                                selectedTabanIndex = lastikBilgileri.tabanListe.IndexOf(lastikBilgileri.tabanListe.FirstOrDefault(y => y.txtTaban == arkaSol[i]));
                            if (i == 2)
                                selectedKesitIndex = lastikBilgileri.kesitListe.IndexOf(lastikBilgileri.kesitListe.FirstOrDefault(y => y.txtKesit == arkaSol[i]));
                            if (i == 3)
                                selectedCapIndex = lastikBilgileri.capListe.IndexOf(lastikBilgileri.capListe.FirstOrDefault(y => y.txtCap == arkaSol[i]));
                            if (i == 4)
                                selectedMevsimIndex = lastikBilgileri.mevsimListe.IndexOf(lastikBilgileri.mevsimListe.FirstOrDefault(y => y.txtMevsim == arkaSol[i]));
                            if (i == 5)
                                selectedDesenIndex = lastikBilgileri.desenListe.IndexOf(lastikBilgileri.desenListe.FirstOrDefault(y => y.txtDesen == arkaSol[i]));
                        }
                        tumunuEsitle = true;
                    });
                else if (detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
                {
                    selectedMarkaIndex = -1;
                    selectedTabanIndex = -1;
                    selectedKesitIndex = -1;
                    selectedCapIndex = -1;
                    selectedMevsimIndex = -1;
                    selectedDesenIndex = -1;
                }
            }

            if (lngLastikYon == 5)
            {
                if (!string.IsNullOrEmpty(digerSag[0]) && detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        tumunuEsitle = false;
                        for (int i = 0; i < digerSag.Length; i++)
                        {
                            markaBilgiReuqest.txtDesen = (i == 5) ? digerSag[5] : "";
                            markaBilgiReuqest.txtMevsim = (i == 4 || i == 5) ? digerSag[4] : "";
                            markaBilgiReuqest.txtCap = (i == 3 || i == 4 || i == 5) ? digerSag[3] : "";
                            markaBilgiReuqest.txtKesit = (i == 2 || i == 3 || i == 4 || i == 5) ? digerSag[2] : "";
                            markaBilgiReuqest.txtTaban = (i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? digerSag[1] : "";
                            markaBilgiReuqest.txtMarka = (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? digerSag[0] : "";

                            IsBusy = false;
                            await MarkaBilgiGetirAsync();

                            if (i == 0)
                                selectedMarkaIndex = lastikBilgileri.markaListe.IndexOf(lastikBilgileri.markaListe.FirstOrDefault(y => y.txtMarka == digerSag[i]));
                            if (i == 1)
                                selectedTabanIndex = lastikBilgileri.tabanListe.IndexOf(lastikBilgileri.tabanListe.FirstOrDefault(y => y.txtTaban == digerSag[i]));
                            if (i == 2)
                                selectedKesitIndex = lastikBilgileri.kesitListe.IndexOf(lastikBilgileri.kesitListe.FirstOrDefault(y => y.txtKesit == digerSag[i]));
                            if (i == 3)
                                selectedCapIndex = lastikBilgileri.capListe.IndexOf(lastikBilgileri.capListe.FirstOrDefault(y => y.txtCap == digerSag[i]));
                            if (i == 4)
                                selectedMevsimIndex = lastikBilgileri.mevsimListe.IndexOf(lastikBilgileri.mevsimListe.FirstOrDefault(y => y.txtMevsim == digerSag[i]));
                            if (i == 5)
                                selectedDesenIndex = lastikBilgileri.desenListe.IndexOf(lastikBilgileri.desenListe.FirstOrDefault(y => y.txtDesen == digerSag[i]));
                        }
                        tumunuEsitle = true;
                    });
                else if (detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
                {
                    selectedMarkaIndex = -1;
                    selectedTabanIndex = -1;
                    selectedKesitIndex = -1;
                    selectedCapIndex = -1;
                    selectedMevsimIndex = -1;
                    selectedDesenIndex = -1;
                }
            }

            if (lngLastikYon == 6)
            {
                if (!string.IsNullOrEmpty(digerSol[0]) && detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        tumunuEsitle = false;
                        for (int i = 0; i < digerSol.Length; i++)
                        {
                            markaBilgiReuqest.txtDesen = (i == 5) ? digerSol[5] : "";
                            markaBilgiReuqest.txtMevsim = (i == 4 || i == 5) ? digerSol[4] : "";
                            markaBilgiReuqest.txtCap = (i == 3 || i == 4 || i == 5) ? digerSol[3] : "";
                            markaBilgiReuqest.txtKesit = (i == 2 || i == 3 || i == 4 || i == 5) ? digerSol[2] : "";
                            markaBilgiReuqest.txtTaban = (i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? digerSol[1] : "";
                            markaBilgiReuqest.txtMarka = (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? digerSol[0] : "";

                            IsBusy = false;
                            await MarkaBilgiGetirAsync();

                            if (i == 0)
                                selectedMarkaIndex = lastikBilgileri.markaListe.IndexOf(lastikBilgileri.markaListe.FirstOrDefault(y => y.txtMarka == digerSol[i]));
                            if (i == 1)
                                selectedTabanIndex = lastikBilgileri.tabanListe.IndexOf(lastikBilgileri.tabanListe.FirstOrDefault(y => y.txtTaban == digerSol[i]));
                            if (i == 2)
                                selectedKesitIndex = lastikBilgileri.kesitListe.IndexOf(lastikBilgileri.kesitListe.FirstOrDefault(y => y.txtKesit == digerSol[i]));
                            if (i == 3)
                                selectedCapIndex = lastikBilgileri.capListe.IndexOf(lastikBilgileri.capListe.FirstOrDefault(y => y.txtCap == digerSol[i]));
                            if (i == 4)
                                selectedMevsimIndex = lastikBilgileri.mevsimListe.IndexOf(lastikBilgileri.mevsimListe.FirstOrDefault(y => y.txtMevsim == digerSol[i]));
                            if (i == 5)
                                selectedDesenIndex = lastikBilgileri.desenListe.IndexOf(lastikBilgileri.desenListe.FirstOrDefault(y => y.txtDesen == digerSol[i]));
                        }
                        tumunuEsitle = true;
                    });
                else if (detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
                {
                    selectedMarkaIndex = -1;
                    selectedTabanIndex = -1;
                    selectedKesitIndex = -1;
                    selectedCapIndex = -1;
                    selectedMevsimIndex = -1;
                    selectedDesenIndex = -1;
                }
            }
            tumunuEsitle = true;
            MessagingCenter.Send(this, "detayScrollUp");
        }

        private async Task DisDerinligiAsync(object x)
        {
            try
            {
                if (string.IsNullOrEmpty(x.ToString()))
                    return;

                if (IsBusy)
                    return;

                IsBusy = true;

                decimal dblIstenenDisDer;
                var bytDisDerinligi = decimal.TryParse(x.ToString().Replace(".",","), out dblIstenenDisDer);
                if (dblDisDerinligi > 0)
                {
                    if (bytDisDerinligi && (dblIstenenDisDer < dblDisDerinligi))
                        DependencyService.Get<IToastService>().ToastMessage("Girdiğiniz değer yasal diş derinliğinin altındadır");
                    return;
                }

                var result = await SaklamaService.YasalDisDerinligiGetir();

                if (result.StatusCode != 500)
                {
                    decimal dblYasalDisDer;
                    var bytYasalDisDerinligi = decimal.TryParse(result.Result.ToString(), out dblYasalDisDer);
                    dblDisDerinligi = dblYasalDisDer;

                    if (bytDisDerinligi && bytYasalDisDerinligi && (dblIstenenDisDer < dblYasalDisDer))
                        DependencyService.Get<IToastService>().ToastMessage("Girdiğiniz değer yasal diş derinliğinin altındadır");

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
                        lastikBilgileri.desenListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.mevsimListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                        detay.TXTURUNKOD = null;
                    }
                    else if (!string.IsNullOrEmpty(markaBilgiReuqest.txtKesit))
                    {
                        lastikBilgileri.capListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                        lastikBilgileri.mevsimListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.desenListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.capListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                        detay.TXTURUNKOD = null;
                    }
                    else if (!string.IsNullOrEmpty(markaBilgiReuqest.txtTaban))
                    {

                        lastikBilgileri.capListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.mevsimListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.desenListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.kesitListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                        detay.TXTURUNKOD = null;

                    }
                    else if (!string.IsNullOrEmpty(markaBilgiReuqest.txtMarka))
                    {
                        lastikBilgileri.kesitListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.capListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.mevsimListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.desenListe = new ObservableCollection<MarkaBilgiResponse>();
                        lastikBilgileri.tabanListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                        detay.TXTURUNKOD = null;

                    }
                    else if (string.IsNullOrEmpty(markaBilgiReuqest.txtMarka))
                    {
                        lastikBilgileri.markaListe = new ObservableCollection<MarkaBilgiResponse>(result.Result);
                    }
                }
                else

                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");


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

        private async Task IsEmriDurumDegistir()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var result = await IsEmriService.IsEmriDurumuTamamla(new IsEmriDurumGuncelleRequest
                {
                    bytDurum = 2,
                    lngDistKod = App.sessionInfo.lngDistkod,
                    lngKod = randevuBilgi.LNGKOD,
                    lngTip = 2
                });

                if (result.StatusCode != 500 && result.Result)
                {
                    MessagingCenter.Send(this, "refreshList");
                    Device.BeginInvokeOnMainThread(async () => await _navigation.PopAsync(true));
                }
                else
                    await App.Current.MainPage.DisplayAlert("Uyarı", result.ErrorMessage, "Tamam");
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
            lngLastikYon = 2;
            dblDisDerinligi = 0;
            tumunuEsitle = true;
            saklamaBaslikRequest = new SaklamaBaslikRequest() { BYTDURUM = 1, LNGDISTKOD = App.sessionInfo.lngDistkod, LNGFILOKOD = 0, LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod };
            detayListe = new ObservableCollection<SaklamaDetayRequest>();
            detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 1, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() });
            detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 1, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() });
            detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 1, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() });
            detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 1, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() });
            detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 0, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() });
            detayListe.Add(new SaklamaDetayRequest() { BYTDURUM = 0, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() });
            detay = new SaklamaDetayRequest() { BYTDURUM = 1, BYTHAVUZDA = 1, LNGURUNTIP = 0, kullaniciUrunBilgileri = new KullaniciUrunRequest() };
            markaBilgiReuqest = new MarkaBilgiRequest();
            lastikBilgileri = new LastikBilgiResponse();
            onSol = new string[] { "", "", "", "", "", "" };
            onSag = new string[] { "", "", "", "", "", "" };
            arkaSol = new string[] { "", "", "", "", "", "" };
            arkaSag = new string[] { "", "", "", "", "", "" };
            digerSol = new string[] { "", "", "", "", "", "" };
            digerSag = new string[] { "", "", "", "", "", "" };
        }

        private async Task GotoMusteriPopUpAsync()
        {
            await _doubleClickControl.PopUpPushAsync(new MusteriAraPopUpPage());
            //PopupNavigation.PushAsync(new MusteriAraPopUpPage());
        }

        private bool MuhtelifKayitKontrol(SaklamaBaslikRequest request)
        {
            bool brisaUrunKontrol = false, kullaniciUrunKontrol = false;

            brisaUrunKontrol = request.Tblsaklamadetay.Any(x => !string.IsNullOrEmpty(x.TXTURUNKOD));

            if (request.Tblsaklamadetay.Any(x => x.kullaniciUrunBilgileri != null))
            {
                kullaniciUrunKontrol = request.Tblsaklamadetay.Where(x => x.kullaniciUrunBilgileri != null).Any(x =>
                 !string.IsNullOrEmpty(x.kullaniciUrunBilgileri.TXTMARKA) &&
                 !string.IsNullOrEmpty(x.kullaniciUrunBilgileri.TXTTABAN) &&
                 !string.IsNullOrEmpty(x.kullaniciUrunBilgileri.TXTKESIT) &&
                 !string.IsNullOrEmpty(x.kullaniciUrunBilgileri.TXTCAP) &&
                 !string.IsNullOrEmpty(x.kullaniciUrunBilgileri.TXTMEVSIM) &&
                 !string.IsNullOrEmpty(x.kullaniciUrunBilgileri.TXTDESEN)
            );
            }

            return (!brisaUrunKontrol && !kullaniciUrunKontrol) ? true : false;
        }
    }
}
