using BitoDesktop.Service.DTOs.Auth;
using BitoDesktop.Service.DTOs.Common;
using BitoDesktop.Service.DTOs.Hr;
using BitoDesktop.Service.DTOs.Settings;
using BitoDesktop.Service.DTOs.WarehouseP;
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
        Task<List<UsernameResponse>> GetUsernames(string phoneNumber, string password);
        Task<List<OrganizationResponse>> GetOrganizations();
        Task<PagingResponse<WarehouseResponse>> GetWareHouses();
        Task<List<PriceResponse>> GetPrices();
        Task<EmployeeResponse> EnterByPinCode(string pincode);
    }
}
