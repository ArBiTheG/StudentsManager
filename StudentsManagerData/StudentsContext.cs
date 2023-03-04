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
        public DbSet<Person> Persons { get; set; } = null!;
        public DbSet<Phone> Phones { get; set; } = null!;
        public DbSet<Email> Emails { get; set; } = null!;
        public DbSet<Hobby> Hobbies { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Students.db");
        }
    }
}
