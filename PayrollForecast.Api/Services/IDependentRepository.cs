using PayrollForecast.Api.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Services
{
    public interface IDependentRepository
    {
        Task<IEnumerable<Dependent>> GetDependentsByEmployeeId(int id);
        Task<Dependent> GetDependentById(int id);
        Task Add(Dependent dependent);
        Task<bool> Exists(int id);
        Task Update(Dependent dependent);
        void Remove(Dependent dependent);
    }
}
