using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Views;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class SaklamaMarkaBilgiGuncelleme : BaseViewModel
    {

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


        public decimal dblDisDerinligi { get; set; }


        public ICommand gotoMusteriAraPopUpPage { get; set; }

        public SaklamaMarkaBilgiGuncelleme(INavigation navigation, KayitGuncelleRequest request)
        {
            _navigation = navigation;
            Initializer();
            gotoMusteriAraPopUpPage = new Command(async () =>await gotoMusteriAraPopUpAsync());
            Device.BeginInvokeOnMainThread(async () => await SaklamaKayitGetir(request));

            MessagingCenter.Subscribe<MusteriAraPopUpViewModel, MusteriBilgileriResponse>(this, "yeniSaklamaSecilenMusteri", (s, e) =>
            {
                saklamaBaslikRequest.TXTMUSTERIUNVAN = e.TXTUNVAN;
                saklamaBaslikRequest.LNGMUSTERIKOD = e.LNGKOD;
                saklamaBaslikRequest.TXTMUSTERIERPKOD = e.TXTERPKOD;
                OnPropertyChanged("saklamaBaslikRequest");
            });
        }

        private async Task  gotoMusteriAraPopUpAsync()
        {
            await PopupNavigation.PushAsync(new MusteriAraPopUpPage());
        }

        public void Initializer()
        {
            lngLastikYon = 2;
            dblDisDerinligi = 0;
            tumunuEsitle = true;
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

    }
}
