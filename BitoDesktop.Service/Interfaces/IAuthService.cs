using BitoDesktop.Service.DTOs.Auth;
using BitoDesktop.Service.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Interfaces
{
    public interface IAuthService
    {
        Task<string> LoginAsync(RequestLogin request);
        Task<PagingResponse<DeviceResponse>> GetDevices(string phonenumber);
    }
}
