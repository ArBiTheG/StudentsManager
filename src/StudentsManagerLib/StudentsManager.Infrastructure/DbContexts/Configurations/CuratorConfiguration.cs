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
    public class CuratorConfiguration : IEntityTypeConfiguration<Curator>
    {
        public void Configure(EntityTypeBuilder<Curator> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(c => c.Person)
                .WithMany()
                .HasForeignKey(c => c.PersonId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
