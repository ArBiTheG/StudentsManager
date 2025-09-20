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

        public Task CreateAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Student entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Student>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Student?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Student entity)
        {
            throw new NotImplementedException();
        }
    }
}
