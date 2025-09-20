using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<Student>> GetAllAsync()
        {
            return await _context.Students.AsNoTracking().ToListAsync();
        }

        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task CreateAsync(Student entity)
        {
            await _context.Students.AddAsync(entity);
        }

        public async Task UpdateAsync(Student entity)
        {
            _context.Students.Update(entity);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Student entity)
        {
            _context.Students.Remove(entity);
            await Task.CompletedTask;
        }
    }
}
