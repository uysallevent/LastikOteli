using Lastikoteli.Helper.Abstract;
using Lastikoteli.Models.Complex.Response;
using System.Collections.Generic;
using System.Linq;

namespace Lastikoteli.Helper
{
    public class SeciliMarkaBilgiIslemleri : ISeciliMarkaBilgiIslemleri
    {
        private SecilenLastikBilgileriResponse onSag;
        private SecilenLastikBilgileriResponse onSol;
        private SecilenLastikBilgileriResponse arkaSag;
        private SecilenLastikBilgileriResponse arkaSol;
        private SecilenLastikBilgileriResponse digerSag;
        private SecilenLastikBilgileriResponse digerSol;
        public List<SecilenLastikBilgileriResponse> secilenlerListesi;


        public void BilgiEke(SecilenLastikBilgileriResponse request, int lngLastikYon)
        {

            var secilen = secilenlerListesi[lngLastikYon - 1];
            if (lngLastikYon == 2)
            {
                for (int i = 0; i < secilenlerListesi.Count - 1; i++)
                {
                    if (i == 1)
                        continue;
                    secilenlerListesi[i] = secilenlerListesi[1];
                }
            }

            secilen.markaListe = (request.markaListe != null) ? request.markaListe : secilen.markaListe;
            secilen.tabanListe = (request.tabanListe != null) ? request.tabanListe : secilen.tabanListe;
            secilen.kesitListe = (request.kesitListe != null) ? request.kesitListe : secilen.kesitListe;
            secilen.capListe = (request.capListe != null) ? request.capListe : secilen.capListe;
            secilen.mevsimListe = (request.mevsimListe != null) ? request.mevsimListe : secilen.mevsimListe;
            secilen.desenListe = (request.desenListe != null) ? request.desenListe : secilen.desenListe;
            secilen.txtUrunKod = (request.txtUrunKod != null) ? request.txtUrunKod : secilen.txtUrunKod;
            secilen.markaIndex = (request.markaIndex != null) ? request.markaIndex : secilen.markaIndex;
            secilen.tabanIndex = (request.tabanIndex != null) ? request.tabanIndex : secilen.tabanIndex;
            secilen.kesitIndex = (request.kesitIndex != null) ? request.kesitIndex : secilen.kesitIndex;
            secilen.capIndex = (request.capIndex != null) ? request.capIndex : secilen.capIndex;
            secilen.mevsimIndex = (request.mevsimIndex != null) ? request.mevsimIndex : secilen.mevsimIndex;
            secilen.desenIndex = (request.desenIndex != null) ? request.desenIndex : secilen.desenIndex;
        }

        public SecilenLastikBilgileriResponse LastikSec(int lngLastikYon)
        {
            switch (lngLastikYon)
            {
                case 1:
                    return secilenlerListesi[lngLastikYon - 1];
                case 2:
                    return secilenlerListesi[lngLastikYon - 1];
                case 3:
                    return secilenlerListesi[lngLastikYon - 1];
                case 4:
                    return secilenlerListesi[lngLastikYon - 1];
                case 5:
                    return secilenlerListesi[lngLastikYon - 1];
                case 6:
                    return secilenlerListesi[lngLastikYon - 1];
                default:
                    return null;
            }
        }

        /// <summary>
        /// Seçilimi bölüm:
        /// Marka-1
        /// Taban-2
        /// Kesit-3
        /// Çap-4
        /// Mevsim-5
        /// Desen-6
        /// </summary>
        /// <param name="lngLastikYon"></param>
        /// <param name="seciliBolum"></param>
        public void SecilenMarkaBolumunuSifirla(int lngLastikYon, int seciliBolum)
        {
            var bulunan = secilenlerListesi[lngLastikYon - 1];
            switch (seciliBolum)
            {
                case 1:
                    bulunan.tabanListe = null;
                    bulunan.kesitListe = null;
                    bulunan.capListe = null;
                    bulunan.mevsimListe = null;
                    bulunan.desenListe = null;

                    break;
                case 2:
                    bulunan.kesitListe = null;
                    bulunan.capListe = null;
                    bulunan.mevsimListe = null;
                    bulunan.desenListe = null;

                    break;
                case 3:
                    bulunan.capListe = null;
                    bulunan.mevsimListe = null;
                    bulunan.desenListe = null;

                    break;
                case 4:
                    bulunan.mevsimListe = null;
                    bulunan.desenListe = null;

                    break;
                case 5:
                    bulunan.desenListe = null;

                    break;
                case 6:

                    break;
            }
        }

        public List<SecilenLastikBilgileriResponse> LastiKSifirla()
        {
            secilenlerListesi = new List<SecilenLastikBilgileriResponse>();
            onSag = new SecilenLastikBilgileriResponse();
            secilenlerListesi.Add(onSag);

            onSol = new SecilenLastikBilgileriResponse();
            secilenlerListesi.Add(onSol);

            arkaSag = new SecilenLastikBilgileriResponse();
            secilenlerListesi.Add(arkaSag);

            arkaSol = new SecilenLastikBilgileriResponse();
            secilenlerListesi.Add(arkaSol);

            digerSag = new SecilenLastikBilgileriResponse();
            secilenlerListesi.Add(digerSag);

            digerSol = new SecilenLastikBilgileriResponse();
            secilenlerListesi.Add(digerSol);

            return secilenlerListesi;
        }
    }
}
