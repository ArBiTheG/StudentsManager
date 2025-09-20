using StudentsManager.Application.Common.Interfaces.Repositories;
using StudentsManager.Domain.Models;
using StudentsManager.Infrastructure.DbContexts;

namespace StudentsManager.Infrastructure.Repositories
{
    internal class CuratorRepository : ICuratorRepository
    {
        private readonly StudentsDbContext _context;

        public CuratorRepository(StudentsDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(Curator entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Curator entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Curator>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Curator?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Curator entity)
        {
            throw new NotImplementedException();
        }
    }
}
