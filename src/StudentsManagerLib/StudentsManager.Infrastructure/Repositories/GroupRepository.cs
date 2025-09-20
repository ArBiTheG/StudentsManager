using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _context.Groups.AsNoTracking().ToListAsync();
        }

        public async Task<Group?> GetByIdAsync(int id)
        {
            return await _context.Groups.FindAsync(id);
        }

        public async Task CreateAsync(Group entity)
        {
            await _context.Groups.AddAsync(entity);
        }

        public async Task UpdateAsync(Group entity)
        {
            _context.Groups.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Group entity)
        {
            _context.Groups.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
