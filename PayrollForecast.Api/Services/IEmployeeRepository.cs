using PayrollForecast.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Services
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(int id);
        Task Add(Employee employee);
        Task<bool> Exists(int id);
        Task Update(Employee employee);
        void Remove(Employee employee);
    }
}
