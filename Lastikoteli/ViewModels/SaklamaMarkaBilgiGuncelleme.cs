using Lastikoteli.Helper.Abstract;
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
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class SaklamaMarkaBilgiGuncelleme : BaseViewModel
    {
        public YeniSaklamaMarkaBilgi Page { get; set; }

        private MarkaBilgiResponse _selectedMarka;
        public MarkaBilgiResponse selectedMarka
        {
            get
            {
                if (lngLastikYon == 1 && _selectedMarka != null)
                    onSag[0] = _selectedMarka.txtMarka;
                if (lngLastikYon == 2 && _selectedMarka != null)
                    onSol[0] = _selectedMarka.txtMarka;
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
                if (lngLastikYon == 2 && _selectedTaban != null)
                    onSol[1] = _selectedTaban.txtTaban;
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
                if (lngLastikYon == 2 && _selectedKesit != null)
                    onSol[2] = _selectedKesit.txtKesit;
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
                if (lngLastikYon == 2 && _selectedCap != null)
                    onSol[3] = _selectedCap.txtCap;

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
                if (lngLastikYon == 2 && _selectedMevsim != null)
                    onSol[4] = _selectedMevsim.txtMevsim;
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
                if (lngLastikYon == 2 && _selectedDesen != null)
                    onSol[5] = _selectedDesen.txtDesen;
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
                    if (lngLastikYon == i + 1)
                    {
                        detayListe[i].bytUrunTip = _detay.bytUrunTip;
                        detayListe[i].DBLDISDERINLIGI = _detay.DBLDISDERINLIGI;
                        detayListe[i].LNGDEPOSIRAKOD = _detay.LNGDEPOSIRAKOD;
                        detayListe[i].LNGLASTIKDURUM = (_detay.ISOTL == 0) ? 1 : 3; //1 lastiğin saklamada olma durumu. 3 lastiğin ÖTL olma durumu
                        detayListe[i].LNGLASTIKTIP = i + 1;
                        detayListe[i].LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                        detayListe[i].LNGURUNTIP = (_detay.bytUrunTip) ? 2 : 1;
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


        #region SeciliMarkaIndexler
        public string[] onSol { get; set; }
        public string[] onSag { get; set; }
        public string[] arkaSol { get; set; }
        public string[] arkaSag { get; set; }
        public string[] digerSol { get; set; }
        public string[] digerSag { get; set; }
        #endregion


        public ICommand gotoMusteriAraPopUpPage { get; set; }
        public ICommand saklamaKayitGuncelleCommand { get; set; }
        public ICommand secilenLastikCommand { get; set; }
        public ICommand MarkaBilgiGetirCommand { get; set; }
        public ICommand DisDerinligiKontrolCommand { get; set; }
        public ICommand RafKolayKodKontrolCommand { get; set; }
        public ICommand PlakaKontrolCommand { get; set; }
        public ICommand HaftaKontrolCommand { get; set; }
        public ICommand DevamButonuCommand { get; set; }
        public SaklamaMarkaBilgiGuncelleme(INavigation navigation, KayitGuncelleRequest request)
        {
            _navigation = navigation;
            Initializer();
            gotoMusteriAraPopUpPage = new Command(async () => await gotoMusteriAraPopUpAsync());
            saklamaKayitGuncelleCommand = new Command(async () => await saklamaKayitGuncelleAsync());
            secilenLastikCommand = new Command((x) => secilenLastik(x));
            MarkaBilgiGetirCommand = new Command(async () => await MarkaBilgiGetirAsync());
            DisDerinligiKontrolCommand = new Command(async (x) => await DisDerinligiAsync(x));
            RafKolayKodKontrolCommand = new Command(async (x) => await RafKolayKodKontrolAsync(x));
            PlakaKontrolCommand = new Command(async (x) => await PlakaKontrolAsync(x));
            HaftaKontrolCommand = new Command((x) => HaftaKontrolAsync(x));
            DevamButonuCommand = new Command(() => DevamButonuAsync());

            Device.BeginInvokeOnMainThread(async () =>
            {
                await SaklamaKayitGetir(request);
                await MarkaBilgiGetirAsync();
            });

            MessagingCenter.Subscribe<MusteriAraPopUpViewModel, MusteriBilgileriResponse>(this, "yeniSaklamaSecilenMusteri", (s, e) =>
            {
                saklamaBaslikRequest.TXTMUSTERIUNVAN = e.TXTUNVAN;
                saklamaBaslikRequest.LNGMUSTERIKOD = e.LNGKOD;
                saklamaBaslikRequest.TXTMUSTERIERPKOD = e.TXTERPKOD;
                OnPropertyChanged("saklamaBaslikRequest");
            });
            MessagingCenter.Subscribe<DepoSecimPopUpViewModel, DepoDizilimResponse>(this, "selectedRaf", (s, e) =>
            {
                detay.TXTRAFKOLAYKOD = e.txtKod;
                detay.LNGDEPOSIRAKOD = e.lngKod;
                OnPropertyChanged("detay");
            });
        }

        private void DevamButonuAsync()
        {
            secilenLastik(2);
        }

        private void secilenLastik(object x)
        {
            tumunuEsitle = false;
            var oncekiLastikYon = lngLastikYon;
            lngLastikYon = Convert.ToInt32(x);

            //devam butonu ile yada marka bilgiler güncelleme sayfası görünür olduğunda yön ürün kodu kontrolüne takılmaması için 0 gönderiliyor.0 olma durumu 2 olma durumu ile aynıdır
            //if (lngLastikYon == 0)
            //{
            //    if (!string.IsNullOrEmpty(onSol[0]) && detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
            //        Device.BeginInvokeOnMainThread(async () =>
            //        {
            //            tumunuEsitle = false;
            //            for (int i = 0; i < onSol.Length; i++)
            //            {
            //                markaBilgiReuqest.txtDesen = (i == 5) ? onSol[5] : "";
            //                markaBilgiReuqest.txtMevsim = (i == 4 || i == 5) ? onSol[4] : "";
            //                markaBilgiReuqest.txtCap = (i == 3 || i == 4 || i == 5) ? onSol[3] : "";
            //                markaBilgiReuqest.txtKesit = (i == 2 || i == 3 || i == 4 || i == 5) ? onSol[2] : "";
            //                markaBilgiReuqest.txtTaban = (i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? onSol[1] : "";
            //                markaBilgiReuqest.txtMarka = (i == 0 || i == 1 || i == 2 || i == 3 || i == 4 || i == 5) ? onSol[0] : "";

            //                IsBusy = false;
            //                await MarkaBilgiGetirAsync();

            //                if (i == 0)
            //                    selectedMarkaIndex = lastikBilgileri.markaListe.IndexOf(lastikBilgileri.markaListe.FirstOrDefault(y => y.txtMarka == onSol[i]));
            //                if (i == 1)
            //                    selectedTabanIndex = lastikBilgileri.tabanListe.IndexOf(lastikBilgileri.tabanListe.FirstOrDefault(y => y.txtTaban == onSol[i]));
            //                if (i == 2)
            //                    selectedKesitIndex = lastikBilgileri.kesitListe.IndexOf(lastikBilgileri.kesitListe.FirstOrDefault(y => y.txtKesit == onSol[i]));
            //                if (i == 3)
            //                    selectedCapIndex = lastikBilgileri.capListe.IndexOf(lastikBilgileri.capListe.FirstOrDefault(y => y.txtCap == onSol[i]));
            //                if (i == 4)
            //                    selectedMevsimIndex = lastikBilgileri.mevsimListe.IndexOf(lastikBilgileri.mevsimListe.FirstOrDefault(y => y.txtMevsim == onSol[i]));
            //                if (i == 5)
            //                    selectedDesenIndex = lastikBilgileri.desenListe.IndexOf(lastikBilgileri.desenListe.FirstOrDefault(y => y.txtDesen == onSol[i]));
            //            }
            //            tumunuEsitle = true;
            //        });
            //    else if (detayListe[lngLastikYon - 1].TXTURUNKOD != detayListe[oncekiLastikYon - 1].TXTURUNKOD)
            //    {
            //        selectedMarkaIndex = -1;
            //        selectedTabanIndex = -1;
            //        selectedKesitIndex = -1;
            //        selectedCapIndex = -1;
            //        selectedMevsimIndex = -1;
            //        selectedDesenIndex = -1;
            //    }

            //    lngLastikYon = 2;
            //}
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
                else if (!string.IsNullOrEmpty(onSol[0]) && string.IsNullOrEmpty(detayListe[lngLastikYon - 1].TXTURUNKOD))
                {
                    detay.kullaniciUrunBilgileri.TXTMARKA = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTMARKA;
                    detay.kullaniciUrunBilgileri.TXTTABAN = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTTABAN;
                    detay.kullaniciUrunBilgileri.TXTKESIT = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTKESIT;
                    detay.kullaniciUrunBilgileri.TXTCAP = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTCAP;
                    detay.kullaniciUrunBilgileri.TXTMEVSIM = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTMEVSIM;
                    detay.kullaniciUrunBilgileri.TXTDESEN = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTDESEN;

                }
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
                else if (!string.IsNullOrEmpty(onSol[0]) && string.IsNullOrEmpty(detayListe[lngLastikYon - 1].TXTURUNKOD))
                {
                    detay.kullaniciUrunBilgileri.TXTMARKA = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTMARKA;
                    detay.kullaniciUrunBilgileri.TXTTABAN = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTTABAN;
                    detay.kullaniciUrunBilgileri.TXTKESIT = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTKESIT;
                    detay.kullaniciUrunBilgileri.TXTCAP = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTCAP;
                    detay.kullaniciUrunBilgileri.TXTMEVSIM = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTMEVSIM;
                    detay.kullaniciUrunBilgileri.TXTDESEN = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTDESEN;

                }
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
                else if (!string.IsNullOrEmpty(onSol[0]) && string.IsNullOrEmpty(detayListe[lngLastikYon - 1].TXTURUNKOD))
                {
                    detay.kullaniciUrunBilgileri.TXTMARKA = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTMARKA;
                    detay.kullaniciUrunBilgileri.TXTTABAN = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTTABAN;
                    detay.kullaniciUrunBilgileri.TXTKESIT = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTKESIT;
                    detay.kullaniciUrunBilgileri.TXTCAP = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTCAP;
                    detay.kullaniciUrunBilgileri.TXTMEVSIM = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTMEVSIM;
                    detay.kullaniciUrunBilgileri.TXTDESEN = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTDESEN;

                }
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
                else if (!string.IsNullOrEmpty(onSol[0]) && string.IsNullOrEmpty(detayListe[lngLastikYon - 1].TXTURUNKOD))
                {
                    detay.kullaniciUrunBilgileri.TXTMARKA = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTMARKA;
                    detay.kullaniciUrunBilgileri.TXTTABAN = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTTABAN;
                    detay.kullaniciUrunBilgileri.TXTKESIT = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTKESIT;
                    detay.kullaniciUrunBilgileri.TXTCAP = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTCAP;
                    detay.kullaniciUrunBilgileri.TXTMEVSIM = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTMEVSIM;
                    detay.kullaniciUrunBilgileri.TXTDESEN = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTDESEN;

                }
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
                else if (!string.IsNullOrEmpty(onSol[0]) && string.IsNullOrEmpty(detayListe[lngLastikYon - 1].TXTURUNKOD))
                {
                    detay.kullaniciUrunBilgileri.TXTMARKA = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTMARKA;
                    detay.kullaniciUrunBilgileri.TXTTABAN = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTTABAN;
                    detay.kullaniciUrunBilgileri.TXTKESIT = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTKESIT;
                    detay.kullaniciUrunBilgileri.TXTCAP = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTCAP;
                    detay.kullaniciUrunBilgileri.TXTMEVSIM = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTMEVSIM;
                    detay.kullaniciUrunBilgileri.TXTDESEN = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTDESEN;

                }
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
                else if (!string.IsNullOrEmpty(onSol[0]) && string.IsNullOrEmpty(detayListe[lngLastikYon - 1].TXTURUNKOD))
                {
                    detay.kullaniciUrunBilgileri.TXTMARKA = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTMARKA;
                    detay.kullaniciUrunBilgileri.TXTTABAN = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTTABAN;
                    detay.kullaniciUrunBilgileri.TXTKESIT = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTKESIT;
                    detay.kullaniciUrunBilgileri.TXTCAP = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTCAP;
                    detay.kullaniciUrunBilgileri.TXTMEVSIM = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTMEVSIM;
                    detay.kullaniciUrunBilgileri.TXTDESEN = detayListe[lngLastikYon - 1].kullaniciUrunBilgileri.TXTDESEN;

                }
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

        private async Task saklamaKayitGuncelleAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;
                detayListe.ToList().ForEach(x =>
                {
                    if (x.LNGURUNTIP == 1)
                        x.kullaniciUrunBilgileri = null;
                    else
                        x.TXTURUNKOD = null;
                });

                var validationresult = saklamayaAlValidator.Validate(saklamaBaslikRequest);
                if (!validationresult.IsValid)
                {

                    await App.Current.MainPage.DisplayAlert("Uyarı", $"{String.Join("", validationresult.Errors.Select(x => "- " + x.ErrorMessage + Environment.NewLine).Distinct())}", "Tamam");
                    return;
                }
                saklamaBaslikRequest.Tblsaklamadetay = detayListe.Where(x => (x.LNGKOD != null && x.BYTDURUM == 0) || x.BYTDURUM == 1).ToList();
                var result = await SaklamaService.YeniSaklamaDuzenle(saklamaBaslikRequest);

                if (result.StatusCode != 500 && result.Result != null)
                {
                    await App.Current.MainPage.DisplayAlert("Uyarı", "Kayıt güncelleme işlemi başarılı", "Tamam");

                    var soru = await App.Current.MainPage.DisplayAlert("Uyarı", "Lastik etiketi yazdırmak istermisiniz?", "Evet", "Hayır");
                    if (soru)
                        await YazdirAsync(saklamaBaslikRequest.LNGKOD ?? 0);

                    await _navigation.PopAsync();
                }
                else
                    await App.Current.MainPage.DisplayAlert("Uyarı", !string.IsNullOrEmpty(result.ErrorMessage) ? result.ErrorMessage : "Bir hata oluştu", "Tamam");

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

        private async Task gotoMusteriAraPopUpAsync()
        {
            await _doubleClickControl.PopUpPushAsync(new MusteriAraPopUpPage());
            //await PopupNavigation.PushAsync(new MusteriAraPopUpPage());
        }

        public void Initializer()
        {
            lngLastikYon = 2;
            dblDisDerinligi = 0;
            tumunuEsitle = true;
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

        private async Task SaklamaKayitGetir(KayitGuncelleRequest request)
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var result = await SaklamaService.SaklamaBilgiGetir(
                    new SaklamaBilgiRequest
                    {
                        lngDistKod = App.sessionInfo.lngDistkod,
                        lngSaklamaBaslik = request.lngSaklamaKod,
                    });

                if (result.StatusCode != 500 && result.Result != null)
                {
                    saklamaBaslikRequest = new SaklamaBaslikRequest
                    {
                        BYTDURUM = 1,
                        LNGARACKM = result.Result.lngAracKm,
                        LNGDISTKOD = App.sessionInfo.lngDistkod,
                        LNGKOD = result.Result.lngKod,
                        LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod,
                        TXTACIKLAMA = result.Result.txtAciklama,
                        TXTCEPTEL = result.Result.txtCepTel,
                        TXTEMAIL = result.Result.txtEmail,
                        TXTMUSTERIERPKOD = result.Result.txtMusteriErpKod,
                        TXTMUSTERIUNVAN = result.Result.txtMusteriUnvan,
                        TXTPLAKA = result.Result.txtPlaka,
                        TXTSOFORADSOYAD = result.Result.txtSoforAdSoyad,
                        TXTTCKIMLIKNO = result.Result.txtTcKimlikNo,
                        TXTVN = result.Result.txtVn
                    };

                    foreach (var x in result.Result.Tblsaklamadetay)
                    {
                        switch (x.txtLastikYon)
                        {
                            case "Ön Sağ":
                                detayListe[0].bytUrunTip = (x.lngUrunTip == 1) ? false : true;
                                detayListe[0].BYTDURUM = x.bytDurum;
                                detayListe[0].BYTHAVUZDA = x.bytHavuzda;
                                detayListe[0].LNGURUNTIP = x.lngUrunTip;
                                detayListe[0].txtDisDerinligi = x.dblDisDerinligi.ToString();
                                detayListe[0].LNGLASTIKDURUM = x.lngLastikDurum;
                                detayListe[0].LNGDEPOSIRAKOD = x.lngDepoSiraKod;
                                detayListe[0].LNGKOD = x.lngKod;
                                detayListe[0].LNGLASTIKTIP = 1;
                                detayListe[0].LNGSAKLAMABASLIKKOD = saklamaBaslikRequest.LNGKOD;
                                detayListe[0].LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                                detayListe[0].TXTACIKLAMA = x.txtAciklama;
                                detayListe[0].TXTDOTFABRIKA = x.txtDotFabrika;
                                detayListe[0].TXTDOTHAFTA = x.txtDotHafta;
                                detayListe[0].TXTDOTURETIM = x.txtDotUretim;
                                detayListe[0].TXTRAFKOLAYKOD = x.txtRafKolayKod;
                                if (x.lngUrunTip == 2)
                                {
                                    detayListe[0].ISOTL = (x.bytOtl) ? 1 : 0;
                                    detayListe[0].LNGKULLANICIURUNKOD = x.kullaniciUrunResponse.lngKod;
                                    detayListe[0].kullaniciUrunBilgileri.BYTDURUM = 1;
                                    detayListe[0].kullaniciUrunBilgileri.LNGKOD = x.kullaniciUrunResponse.lngKod;
                                    detayListe[0].kullaniciUrunBilgileri.LNGLASTIKTIP = x.lngLastikTip;
                                    detayListe[0].kullaniciUrunBilgileri.LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                                    detayListe[0].kullaniciUrunBilgileri.TXTCAP = x.kullaniciUrunResponse.txtCap;
                                    detayListe[0].kullaniciUrunBilgileri.TXTDESEN = x.kullaniciUrunResponse.txtDesen;
                                    detayListe[0].kullaniciUrunBilgileri.TXTKESIT = x.kullaniciUrunResponse.txtKesit;
                                    detayListe[0].kullaniciUrunBilgileri.TXTMARKA = x.kullaniciUrunResponse.txtMarka;
                                    detayListe[0].kullaniciUrunBilgileri.TXTMEVSIM = x.kullaniciUrunResponse.txtMevsim;
                                    detayListe[0].kullaniciUrunBilgileri.TXTTABAN = x.kullaniciUrunResponse.txtTaban;
                                }
                                else
                                    detayListe[0].TXTURUNKOD = x.txtUrunKod;

                                onSag[0] = !string.IsNullOrEmpty(x.txtMarka) ? x.txtMarka : "";
                                onSag[1] = x.txtTaban;
                                onSag[2] = x.txtKesit;
                                onSag[3] = x.txtCap;
                                onSag[4] = x.txtMevsim;
                                onSag[5] = x.txtDesen;

                                break;
                            case "Ön Sol":
                                detayListe[1].ISOTL = (x.bytOtl) ? 1 : 0;
                                detayListe[1].bytUrunTip = (x.lngUrunTip == 1) ? false : true;
                                detayListe[1].BYTDURUM = x.bytDurum;
                                detayListe[1].BYTHAVUZDA = x.bytHavuzda;
                                detayListe[1].LNGURUNTIP = x.lngUrunTip;
                                detayListe[1].txtDisDerinligi = x.dblDisDerinligi.ToString();
                                detayListe[1].LNGLASTIKDURUM = x.lngLastikDurum;
                                detayListe[1].LNGDEPOSIRAKOD = x.lngDepoSiraKod;
                                detayListe[1].LNGKOD = x.lngKod;
                                detayListe[1].LNGLASTIKTIP = 2;
                                detayListe[1].LNGSAKLAMABASLIKKOD = saklamaBaslikRequest.LNGKOD;
                                detayListe[1].LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                                detayListe[1].LNGURUNTIP = x.lngUrunTip;
                                detayListe[1].TXTACIKLAMA = x.txtAciklama;
                                detayListe[1].TXTDOTFABRIKA = x.txtDotFabrika;
                                detayListe[1].TXTDOTHAFTA = x.txtDotHafta;
                                detayListe[1].TXTDOTURETIM = x.txtDotUretim;
                                detayListe[1].TXTRAFKOLAYKOD = x.txtRafKolayKod;
                                if (x.lngUrunTip == 2)
                                {
                                    detayListe[1].LNGKULLANICIURUNKOD = x.kullaniciUrunResponse.lngKod;
                                    detayListe[1].kullaniciUrunBilgileri.BYTDURUM = 1;
                                    detayListe[1].kullaniciUrunBilgileri.LNGKOD = x.kullaniciUrunResponse.lngKod;
                                    detayListe[1].kullaniciUrunBilgileri.LNGLASTIKTIP = x.lngLastikTip;
                                    detayListe[1].kullaniciUrunBilgileri.LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                                    detayListe[1].kullaniciUrunBilgileri.TXTCAP = x.kullaniciUrunResponse.txtCap;
                                    detayListe[1].kullaniciUrunBilgileri.TXTDESEN = x.kullaniciUrunResponse.txtDesen;
                                    detayListe[1].kullaniciUrunBilgileri.TXTKESIT = x.kullaniciUrunResponse.txtKesit;
                                    detayListe[1].kullaniciUrunBilgileri.TXTMARKA = x.kullaniciUrunResponse.txtMarka;
                                    detayListe[1].kullaniciUrunBilgileri.TXTMEVSIM = x.kullaniciUrunResponse.txtMevsim;
                                    detayListe[1].kullaniciUrunBilgileri.TXTTABAN = x.kullaniciUrunResponse.txtTaban;
                                }
                                else
                                    detayListe[1].TXTURUNKOD = x.txtUrunKod;

                                onSol[0] = !string.IsNullOrEmpty(x.txtMarka) ? x.txtMarka : "";
                                onSol[1] = x.txtTaban;
                                onSol[2] = x.txtKesit;
                                onSol[3] = x.txtCap;
                                onSol[4] = x.txtMevsim;
                                onSol[5] = x.txtDesen;
                                break;
                            case "Arka Sağ":
                                detayListe[2].ISOTL = (x.bytOtl) ? 1 : 0;
                                detayListe[2].bytUrunTip = (x.lngUrunTip == 1) ? false : true;
                                detayListe[2].BYTDURUM = x.bytDurum;
                                detayListe[2].BYTHAVUZDA = x.bytHavuzda;
                                detayListe[2].LNGURUNTIP = x.lngUrunTip;
                                detayListe[2].txtDisDerinligi = x.dblDisDerinligi.ToString();
                                detayListe[2].LNGLASTIKDURUM = x.lngLastikDurum;
                                detayListe[2].LNGDEPOSIRAKOD = x.lngDepoSiraKod;
                                detayListe[2].LNGKOD = x.lngKod;
                                detayListe[2].LNGLASTIKTIP = 3;
                                detayListe[2].LNGSAKLAMABASLIKKOD = saklamaBaslikRequest.LNGKOD;
                                detayListe[2].LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                                detayListe[2].LNGURUNTIP = x.lngUrunTip;
                                detayListe[2].TXTACIKLAMA = x.txtAciklama;
                                detayListe[2].TXTDOTFABRIKA = x.txtDotFabrika;
                                detayListe[2].TXTDOTHAFTA = x.txtDotHafta;
                                detayListe[2].TXTDOTURETIM = x.txtDotUretim;
                                detayListe[2].TXTRAFKOLAYKOD = x.txtRafKolayKod;
                                if (x.lngUrunTip == 2)
                                {
                                    detayListe[2].LNGKULLANICIURUNKOD = x.kullaniciUrunResponse.lngKod;
                                    detayListe[2].kullaniciUrunBilgileri.BYTDURUM = 1;
                                    detayListe[2].kullaniciUrunBilgileri.LNGKOD = x.kullaniciUrunResponse.lngKod;
                                    detayListe[2].kullaniciUrunBilgileri.LNGLASTIKTIP = x.lngLastikTip;
                                    detayListe[2].kullaniciUrunBilgileri.LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                                    detayListe[2].kullaniciUrunBilgileri.TXTCAP = x.kullaniciUrunResponse.txtCap;
                                    detayListe[2].kullaniciUrunBilgileri.TXTDESEN = x.kullaniciUrunResponse.txtDesen;
                                    detayListe[2].kullaniciUrunBilgileri.TXTKESIT = x.kullaniciUrunResponse.txtKesit;
                                    detayListe[2].kullaniciUrunBilgileri.TXTMARKA = x.kullaniciUrunResponse.txtMarka;
                                    detayListe[2].kullaniciUrunBilgileri.TXTMEVSIM = x.kullaniciUrunResponse.txtMevsim;
                                    detayListe[2].kullaniciUrunBilgileri.TXTTABAN = x.kullaniciUrunResponse.txtTaban;
                                }
                                else
                                    detayListe[2].TXTURUNKOD = x.txtUrunKod;

                                arkaSag[0] = !string.IsNullOrEmpty(x.txtMarka) ? x.txtMarka : "";
                                arkaSag[1] = x.txtTaban;
                                arkaSag[2] = x.txtKesit;
                                arkaSag[3] = x.txtCap;
                                arkaSag[4] = x.txtMevsim;
                                arkaSag[5] = x.txtDesen;
                                break;
                            case "Arka Sol":
                                detayListe[3].ISOTL = (x.bytOtl) ? 1 : 0;
                                detayListe[3].bytUrunTip = (x.lngUrunTip == 1) ? false : true;
                                detayListe[3].BYTDURUM = x.bytDurum;
                                detayListe[3].BYTHAVUZDA = x.bytHavuzda;
                                detayListe[3].LNGURUNTIP = x.lngUrunTip;
                                detayListe[3].txtDisDerinligi = x.dblDisDerinligi.ToString();
                                detayListe[3].LNGLASTIKDURUM = x.lngLastikDurum;
                                detayListe[3].LNGDEPOSIRAKOD = x.lngDepoSiraKod;
                                detayListe[3].LNGKOD = x.lngKod;
                                detayListe[3].LNGLASTIKTIP = 4;
                                detayListe[3].LNGSAKLAMABASLIKKOD = saklamaBaslikRequest.LNGKOD;
                                detayListe[3].LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                                detayListe[3].LNGURUNTIP = x.lngUrunTip;
                                detayListe[3].TXTACIKLAMA = x.txtAciklama;
                                detayListe[3].TXTDOTFABRIKA = x.txtDotFabrika;
                                detayListe[3].TXTDOTHAFTA = x.txtDotHafta;
                                detayListe[3].TXTDOTURETIM = x.txtDotUretim;
                                detayListe[3].TXTRAFKOLAYKOD = x.txtRafKolayKod;
                                if (x.lngUrunTip == 3)
                                {
                                    detayListe[3].LNGKULLANICIURUNKOD = x.kullaniciUrunResponse.lngKod;
                                    detayListe[3].kullaniciUrunBilgileri.BYTDURUM = 1;
                                    detayListe[3].kullaniciUrunBilgileri.LNGKOD = x.kullaniciUrunResponse.lngKod;
                                    detayListe[3].kullaniciUrunBilgileri.LNGLASTIKTIP = x.lngLastikTip;
                                    detayListe[3].kullaniciUrunBilgileri.LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                                    detayListe[3].kullaniciUrunBilgileri.TXTCAP = x.kullaniciUrunResponse.txtCap;
                                    detayListe[3].kullaniciUrunBilgileri.TXTDESEN = x.kullaniciUrunResponse.txtDesen;
                                    detayListe[3].kullaniciUrunBilgileri.TXTKESIT = x.kullaniciUrunResponse.txtKesit;
                                    detayListe[3].kullaniciUrunBilgileri.TXTMARKA = x.kullaniciUrunResponse.txtMarka;
                                    detayListe[3].kullaniciUrunBilgileri.TXTMEVSIM = x.kullaniciUrunResponse.txtMevsim;
                                    detayListe[3].kullaniciUrunBilgileri.TXTTABAN = x.kullaniciUrunResponse.txtTaban;
                                }
                                else
                                    detayListe[3].TXTURUNKOD = x.txtUrunKod;

                                arkaSol[0] = !string.IsNullOrEmpty(x.txtMarka) ? x.txtMarka : "";
                                arkaSol[1] = x.txtTaban;
                                arkaSol[2] = x.txtKesit;
                                arkaSol[3] = x.txtCap;
                                arkaSol[4] = x.txtMevsim;
                                arkaSol[5] = x.txtDesen;
                                break;
                            case "Diğer Sağ 1":
                                detayListe[4].ISOTL = (x.bytOtl) ? 1 : 0;
                                detayListe[4].bytUrunTip = (x.lngUrunTip == 1) ? false : true;
                                detayListe[4].BYTDURUM = x.bytDurum;
                                detayListe[4].BYTHAVUZDA = x.bytHavuzda;
                                detayListe[4].LNGURUNTIP = x.lngUrunTip;
                                detayListe[4].txtDisDerinligi = x.dblDisDerinligi.ToString();
                                detayListe[4].LNGLASTIKDURUM = x.lngLastikDurum;
                                detayListe[4].LNGDEPOSIRAKOD = x.lngDepoSiraKod;
                                detayListe[4].LNGKOD = x.lngKod;
                                detayListe[4].LNGLASTIKTIP = 5;
                                detayListe[4].LNGSAKLAMABASLIKKOD = saklamaBaslikRequest.LNGKOD;
                                detayListe[4].LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                                detayListe[4].LNGURUNTIP = x.lngUrunTip;
                                detayListe[4].TXTACIKLAMA = x.txtAciklama;
                                detayListe[4].TXTDOTFABRIKA = x.txtDotFabrika;
                                detayListe[4].TXTDOTHAFTA = x.txtDotHafta;
                                detayListe[4].TXTDOTURETIM = x.txtDotUretim;
                                detayListe[4].TXTRAFKOLAYKOD = x.txtRafKolayKod;
                                if (x.lngUrunTip == 2)
                                {
                                    detayListe[4].LNGKULLANICIURUNKOD = x.kullaniciUrunResponse.lngKod;
                                    detayListe[4].kullaniciUrunBilgileri.BYTDURUM = 1;
                                    detayListe[4].kullaniciUrunBilgileri.LNGKOD = x.kullaniciUrunResponse.lngKod;
                                    detayListe[4].kullaniciUrunBilgileri.LNGLASTIKTIP = x.lngLastikTip;
                                    detayListe[4].kullaniciUrunBilgileri.LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                                    detayListe[4].kullaniciUrunBilgileri.TXTCAP = x.kullaniciUrunResponse.txtCap;
                                    detayListe[4].kullaniciUrunBilgileri.TXTDESEN = x.kullaniciUrunResponse.txtDesen;
                                    detayListe[4].kullaniciUrunBilgileri.TXTKESIT = x.kullaniciUrunResponse.txtKesit;
                                    detayListe[4].kullaniciUrunBilgileri.TXTMARKA = x.kullaniciUrunResponse.txtMarka;
                                    detayListe[4].kullaniciUrunBilgileri.TXTMEVSIM = x.kullaniciUrunResponse.txtMevsim;
                                    detayListe[4].kullaniciUrunBilgileri.TXTTABAN = x.kullaniciUrunResponse.txtTaban;
                                }
                                else
                                    detayListe[4].TXTURUNKOD = x.txtUrunKod;

                                digerSag[0] = !string.IsNullOrEmpty(x.txtMarka) ? x.txtMarka : "";
                                digerSag[1] = x.txtTaban;
                                digerSag[2] = x.txtKesit;
                                digerSag[3] = x.txtCap;
                                digerSag[4] = x.txtMevsim;
                                digerSag[5] = x.txtDesen;
                                break;
                            case "Diğer Sol 1":
                                detayListe[5].ISOTL = (x.bytOtl) ? 1 : 0;
                                detayListe[5].bytUrunTip = (x.lngUrunTip == 1) ? false : true;
                                detayListe[5].BYTDURUM = x.bytDurum;
                                detayListe[5].BYTHAVUZDA = x.bytHavuzda;
                                detayListe[5].LNGURUNTIP = x.lngUrunTip;
                                detayListe[5].txtDisDerinligi = x.dblDisDerinligi.ToString();
                                detayListe[5].LNGLASTIKDURUM = x.lngLastikDurum;
                                detayListe[5].LNGDEPOSIRAKOD = x.lngDepoSiraKod;
                                detayListe[5].LNGKOD = x.lngKod;
                                detayListe[5].LNGLASTIKTIP = 6;
                                detayListe[5].LNGSAKLAMABASLIKKOD = saklamaBaslikRequest.LNGKOD;
                                detayListe[5].LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                                detayListe[5].LNGURUNTIP = x.lngUrunTip;
                                detayListe[5].TXTACIKLAMA = x.txtAciklama;
                                detayListe[5].TXTDOTFABRIKA = x.txtDotFabrika;
                                detayListe[5].TXTDOTHAFTA = x.txtDotHafta;
                                detayListe[5].TXTDOTURETIM = x.txtDotUretim;
                                detayListe[5].TXTRAFKOLAYKOD = x.txtRafKolayKod;
                                if (x.lngUrunTip == 2)
                                {
                                    detayListe[5].LNGKULLANICIURUNKOD = x.kullaniciUrunResponse.lngKod;
                                    detayListe[5].kullaniciUrunBilgileri.BYTDURUM = 1;
                                    detayListe[5].kullaniciUrunBilgileri.LNGKOD = x.kullaniciUrunResponse.lngKod;
                                    detayListe[5].kullaniciUrunBilgileri.LNGLASTIKTIP = x.lngLastikTip;
                                    detayListe[5].kullaniciUrunBilgileri.LNGSONISLEMYAPANKULLANICI = App.sessionInfo.lngPanKulKod;
                                    detayListe[5].kullaniciUrunBilgileri.TXTCAP = x.kullaniciUrunResponse.txtCap;
                                    detayListe[5].kullaniciUrunBilgileri.TXTDESEN = x.kullaniciUrunResponse.txtDesen;
                                    detayListe[5].kullaniciUrunBilgileri.TXTKESIT = x.kullaniciUrunResponse.txtKesit;
                                    detayListe[5].kullaniciUrunBilgileri.TXTMARKA = x.kullaniciUrunResponse.txtMarka;
                                    detayListe[5].kullaniciUrunBilgileri.TXTMEVSIM = x.kullaniciUrunResponse.txtMevsim;
                                    detayListe[5].kullaniciUrunBilgileri.TXTTABAN = x.kullaniciUrunResponse.txtTaban;
                                }
                                else
                                    detayListe[5].TXTURUNKOD = x.txtUrunKod;
                                digerSol[0] = !string.IsNullOrEmpty(x.txtMarka) ? x.txtMarka : "";
                                digerSol[1] = x.txtTaban;
                                digerSol[2] = x.txtKesit;
                                digerSol[3] = x.txtCap;
                                digerSol[4] = x.txtMevsim;
                                digerSol[5] = x.txtDesen;
                                break;
                        }
                    }

                    detayListe.ToList().ForEach(x =>
                    {
                        if (x.LNGKOD == null)
                            x.BYTDURUM = 0;
                    });
                }
                else
                {
                    await App.Current.MainPage.DisplayAlert("Uyarı", (!string.IsNullOrEmpty(result.ErrorMessage)) ? result.ErrorMessage : "Bir hata oluştu", "Tamam");
                    await _navigation.PopAsync();
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
                var bytDisDerinligi = decimal.TryParse(x.ToString(), out dblIstenenDisDer);
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

        private void HaftaKontrolAsync(object x)
        {
            if (x.ToString().Length != 4)
            {
                DependencyService.Get<IToastService>().ToastMessage($"Hafta bilgisi 4 karakter olmalıdır");
                detay.TXTDOTHAFTA = null;
                OnPropertyChanged("detay");
            }
        }

        private async Task YazdirAsync(int lngSaklamaKod)
        {
            try
            {
                var result = await ParametreService.DesenBilgileriGetir(new DesenRequest
                {
                    lngDistKod = App.sessionInfo.lngDistkod,
                    lngSaklamaBaslik = lngSaklamaKod,
                });

                if (result.StatusCode != 500 && result.Result != null && result.Result.Count > 0)
                    PopupNavigation.PushAsync(new SearchPrinterPopupPage(new PrintRequest
                    {
                        lastikEtiketlerBilgi = result.Result.ToList(),
                        siraKolayKodEtiketBilgileri = null
                    }));
                else
                    await Page.DisplayAlert("Uyarı", !string.IsNullOrEmpty(result.ErrorMessage) ? result.ErrorMessage : "Sıra kolay kod desen bilgisi alınamadı", "Tamam");

            }
            catch (Exception)
            {
                await Page.DisplayAlert("Uyarı", "Bir hata oluştu", "Tamam");
            }
        }

    }
}
