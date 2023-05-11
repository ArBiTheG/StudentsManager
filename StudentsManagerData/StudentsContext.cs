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
using System.Windows.Input;

namespace StudentsManagerData
{
    internal class StudentsContext : DbContext
    {
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
        /// <summary>
        /// Набор сущностей Curators
        /// </summary>
        public DbSet<Curator> Curators { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Decrees
        /// </summary>
        public DbSet<Decree> Decrees { get; set; } = null!;


        public StudentsContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
#if DEBUG
            Trace.WriteLine("Инициализация первичных ключей");
#endif
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
            // Установка первичного ключа для Curator.Id
            modelBuilder.Entity<Curator>().HasKey(u => u.Id);
            // Установка первичного ключа для Decree.Id
            modelBuilder.Entity<Decree>().HasKey(u => u.Id);

#if DEBUG
            Trace.WriteLine("Инициализация уникальных ключей");
#endif

            // Установка уникального ключа для Student.PersonId
            modelBuilder.Entity<Student>().HasAlternateKey(u => u.PersonId );
            // Установка уникального ключа для Curator.PersonId
            modelBuilder.Entity<Curator>().HasAlternateKey(u => u.PersonId);


#if DEBUG
            Trace.WriteLine("Инициализация связей");
#endif
            // Подключение внешнего ключа от Hobby.Person к Person
            modelBuilder.Entity<Person>().HasMany(t => t.Hobbies)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);
            // Подключение внешнего ключа от Email.Person к Person  (1 - М)
            modelBuilder.Entity<Person>().HasMany(t => t.Emails)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);
            // Подключение внешнего ключа от Phone.Person к Person  (1 - М)
            modelBuilder.Entity<Person>().HasMany(t => t.Phones)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);
            // Подключение внешнего ключа от Relation.Child к Person  (1 - М)
            modelBuilder.Entity<Person>().HasMany(t => t.Childs)
                .WithOne(g => g.Child)
                .HasForeignKey(g => g.ChildId);
            // Подключение внешнего ключа от Relation.Parent к Person  (1 - М)
            modelBuilder.Entity<Person>().HasMany(t => t.Parents)
                .WithOne(g => g.Parent)
                .HasForeignKey(g => g.ParentId);
            // Подключение внешнего ключа от Student.Person к Person (1 - M)
            modelBuilder.Entity<Person>().HasMany(t => t.Students)
                .WithOne(g => g.Person)
                .HasForeignKey(g => g.PersonId);

            // Подключение внешнего ключа от Curator.Person к Person (1 - 1)
            modelBuilder.Entity<Person>().HasOne(t => t.Curator)
                .WithOne(g => g.Person)
                .HasForeignKey<Curator>(g => g.PersonId);
            // Подключение внешнего ключа от Decree.Student к Student (1 - 1)
            modelBuilder.Entity<Student>().HasMany(t => t.Decrees)
                .WithOne(g => g.Student)
                .HasForeignKey(g => g.StudentId);
            // Подключение внешнего ключа от Student.Group к Group  (1 - М)
            modelBuilder.Entity<Group>().HasMany(t => t.Students)
                .WithOne(g => g.Group)
                .HasForeignKey(g => g.GroupId);
            // Подключение внешнего ключа от Group.Specialties к Specialty  (1 - М)
            modelBuilder.Entity<Specialty>().HasMany(t => t.Groups)
                .WithOne(g => g.Specialty)
                .HasForeignKey(g => g.SpecialtyId);

            // Подключение внешнего ключа от Person.EducationSchool к School (1 - M)
            modelBuilder.Entity<School>().HasMany(t => t.Persons)
                .WithOne(g => g.EducationSchool)
                .HasForeignKey(g => g.EducationSchoolId);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Students.db");
        }
    }
}
