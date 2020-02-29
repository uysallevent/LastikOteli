using Lastikoteli.Models.Complex.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.ViewModels
{
    public class SaklamaListePopUpViewModel : BaseViewModel
    {
        private IList<LastikSaklamaBilgiResponse> _saklamaListe;

        public IList<LastikSaklamaBilgiResponse> saklamaListe
        {
            get { return _saklamaListe; }
            set { SetProperty(ref _saklamaListe, value); }
        }

        public SaklamaListePopUpViewModel(IList<LastikSaklamaBilgiResponse> liste)
        {
            saklamaListe = liste;
        }
    }
}
