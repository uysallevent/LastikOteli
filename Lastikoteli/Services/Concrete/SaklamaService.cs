using Lastikoteli.Helper;
using Lastikoteli.Helper.ServiceHelper;
using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Services.Abstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lastikoteli.Services.Concrete
{
    public class SaklamaService : ServiceManager, ISaklamaService
    {
        public async Task<ApiResponseGeneric<SaklamaBilgileriResponse>> SaklamaBilgiGetir(SaklamaBilgiRequest request)
        {
            var Client = await GetClient();
            var response = await Client.GetStringAsync(apiUrl + $"/api/Saklama/SaklamaKayitGetir?lngDistKod={request.lngDistKod}&lngSaklamaBaslik={request.lngSaklamaBaslik}");
            return await Task.FromResult(ApiResultCheck.ResultCheck<SaklamaBilgileriResponse>(response));
        }

        public async Task<ApiResponseGeneric<List<SaklamaBilgileriResponse>>> SaklamadaKayitArama(SaklamaBilgiRequest request)
        {
            var Client = await GetClient();
            var path = (!string.IsNullOrEmpty(request.txtPlaka)) ?
                $"/api/Saklama/SaklamadaKayitArama?lngDistKod={request.lngDistKod}&txtPlaka={request.txtPlaka.ToLower()}" :
                $"/api/Saklama/SaklamadaKayitArama?lngDistKod={request.lngDistKod}&lngSaklamaBaslik={request.lngSaklamaBaslik}";

            var response = await Client.GetAsync(apiUrl + path);
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<List<SaklamaBilgileriResponse>>(responseContent));
        }

        public async Task<ApiResponseGeneric<bool>> LastikTeslimEt(LastikTeslimRequest request)
        {
            var client = await GetClient();
            var response = await client.PostAsync(apiUrl + "/api/Saklama/ElTerminaliLastikTeslimEtme", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<bool>(responseContent));
        }

        public async Task<ApiResponseGeneric<PagingResponse<MusteriBilgileriResponse>>> MusteriListesi(SaklamaMusteriRequest request)
        {
            var client = await GetClient();
            var response = await client.PostAsync(apiUrl + "/api/Saklama/MusterilerListesi", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<PagingResponse<MusteriBilgileriResponse>>(responseContent));
        }

        public async Task<ApiResponse> YasalDisDerinligiGetir()
        {
            var Client = await GetClient();
            var response = await Client.GetAsync(apiUrl + "/api/Saklama/YasalDisDeriniligiGetir");
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck(responseContent));
        }

        public async Task<ApiResponseGeneric<PlakaSorguResponse>> PlakaSorgula(SaklamaPlakaSorgulaRequest request)
        {
            var Client = await GetClient();
            var response = await Client.GetAsync(apiUrl + $"/api/Saklama/SaklamaPlakaSorgula?lngDistkod={request.lngDistKod}&txtPlaka={request.txtPlaka}");
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<PlakaSorguResponse>(responseContent));
        }

        public async Task<ApiResponseGeneric<List<AracUzerindekilerResponse>>> AracUzerindekileriGetir(SaklamaPlakaSorgulaRequest request)
        {
            var Client = await GetClient();
            var response = await Client.GetAsync(apiUrl + $"/api/Saklama/AracUzerindekileriGetir?lngDistkod={request.lngDistKod}&txtPlaka={request.txtPlaka}");
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<List<AracUzerindekilerResponse>>(responseContent));
        }

        public async Task<ApiResponseGeneric<int>> YeniSaklamaEkle(SaklamaBaslikRequest request)
        {
            var client = await GetClient();
            var response = await client.PostAsync(apiUrl + "/api/Saklama/YeniSaklamaEkle", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<int>(responseContent));
        }

        public async Task<ApiResponseGeneric<SaklamaBaslikResponse>> YeniSaklamaDuzenle(SaklamaBaslikRequest request)
        {
            var client = await GetClient();
            var response = await client.PostAsync(apiUrl + "/api/Saklama/YeniSaklamaDuzenle", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<SaklamaBaslikResponse>(responseContent));
        }

        public async Task<ApiResponseGeneric<bool>> ElTerminaliLastikRafGuncelle(LastikRafGuncelleRequest request)
        {
            var client = await GetClient();
            var response = await client.PostAsync(apiUrl + "/api/Saklama/ElTerminaliLastikRafGuncelle", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<bool>(responseContent));
        }

    }
}
