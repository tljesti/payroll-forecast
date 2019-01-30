using Microsoft.EntityFrameworkCore;
using PayrollForecast.Api.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayrollForecast.Api.Services
{
    public class DependentRepository : IDependentRepository
    {
        private readonly ApplicationDbContext _context;

        public DependentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Dependent>> GetDependentsByEmployeeId(int id)
        {
            return await _context.Dependents.Where(d => d.EmployeeId == id).ToListAsync();
        }

        public async Task<Dependent> GetDependentById(int id)
        {
            return await _context.Dependents.Where(d => d.Id == id).FirstOrDefaultAsync();
        }

        public async Task Add(Dependent dependent)
        {
            await _context.AddAsync(dependent);
        }

        public async Task<bool> Exists(int id)
        {
            return await _context.Dependents.AnyAsync(e => e.Id == id);
        }

        public async Task Update(Dependent dependent)
        {
            var updateDependent = await _context.Dependents.FirstAsync(d => d.Id == dependent.Id);

            updateDependent.FirstName = dependent.FirstName;
            updateDependent.LastName = dependent.LastName;
        }

        public void Remove(Dependent dependent)
        {
            _context.Remove(dependent);
        }
    }
}
