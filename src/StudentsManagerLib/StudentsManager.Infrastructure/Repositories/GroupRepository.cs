using StudentsManager.Application.Common.Interfaces.Repositories;
using StudentsManager.Domain.Models;
using StudentsManager.Infrastructure.DbContexts;

namespace StudentsManager.Infrastructure.Repositories
{
    internal class GroupRepository : IGroupRepository
    {
        private readonly StudentsDbContext _context;

        public GroupRepository(StudentsDbContext context)
        {
            _context = context;
        }

        public Task CreateAsync(Group entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Group entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Group>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Group?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
