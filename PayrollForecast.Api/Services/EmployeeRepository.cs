using Microsoft.EntityFrameworkCore;
using PayrollForecast.Api.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Services
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Employee employee)
        {
            await _context.AddAsync(employee);
        }

        public void Remove(Employee employee)
        {
            _context.Remove(employee);
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Employees.AnyAsync(e => e.Id == id);
        }

        public async Task<Employee> GetById(int id)
        {
            return await _context.Employees.Include("Dependents").FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await _context.Employees.Include("Dependents").ToListAsync();
        }

        public async Task Update(Employee employee)
        {
            var updateEmployee = await _context.Employees.FirstAsync(e => e.Id == employee.Id);

            updateEmployee.FirstName = employee.FirstName;
            updateEmployee.LastName = employee.LastName;
        }
    }
}
