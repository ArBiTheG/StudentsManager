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

        public void Create(Group entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Group entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetAll()
        {
            throw new NotImplementedException();
        }

        public Group? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Group entity)
        {
            throw new NotImplementedException();
        }
    }
}
