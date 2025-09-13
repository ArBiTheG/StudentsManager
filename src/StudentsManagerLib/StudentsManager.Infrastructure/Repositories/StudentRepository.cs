using StudentsManager.Application.Common.Interfaces.Repositories;
using StudentsManager.Domain.Models;
using StudentsManager.Infrastructure.DbContexts;

namespace StudentsManager.Infrastructure.Repositories
{
    internal class StudentRepository : IStudentRepository
    {
        private readonly StudentsDbContext _context;

        public StudentRepository(StudentsDbContext context)
        {
            _context = context;
        }

        public void Create(Student entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(Student entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
            throw new NotImplementedException();
        }

        public Student? GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
