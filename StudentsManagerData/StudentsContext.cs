using Microsoft.EntityFrameworkCore;
using StudentsManagerData.Table;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManagerData
{
    internal class StudentsContext : DbContext
    {
        /// <summary>
        /// Набор сущностей Diplomas
        /// </summary>
        public DbSet<Diploma> Diplomas { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Emails
        /// </summary>
        public DbSet<Email> Emails { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Emails
        /// </summary>
        public DbSet<Group> Groups { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Hobbies
        /// </summary>
        public DbSet<Hobby> Hobbies { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Persons
        /// </summary>
        public DbSet<Person> Persons { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Phones
        /// </summary>
        public DbSet<Phone> Phones { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Relations
        /// </summary>
        public DbSet<Relation> Relations { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Schools
        /// </summary>
        public DbSet<School> Schools { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Specialties
        /// </summary>
        public DbSet<Specialty> Specialties { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Students
        /// </summary>
        public DbSet<Student> Students { get; set; } = null!;


        public StudentsContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Установка первичного ключа для Diploma.Id
            modelBuilder.Entity<Diploma>().HasKey(u => u.Id);

            // Установка первичного ключа для Email.Id
            modelBuilder.Entity<Email>().HasKey(u => u.Id);

            // Установка первичного ключа для Group.Id
            modelBuilder.Entity<Group>().HasKey(u => u.Id);

            // Установка первичного ключа для Hobby.Id
            modelBuilder.Entity<Hobby>().HasKey(u => u.Id);

            // Установка первичного ключа для Person.Id
            modelBuilder.Entity<Person>().HasKey(u => u.Id);

            // Установка первичного ключа для Phone.Id
            modelBuilder.Entity<Phone>().HasKey(u => u.Id);

            // Установка первичного ключа для Relation.Id
            modelBuilder.Entity<Relation>().HasKey(u => u.Id);

            // Установка первичного ключа для School.Id
            modelBuilder.Entity<School>().HasKey(u => u.Id);

            // Установка первичного ключа для Specialty.Id
            modelBuilder.Entity<Specialty>().HasKey(u => u.Id);

            // Установка первичного ключа для Student.Id
            modelBuilder.Entity<Student>().HasKey(u => u.Id);


            // Установка уникальных ключей для Diploma.Series и Diploma.Number
            modelBuilder.Entity<Diploma>().HasAlternateKey(u => new { u.Series, u.Number });

            // Установка уникальных ключей для Email.PersonId и Email.Name
            modelBuilder.Entity<Email>().HasAlternateKey(u => new { u.PersonId, u.Name });

            // Установка уникальных ключей для Group.SpecialtyId и Group.Name
            modelBuilder.Entity<Group>().HasAlternateKey(u => new { u.SpecialtyId, u.Name });

            // Установка уникальных ключей для Hobby.PersonId и Hobby.Name
            modelBuilder.Entity<Hobby>().HasAlternateKey(u => new { u.PersonId, u.Name });

            // Установка уникальных ключей для Phone.PersonId и Phone.Name
            modelBuilder.Entity<Phone>().HasAlternateKey(u => new { u.PersonId, u.Name });

            // Установка уникальных ключей для Relation.ChildId и Relation.ParentId
            modelBuilder.Entity<Relation>().HasAlternateKey(u => new { u.ChildId, u.ParentId });

            // Установка уникальных ключей для School.FullName
            modelBuilder.Entity<School>().HasAlternateKey(u => new { u.FullName});

            // Установка уникальных ключей для Specialty.Code и Specialty.Name
            modelBuilder.Entity<Specialty>().HasAlternateKey(u => new { u.Code, u.Name });

            // Установка уникальных ключей для Student.PersonId и Student.GroupId
            modelBuilder.Entity<Student>().HasAlternateKey(u => new { u.PersonId, u.GroupId });


            // Подключение внешнего ключа от Hobby.Person к Person
            modelBuilder.Entity<Person>().HasMany(t => t.Hobbies)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);

            // Подключение внешнего ключа от Diploma.Person к Person
            modelBuilder.Entity<Person>().HasMany(t => t.Diplomas)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);

            // Подключение внешнего ключа от Email.Person к Person
            modelBuilder.Entity<Person>().HasMany(t => t.Emails)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);

            // Подключение внешнего ключа от Phone.Person к Person
            modelBuilder.Entity<Person>().HasMany(t => t.Phones)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);

            // Подключение внешнего ключа от Student.Person к Person
            modelBuilder.Entity<Person>().HasMany(t => t.Students)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);

            // Подключение внешнего ключа от Relation.Child к Person
            modelBuilder.Entity<Person>().HasMany(t => t.Childs)
                .WithOne(g => g.Child)
                .HasForeignKey(g => g.ChildId);

            // Подключение внешнего ключа от Relation.Parent к Person
            modelBuilder.Entity<Person>().HasMany(t => t.Parents)
                .WithOne(g => g.Parent)
                .HasForeignKey(g => g.ParentId);

            // Подключение внешнего ключа от Diploma.School к School
            modelBuilder.Entity<School>().HasMany(t => t.Diplomas)
                .WithOne(g => g.School)
                .HasForeignKey(g => g.SchoolId);

            // Подключение внешнего ключа от Student.Group к Group
            modelBuilder.Entity<Group>().HasMany(t => t.Students)
                .WithOne(g => g.Group)
                .HasForeignKey(g => g.GroupId);

            // Подключение внешнего ключа от Group.Specialties к Specialty
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
