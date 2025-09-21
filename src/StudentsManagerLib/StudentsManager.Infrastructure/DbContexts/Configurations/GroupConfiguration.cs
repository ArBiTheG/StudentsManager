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
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasOne(g => g.Specialty)
                .WithMany(s => s.Groups)
                .HasForeignKey(g => g.SpecialtyId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(g => g.Curator)
                .WithMany(c => c.Groups)
                .HasForeignKey(g => g.CuratorId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
