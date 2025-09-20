using Microsoft.EntityFrameworkCore;
using StudentsManager.Application.Common.Interfaces.Repositories;
using StudentsManager.Domain.Models;
using StudentsManager.Infrastructure.DbContexts;

namespace StudentsManager.Infrastructure.Repositories
{
    internal class PersonRepository : IPersonRepository
    {
        private readonly StudentsDbContext _context;

        public PersonRepository(StudentsDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.AsNoTracking().ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task CreateAsync(Person entity)
        {
            await _context.Persons.AddAsync(entity);
        }

        public async Task UpdateAsync(Person entity)
        {
            _context.Persons.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Person entity)
        {
            _context.Persons.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
