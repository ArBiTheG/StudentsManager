using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Curator>> GetAllAsync()
        {
            return await _context.Curators.AsNoTracking().ToListAsync();
        }

        public async Task<Curator?> GetByIdAsync(int id)
        {
            return await _context.Curators.FindAsync(id);
        }

        public async Task CreateAsync(Curator entity)
        {
            await _context.Curators.AddAsync(entity);
        }

        public async Task UpdateAsync(Curator entity)
        {
            _context.Curators.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Curator entity)
        {
            _context.Curators.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
