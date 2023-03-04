using Microsoft.EntityFrameworkCore;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData
{
    public class StudentsContext : DbContext
    {
        public DbSet<Diploma> Diplomas { get; set; } = null!;
        public DbSet<Email> Emails { get; set; } = null!;
        public DbSet<Group> Groups { get; set; } = null!;
        public DbSet<Hobby> Hobbies { get; set; } = null!;
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Phone> Phones { get; set; } = null!;
        public DbSet<Relation> Relations { get; set; } = null!;
        public DbSet<School> Schools { get; set; } = null!;
        public DbSet<Specialty> Specialties { get; set; } = null!;
        public DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Students.db");
        }
    }
}
