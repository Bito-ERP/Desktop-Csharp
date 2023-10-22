using BitoDesktop.Service.DTOs.Auth;
using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Hr;
using BitoDesktop.Service.DTOs.Settings;
using BitoDesktop.Service.DTOs.WarehouseP;
using BitoDesktop.Service.Exceptions;
using BitoDesktop.Service.Http;
using BitoDesktop.Service.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services
{
    public class AuthService : IAuthService
    {
        public async Task<string> LoginAsync(RequestLogin request)
        {
            var responce = await AuthApi.Login(request);
            if (responce.Message != "Success")
                throw new MarketException(responce.Code, responce.Message);

            return responce.Data;
        }

        public async Task<PagingResponse<DeviceResponse>> GetDevices(string phonenumber)
        {
            var responce = await DeviceApi.GetPage(new RequestPage()
            {
                PhoneNumber = phonenumber
            });
            if (responce.Message != "Success")
                throw new MarketException(responce.Code, responce.Message);

            return responce.Data;
        }

        public async Task<List<UsernameResponse>> GetUsernames(string phoneNumber, string password)
        {
            var responce = await AuthApi.GetUsernames(new RequestLogin()
            {
                PhoneNumber = phoneNumber,
                Password = password
            });

            if (responce.Message != "Success")
                throw new MarketException(responce.Code, responce.Message);

            return responce.Data;
        }

        public async Task<List<OrganizationResponse>> GetOrganizations()
        {
            var responce = await OrganizationApi.GetAll();

            if (responce.Message != "Success")
                throw new MarketException(responce.Code, responce.Message);

            return responce.Data;
        }

        public async Task<PagingResponse<WarehouseResponse>> GetWareHouses()
        {
            var responce = await WarehouseApi.GetPage(new RequestPage());

            if (responce.Message != "Success")
                throw new MarketException(responce.Code, responce.Message);

            return responce.Data;
        }

        public async Task<List<PriceResponse>> GetPrices()
        {
            var responce = await PriceApi.GetAll();

            if (responce.Message != "Success")
                throw new MarketException(responce.Code, responce.Message);

            return responce.Data;
        }

        public async Task<EmployeeResponse> EnterByPinCode(string pincode)
        {
            var responce = await EmployeeApi.GetByPincode(new RequestLogin() { Pincode = pincode });

            if (responce.Message != "Success")
                throw new MarketException(responce.Code, responce.Message);

            return responce.Data;
        }
    }
}
