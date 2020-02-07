using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Constant;
using Lastikoteli.Models.MiyaPortal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Extended;

namespace Lastikoteli.ViewModels
{
    public class IsListesiViewModel : BaseViewModel
    {
        private INavigation _navigation;

        public ObservableCollection<Randevu> _isListesi { get; set; }

        public IsListesiViewModel(INavigation navigation)
        {
            _navigation = navigation;

        }

    }
}
