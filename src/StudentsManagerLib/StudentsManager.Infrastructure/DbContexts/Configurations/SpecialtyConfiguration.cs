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
    public class SpecialtyConfiguration : IEntityTypeConfiguration<Specialty>
    {
        public void Configure(EntityTypeBuilder<Specialty> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(s => s.Code)
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(200);
        }
    }
}
