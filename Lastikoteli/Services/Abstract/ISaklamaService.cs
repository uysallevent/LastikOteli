using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lastikoteli.Services.Abstract
{
    public interface ISaklamaService
    {
        Task<ApiResponseGeneric<int>> YeniSaklamaEkle(SaklamaBaslikRequest request);
        Task<ApiResponseGeneric<SaklamaBilgileriResponse>> SaklamaBilgiGetir(SaklamaBilgiRequest request);
        Task<ApiResponseGeneric<bool>> LastikTeslimEt(LastikTeslimRequest request);
        Task<ApiResponseGeneric<List<SaklamaBilgileriResponse>>> SaklamadaKayitArama(SaklamaBilgiRequest request);
        Task<ApiResponseGeneric<PagingResponse<MusteriBilgileriResponse>>> MusteriListesi(SaklamaMusteriRequest request);
        Task<ApiResponse> YasalDisDerinligiGetir();
        Task<ApiResponseGeneric<PlakaSorguResponse>> PlakaSorgula(string txtPlaka);
    }
}
