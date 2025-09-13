using Microsoft.EntityFrameworkCore;
using StudentsManager.Domain.Models;

namespace StudentsManager.Infrastructure.DbContexts
{
    /// <summary>
    /// Контекст базы данных студентов
    /// </summary>
    internal class StudentsDbContext: DbContext
    {
        public StudentsDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Curator> Curators { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Specialty> Specialties { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;

    }
}
