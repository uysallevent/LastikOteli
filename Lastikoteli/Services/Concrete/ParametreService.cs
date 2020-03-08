using Lastikoteli.Helper.ServiceHelper;
using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Services.Abstract;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Lastikoteli.Services.Concrete
{
    public class ParametreService : ServiceManager, IParametreService
    {
        public async Task<ApiResponseGeneric<ObservableCollection<MarkaBilgiResponse>>> MarkaBilgiGetir(MarkaBilgiRequest request)
        {
            var Client = await GetClient();
            var response = await Client.GetAsync(apiUrl + "/api/Parametre/MarkaBilgileriGetir" + MarkaBilgiRequestModelOlustur(request));
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<ObservableCollection<MarkaBilgiResponse>>(responseContent));
        }

        public async Task<ApiResponseGeneric<ObservableCollection<KeyValuePair<string, string>>>> DesenBilgileriGetir(DesenRequest request)
        {
            var Client = await GetClient();
            var response = await Client.GetAsync(apiUrl + $"/api/Parametre/EtiketBilgiGetir?lngDistKod={request.lngDistKod}&lngSaklamaBaslik={request.lngSaklamaBaslik}");
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<ObservableCollection<KeyValuePair<string, string>>>(responseContent));
        }

        public async Task<ApiResponseGeneric<SiraKolayKodDesenBilgiResponse>> SiraKolayKodDesenBilgiGetir()
        {
            var Client = await GetClient();
            var response = await Client.GetAsync(apiUrl + "/api/Parametre/SiraKolayKodDesenBilgiGetir");
            var responseContent = await response.Content.ReadAsStringAsync();
            return await Task.FromResult(ApiResultCheck.ResultCheck<SiraKolayKodDesenBilgiResponse>(responseContent));
        }

        private string MarkaBilgiRequestModelOlustur(MarkaBilgiRequest request)
        {
            string response = "?";

            foreach (var item in request.GetType().GetProperties().ToList())
            {
                if (item.Name == "lngUrunTip")
                {
                    response += $"lngruntTip={request.lngUrunTip}&";
                }

                if (item.Name == "txtMarka")
                {
                    response += $"txtMarka={request.txtMarka}&";
                }

                if (item.Name == "txtTaban")
                {
                    response += $"txtTaban={request.txtTaban}&";
                }

                if (item.Name == "txtKesit")
                {
                    response += $"txtKesit={request.txtKesit}&";
                }

                if (item.Name == "txtCap")
                {
                    response += $"txtCap={request.txtCap}&";
                }

                if (item.Name == "txtMevsim")
                {
                    response += $"txtMevsim={request.txtMevsim}&";
                }

                if (item.Name == "txtDesen")
                {
                    response += $"txtDesen={request.txtDesen}";
                }
            }
            return response;
        }
    }
}