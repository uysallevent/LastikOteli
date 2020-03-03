using Lastikoteli.Models.Complex.Response;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Helper.Abstract
{
    public interface ISeciliMarkaBilgiIslemleri
    {
        void BilgiEke(SecilenLastikBilgileriResponse request, int lngLastikYon);
        List<SecilenLastikBilgileriResponse> LastiKSifirla();
        void SecilenMarkaBolumunuSifirla(int lngLastikYon, int seciliBolum);
        SecilenLastikBilgileriResponse LastikSec(int lngLastikYon);
    }
}
