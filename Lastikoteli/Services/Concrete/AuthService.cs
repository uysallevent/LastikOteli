using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Models.MiyaPortal;
using Lastikoteli.Services.Abstract;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lastikoteli.Services.Concrete
{
    public class AuthService : ServiceManager, IAuthService<TerminalKullanici>
    {
        public async Task<ApiResponse> GetList(TerminalKullaniciListeRequest requets)
        {
            var client = await GetClient();
            var response = client.PostAsync(APIUrl + "/api/Kullanici/TerminalKullaniciListe", new StringContent(JsonConvert.SerializeObject(requets), Encoding.UTF8, "application/json")).Result;
            var ResponseContent = await response.Content.ReadAsStringAsync();

            return await Task.FromResult(JsonConvert.DeserializeObject<ApiResponse>(ResponseContent));
        }

        public async Task<ApiResponseGeneric<TerminalGirisResponse>> Login(LoginRequest request)
        {
            var client = await GetClient();
            var response = await client.PostAsync(APIUrl + "/api/Kullanici/ElTermimnaliGirisi", new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json"));
            var responseContent = await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<ApiResponseGeneric<TerminalGirisResponse>>(responseContent).StatusCode;
            return await Task.FromResult(JsonConvert.DeserializeObject<ApiResponseGeneric<TerminalGirisResponse>>(responseContent));
        }


    }
}
