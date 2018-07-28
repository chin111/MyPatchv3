using MyPatchV3.UI.DataServices.Base;
using MyPatchV3.UI.DataServices.Interfaces;
using MyPatchV3.UI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPatchV3.UI.DataServices
{
    public class EmployeeListService : IEmployeeListService
    {
        private readonly IRequestProvider _requestProvider;
        private readonly IAuthenticationService _authenticationService;

        public EmployeeListService(IRequestProvider requestProvider, IAuthenticationService authenticationService)
        {
            _requestProvider = requestProvider;
            _authenticationService = authenticationService;
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            var userId = _authenticationService.GetCurrentUserId();

            var data = new EmployeeListRequest
            {
                SupervisorID = userId
            };

            UriBuilder builder = new UriBuilder(GlobalSettings.EmployeeListEndpoint);
            builder.Path = "MyPatchAPI/api/employeelist";

            string uri = builder.ToString();

            IEnumerable<Employee> employees = await _requestProvider.PostAsync<EmployeeListRequest, IEnumerable<Employee>>(uri, data);

            return employees;
        }
    }
}
