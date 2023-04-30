﻿using Microsoft.EntityFrameworkCore;
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
    public class StudentsContext : DbContext, IStudentsData
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
            //Database.EnsureDeleted();
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

        public ObservableCollection<Diploma> GetDiplomas()
        {
#if DEBUG
            Trace.WriteLine($"Создана коллекция объектов: '{nameof(Diplomas)}'");
#endif
            Diplomas.Load();
            return Diplomas.Local.ToObservableCollection();
        }

        public ObservableCollection<Email> GetEmails()
        {
#if DEBUG
            Trace.WriteLine($"Создана коллекция объектов: '{nameof(Emails)}'");
#endif
            Emails.Load();
            return Emails.Local.ToObservableCollection();
        }

        public ObservableCollection<Group> GetGroups()
        {
#if DEBUG
            Trace.WriteLine($"Создана коллекция объектов: '{nameof(Groups)}'");
#endif
            Groups.Load();
            return Groups.Local.ToObservableCollection();
        }

        public ObservableCollection<Hobby> GetHobbies()
        {
#if DEBUG
            Trace.WriteLine($"Создана коллекция объектов: '{nameof(Hobbies)}'");
#endif
            Hobbies.Load();
            return Hobbies.Local.ToObservableCollection();
        }

        public ObservableCollection<Person> GetPersons()
        {
#if DEBUG
            Trace.WriteLine($"Создана коллекция объектов: '{nameof(Persons)}'");
#endif
            Persons.Load();
            return Persons.Local.ToObservableCollection();
        }

        public ObservableCollection<Phone> GetPhones()
        {
#if DEBUG
            Trace.WriteLine($"Создана коллекция объектов: '{nameof(Phones)}'");
#endif
            Phones.Load();
            return Phones.Local.ToObservableCollection();
        }

        public ObservableCollection<Relation> GetRelations()
        {
#if DEBUG
            Trace.WriteLine($"Создана коллекция объектов: '{nameof(Relations)}'");
#endif
            Relations.Load();
            return Relations.Local.ToObservableCollection();
        }

        public ObservableCollection<School> GetSchools()
        {
#if DEBUG
            Trace.WriteLine($"Создана коллекция объектов: '{nameof(Schools)}'");
#endif
            Schools.Load();
            return Schools.Local.ToObservableCollection();
        }

        public ObservableCollection<Specialty> GetSpecialties()
        {
#if DEBUG
            Trace.WriteLine($"Создана коллекция объектов: '{nameof(Specialties)}'");
#endif
            Specialties.Load();
            return Specialties.Local.ToObservableCollection();
        }

        public ObservableCollection<Student> GetStudents()
        {
#if DEBUG
            Trace.WriteLine($"Создана коллекция объектов: '{nameof(Students)}'");
#endif
            Students.Load();
            return Students.Local.ToObservableCollection();
        }

        public void Add<Entity>(Entity entity)
        {
            Add(entity);
        }
        public void Remove<Entity>(Entity entity)
        {
            Add(entity);
        }
        public void Edit<Entity>(Entity entity)
        {
            Entry(entity).State = EntityState.Modified;
        }
    }
}
