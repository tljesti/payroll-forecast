using System.Threading.Tasks;

namespace PayrollForecast.Api.Services
{
    public interface IUnitOfWork
    {
        IEmployeeRepository Employees { get; }
        IDependentRepository Dependents { get; }
        Task<bool> Complete();
    }
}
