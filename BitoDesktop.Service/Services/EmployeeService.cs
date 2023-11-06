using BitoDesktop.Data.Repositories.Hr;
using BitoDesktop.Service.Exceptions;
using BitoDesktop.Service.Extensions;
using BitoDesktop.Service.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitoDesktop.Service.Services
{
    public class EmployeeService
    {
        private readonly EmployeeRepository employeeRepository;
        private readonly ConfigurationService configurationService;
        public EmployeeService()
        {
            configurationService = new ConfigurationService();
            employeeRepository = new EmployeeRepository();
        }

        public async Task<bool> CheckPinCode(string pincode)
        {
            var employeeId = await configurationService.Get("employee");
            var employee = await employeeRepository.Get(employeeId);

            if(employee.Pincode == pincode.GetHash())
                return true;

            throw new MarketException(400,"Pincode is wrong");
        }
    }
}
