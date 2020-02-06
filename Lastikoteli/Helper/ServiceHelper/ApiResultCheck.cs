using Lastikoteli.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lastikoteli.Helper.ServiceHelper
{
    public static class ApiResultCheck
    {
        //Servisten dönen model içeriğinde Result Status 500 durumunda ilgili model yerine hata mesajını barındırdığı için 
        //JsonConvert aşamasında hata vermemesi için kontrol burada sağlanmaktadır
        public static ApiResponseGeneric<T> ResultCheck<T>(string responseContent) where T : class, new()
        {
            var response = new ApiResponseGeneric<T>();
            var responseResult = JsonConvert.DeserializeObject<ApiResponse>(responseContent);
            if (responseResult.StatusCode == 500)
                return new ApiResponseGeneric<T>
                {
                    RequestId = responseResult.RequestId,
                    Version = responseResult.Version,
                    ErrorMessage = responseResult.ErrorMessage,
                    StatusCode = responseResult.StatusCode,
                    Result = new T()
                };

            if (responseResult.StatusCode == 200)
                return JsonConvert.DeserializeObject<ApiResponseGeneric<T>>(responseContent);

            return JsonConvert.DeserializeObject<ApiResponseGeneric<T>>("");
        }
    }
}
