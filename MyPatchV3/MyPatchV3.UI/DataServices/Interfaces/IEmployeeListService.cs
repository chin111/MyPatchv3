using MyPatchV3.UI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyPatchV3.UI.DataServices.Interfaces
{
    public interface IEmployeeListService
    {
        Task<IEnumerable<Employee>> GetEmployees();
    }
}
