using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolApp.Infrastructure.DatabaseContext.Seed.Extensions;
using SchoolApp.Infrastructure.Models.Classes;

namespace Infrastructure.Models.DatabaseContext.Configurations;
public class StudentConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.HasKey(s => s.id);
        builder.HasOne(s => s.person)
              .WithMany(pers => pers.students)
              .HasForeignKey(p => p.personid)
              .OnDelete(DeleteBehavior.Cascade);
        builder.HasOne(s => s.level)
              .WithMany(l => l.students)
              .HasForeignKey(s => s.levelid)
              .OnDelete(DeleteBehavior.Cascade);
        builder.Seed();
    }
}