using StudentsManager.Application.Common.Interfaces.Repositories;
using StudentsManager.Domain.Models;
using StudentsManager.Infrastructure.DbContexts;

namespace StudentsManager.Infrastructure.Repositories
{
    internal class SpecialtyRepository : ISpecialtyRepository
    {
        private readonly StudentsDbContext _context;

        public SpecialtyRepository(StudentsDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(Specialty entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Specialty entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Specialty>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Specialty?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Specialty entity)
        {
            throw new NotImplementedException();
        }
    }
}
