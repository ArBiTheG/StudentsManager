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

        public void Create(Curator entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Curator entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Curator> GetAll()
        {
            throw new NotImplementedException();
        }

        public Curator? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Curator entity)
        {
            throw new NotImplementedException();
        }
    }
}
