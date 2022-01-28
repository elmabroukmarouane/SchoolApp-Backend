using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolApp.Infrastructure.DatabaseContext.Seed.Extensions;
using SchoolApp.Infrastructure.Models.Classes;

namespace Infrastructure.Models.DatabaseContext.Configurations;
public class ProfessorConfiguration : IEntityTypeConfiguration<Professor>
{
    public void Configure(EntityTypeBuilder<Professor> builder)
    {
        builder.HasKey(p => p.id);
        builder.HasOne(p => p.person)
              .WithMany(pers => pers.professors)
              .HasForeignKey(p => p.personid)
              .OnDelete(DeleteBehavior.Cascade);
        builder.Seed();
    }
}