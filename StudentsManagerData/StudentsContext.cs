using Microsoft.EntityFrameworkCore;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
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

        public StudentsContext()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Расстановка первичных ключей
            modelBuilder.Entity<Diploma>().HasKey(u => u.Id);
            modelBuilder.Entity<Email>().HasKey(u => u.Id);
            modelBuilder.Entity<Group>().HasKey(u => u.Id);
            modelBuilder.Entity<Hobby>().HasKey(u => u.Id);
            modelBuilder.Entity<Person>().HasKey(u => u.Id);
            modelBuilder.Entity<Phone>().HasKey(u => u.Id);
            modelBuilder.Entity<Relation>().HasKey(u => u.Id);
            modelBuilder.Entity<School>().HasKey(u => u.Id);
            modelBuilder.Entity<Specialty>().HasKey(u => u.Id);
            modelBuilder.Entity<Student>().HasKey(u => u.Id);
            // Установка связей Person
            modelBuilder.Entity<Person>().HasMany(t => t.Hobbies)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);
            modelBuilder.Entity<Person>().HasMany(t => t.Diplomas)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);
            modelBuilder.Entity<Person>().HasMany(t => t.Emails)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);
            modelBuilder.Entity<Person>().HasMany(t => t.Phones)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);
            modelBuilder.Entity<Person>().HasMany(t => t.Students)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);
            modelBuilder.Entity<Person>().HasMany(t => t.Childs)
                .WithOne(g => g.Child)
                .HasForeignKey(g => g.ChildId);
            modelBuilder.Entity<Person>().HasMany(t => t.Parents)
                .WithOne(g => g.Parent)
                .HasForeignKey(g => g.ParentId);
            // Установка связей School
            modelBuilder.Entity<School>().HasMany(t => t.Diplomas)
                .WithOne(g => g.School)
                .HasForeignKey(g => g.SchoolId);
            // Установка связей Group
            modelBuilder.Entity<Group>().HasMany(t => t.Students)
                .WithOne(g => g.Group)
                .HasForeignKey(g => g.GroupId);
            // Установка связей Specialty
            modelBuilder.Entity<Specialty>().HasMany(t => t.Groups)
                .WithOne(g => g.Specialty)
                .HasForeignKey(g => g.SpecialtyId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Students.db");
        }
    }
}
