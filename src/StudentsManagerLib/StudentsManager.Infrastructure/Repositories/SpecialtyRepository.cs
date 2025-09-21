using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Specialty>> GetAllAsync()
        {
            return await _context.Specialties.AsNoTracking().ToListAsync();
        }

        public async Task<Specialty?> GetByIdAsync(int id)
        {
            return await _context.Specialties.FindAsync(id);
        }

        public async Task CreateAsync(Specialty entity)
        {
            await _context.Specialties.AddAsync(entity);
        }

        public async Task UpdateAsync(Specialty entity)
        {
            _context.Specialties.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Specialty entity)
        {
            _context.Specialties.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
