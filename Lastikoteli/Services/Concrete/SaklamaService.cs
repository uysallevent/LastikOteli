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
            var response = await Client.GetStringAsync(APIUrl + $"/api/Saklama/SaklamaKayitGetir?lngDistKod={request.lngDistKod}&lngSaklamaBaslik={request.lngSaklamaBaslik}");
            return await Task.FromResult(ApiResultCheck.ResultCheck<SaklamaBilgileriResponse>(response));
        }

        public async Task<ApiResponseGeneric<List<SaklamaBilgileriResponse>>> SaklamadaKayitArama(SaklamaBilgiRequest request)
        {
            var Client = await GetClient();
            var path = (!string.IsNullOrEmpty(request.txtPlaka)) ?
                $"/api/Saklama/SaklamadaKayitArama?lngDistKod={request.lngDistKod}&txtPlaka={request.txtPlaka.ToLower()}" :
                $"/api/Saklama/SaklamadaKayitArama?lngDistKod={request.lngDistKod}&lngSaklamaBaslik={request.lngSaklamaBaslik}";

            var response = await Client.GetAsync(APIUrl + path);
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<List<SaklamaBilgileriResponse>>(responseContent));
        }

        public async Task<ApiResponseGeneric<bool>> LastikTeslimEt(LastikTeslimRequest request)
        {
            var client = await GetClient();
            var response = await client.PostAsync(APIUrl + "/api/Saklama/ElTerminaliLastikTeslimEtme", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<bool>(responseContent));
        }
    }
}
