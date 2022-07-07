using JWT.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Repository.Contract
{
    public interface IEmployeeRepository
    {
        List<Employee> GetAllAsync();

        Task<Employee> GetByIdAsync(int id);

        Task<bool> AddEmployeAsync(Employee employee);

        Task<bool> UpdateEmployeeAsync(Employee employee);

        Task<bool> DeleteEmployee(int id);

        bool ExistsEmployee(int id);


    }
}
