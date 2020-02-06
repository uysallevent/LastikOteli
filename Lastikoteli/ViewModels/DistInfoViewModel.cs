using System;
using Lastikoteli.Models;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class DistInfoViewModel : BaseViewModel
    {
        private INavigation _navigation;
        public SessionInfo distBilgi { get; set; }

        public DistInfoViewModel(INavigation navigation)
        {
            _navigation = navigation;
            distBilgi = App.sessionInfo;
        }
    }
}
