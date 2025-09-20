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

        public Task CreateAsync(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Person entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Person?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
