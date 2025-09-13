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

        public void Create(Person entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Person entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Person entity)
        {
            throw new NotImplementedException();
        }
    }
}
