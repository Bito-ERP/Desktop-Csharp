using BitoDesktop.Service.DTOs.Auth;
using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.Exceptions;
using BitoDesktop.Service.Http;
using BitoDesktop.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services
{
    public class AuthService : IAuthService
    {
        public async Task<string> LoginAsync(RequestLogin request)
        {
            var responce = await AuthApi.Login(request);
            if (responce.Message != "Success")
            {
                throw new MarketException(responce.Code,responce.Message);
            }
            return responce.Data;
        }

        public async Task<PagingResponse<DeviceResponse>> GetDevices(string phonenumber)
        {
            var responce = await DeviceApi.GetPage(new RequestPage()
            {
                PhoneNumber = phonenumber
            });
            if (responce.Message != "Success")
            {
                throw new MarketException(responce.Code, responce.Message);
            }
            return responce.Data;
        }
    }
}
