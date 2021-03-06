﻿using Lastikoteli.Models;
using Lastikoteli.Models.Complex.Request;
using Lastikoteli.Models.Complex.Response;
using Lastikoteli.Models.MiyaPortal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Lastikoteli.Services.Abstract
{
    public interface IAuthService
    {
        Task<ApiResponseGeneric<SessionInfo>> Login(LoginRequest request);
    }
}
