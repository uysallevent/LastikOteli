using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Lastikoteli.ViewModels
{
    public class KayitGuncellemeTabbedViewModel : BaseViewModel
    {

        public SaklamaMarkaBilgiGuncelleme saklamaMarkaBilgiGuncelleme { get; set; }

        public KayitGuncellemeTabbedViewModel(INavigation navigation, KayitGuncelleRequest request)
        {
            saklamaMarkaBilgiGuncelleme = new SaklamaMarkaBilgiGuncelleme(navigation, request);
        }
    }
}
