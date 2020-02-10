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
        private INavigation _navigation;
        public IsListesiPage Page { get; set; }

        public ObservableCollection<Randevu> _isListesi { get; set; }

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
        public Randevu SelectedModel { get; set; }

        private async void OpenPopUpDialog(Randevu randevu)

        {
            string actionSheetResult = "";
            if (randevu.TXTSOKMETAKMA == "S")
            {
                actionSheetResult = await this.Page.DisplayActionSheet("Seçim Yapın", "İptal", null, "Saklama");
            }
            else if (randevu.TXTSOKMETAKMA == "T")
            {
                actionSheetResult = await this.Page.DisplayActionSheet("Seçim Yapın", "İptal", null, "Sökme/Takma");
            }
            else if (randevu.TXTSOKMETAKMA == "S/T")
            {
                actionSheetResult = await this.Page.DisplayActionSheet("Seçim Yapın", "İptal", null, "Saklama", "Sökme/Takma");
            }

            switch (actionSheetResult)
            {
                case "Saklama":

                    break;
                case "Sökme/Takma":
                    await _doubleClickControl.PushAsync(new YeniTakma(SelectedModel.LNGSAKLAMABASLIK ?? 0));
                    break;
            }
        }

        public IsListesiViewModel(INavigation navigation)
        {
            _navigation = navigation;
            _doubleClickControl = new DoubleClickControl(_navigation);
        }

    }
}
