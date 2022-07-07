using JWT.Models.Data;
using JWT.Models.Models;
using JWT.Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JWT.Repository.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly JWTAuthenticationContext _context;

        public EmployeeRepository(JWTAuthenticationContext context)
        {
            _context = context;
        }
        public async Task<bool> AddEmployeAsync(Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            Employee? employeeEntity = await _context.Employees.FindAsync(id);

            if (employeeEntity == null) throw new ArgumentNullException();

            _context.Employees.Remove(employeeEntity);

            return await _context.SaveChangesAsync() > 0;
        }

        public bool ExistsEmployee(int id)
        {
            return _context.Employees.Any(q => q.EmployeeId == id);
        }

        public List<Employee> GetAllAsync()
        {
            return _context.Employees.ToList();
        }

        public async Task<Employee> GetByIdAsync(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<bool> UpdateEmployeeAsync(Employee employee)
        {
            _context.Entry(employee).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return await _context.SaveChangesAsync() > 0;

        }
    }
}
