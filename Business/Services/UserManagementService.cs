using JWT.Business.Contracts;
using JWT.Models.Models;
using JWT.Repository.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Business.Services
{
    public class UserManagementService : IUserManagementService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public UserManagementService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public List<Employee> GetEmployees()
        {
            return _employeeRepository.GetAllAsync();
        }
    }
}
