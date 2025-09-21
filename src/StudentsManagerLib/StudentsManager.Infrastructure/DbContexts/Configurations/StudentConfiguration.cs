using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StudentsManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsManager.Infrastructure.DbContexts.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(s => s.Person)
                .WithMany()
                .HasForeignKey(s => s.PersonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(s => s.Group)
                .WithMany(g => g.Students)
                .HasForeignKey(s => s.GroupId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
