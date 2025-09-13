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

        public void Create(Specialty entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Specialty entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Specialty> GetAll()
        {
            throw new NotImplementedException();
        }

        public Specialty? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Specialty entity)
        {
            throw new NotImplementedException();
        }
    }
}
