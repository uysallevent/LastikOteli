using System;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class IsListesiViewModel : BaseViewModel
    {
        private INavigation _navigation;

        public IsListesiViewModel(INavigation navigation)
        {
            _navigation = navigation;
        }
    }
}
