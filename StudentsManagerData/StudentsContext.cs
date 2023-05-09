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
        /// <summary>
        /// Набор сущностей Curators
        /// </summary>
        public DbSet<Curator> Curators { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Decrees
        /// </summary>
        public DbSet<Decree> Decrees { get; set; } = null!;
        /// <summary>
        /// Набор сущностей INNs
        /// </summary>
        public DbSet<INN> INNs { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Invalids
        /// </summary>
        public DbSet<Invalid> Invalids { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Passports
        /// </summary>
        public DbSet<Passport> Passports { get; set; } = null!;
        /// <summary>
        /// Набор сущностей Snilses
        /// </summary>
        public DbSet<Snils> Snilses { get; set; } = null!;


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
            // Установка первичного ключа для Curator.Id
            modelBuilder.Entity<Curator>().HasKey(u => u.Id);
            // Установка первичного ключа для Decree.Id
            modelBuilder.Entity<Decree>().HasKey(u => u.Id);
            // Установка первичного ключа для INN.Id
            modelBuilder.Entity<INN>().HasKey(u => u.Id);
            // Установка первичного ключа для Invalid.Id
            modelBuilder.Entity<Invalid>().HasKey(u => u.Id);
            // Установка первичного ключа для Passport.Id
            modelBuilder.Entity<Passport>().HasKey(u => u.Id);
            // Установка первичного ключа для Snils.Id
            modelBuilder.Entity<Snils>().HasKey(u => u.Id);

#if DEBUG
            Trace.WriteLine("Инициализация уникальных ключей");
#endif

            // Установка уникального ключа для Student.PersonId
            modelBuilder.Entity<Student>().HasAlternateKey(u => u.PersonId );
            // Установка уникального ключа для Curator.PersonId
            modelBuilder.Entity<Curator>().HasAlternateKey(u => u.PersonId);
            // Установка уникального ключа для INN.PersonId
            modelBuilder.Entity<INN>().HasAlternateKey(u => u.PersonId);
            // Установка уникального ключа для Passport.PersonId
            modelBuilder.Entity<Passport>().HasAlternateKey(u => u.PersonId);
            // Установка уникального ключа для Snils.PersonId
            modelBuilder.Entity<Snils>().HasAlternateKey(u => u.PersonId);
            // Установка уникального ключа для Invalid.PersonId
            modelBuilder.Entity<Invalid>().HasAlternateKey(u => u.PersonId);
            // Установка уникального ключа для Diploma.PersonId
            modelBuilder.Entity<Diploma>().HasAlternateKey(u => u.PersonId);


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
            // Подключение внешнего ключа от Diploma.Person к Person  (1 - 1)
            modelBuilder.Entity<Person>().HasOne(t => t.Diploma)
                .WithOne(g => g.Person)
                .HasForeignKey<Diploma>(g => g.PersonId);
            // Подключение внешнего ключа от Student.Person к Person (1 - 1)
            modelBuilder.Entity<Person>().HasOne(t => t.Student)
                .WithOne(g => g.Person)
                .HasForeignKey<Student>(g => g.PersonId);
            // Подключение внешнего ключа от Curator.Person к Person (1 - 1)
            modelBuilder.Entity<Person>().HasOne(t => t.Curator)
                .WithOne(g => g.Person)
                .HasForeignKey<Curator>(g => g.PersonId);
            // Подключение внешнего ключа от Snils.Person к Person (1 - 1)
            modelBuilder.Entity<Person>().HasOne(t => t.Snils)
                .WithOne(g => g.Person)
                .HasForeignKey<Snils>(g => g.PersonId);
            // Подключение внешнего ключа от Snils.Person к Person (1 - 1)
            modelBuilder.Entity<Person>().HasOne(t => t.Invalid)
                .WithOne(g => g.Person)
                .HasForeignKey<Invalid>(g => g.PersonId);
            // Подключение внешнего ключа от Passport.Person к Person (1 - 1)
            modelBuilder.Entity<Person>().HasOne(t => t.Passport)
                .WithOne(g => g.Person)
                .HasForeignKey<Passport>(g => g.PersonId);
            // Подключение внешнего ключа от Decree.Student к Student (1 - 1)
            modelBuilder.Entity<Student>().HasMany(t => t.Decrees)
                .WithOne(g => g.Student)
                .HasForeignKey(g => g.StudentId);
            // Подключение внешнего ключа от Diploma.School к School  (1 - М)
            modelBuilder.Entity<School>().HasMany(t => t.Diplomas)
                .WithOne(g => g.School)
                .HasForeignKey(g => g.SchoolId);
            // Подключение внешнего ключа от Student.Group к Group  (1 - М)
            modelBuilder.Entity<Group>().HasMany(t => t.Students)
                .WithOne(g => g.Group)
                .HasForeignKey(g => g.GroupId);
            // Подключение внешнего ключа от Group.Specialties к Specialty  (1 - М)
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
