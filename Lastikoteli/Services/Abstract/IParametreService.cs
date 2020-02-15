using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;

namespace Lastikoteli.Services.Abstract
{
    public interface IParametreService
    {
        Task<ApiResponseGeneric<List<MarkaBilgiResponse>>> MarkaBilgiGetir(MarkaBilgiRequest request);
    }
}
