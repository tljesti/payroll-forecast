using System.Threading.Tasks;

namespace PayrollForecast.Api.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IEmployeeRepository Employees { get; private set; }
        public IDependentRepository Dependents { get; private set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Employees = new EmployeeRepository(context);
            Dependents = new DependentRepository(context);
        }

        public async Task<bool> Complete()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
