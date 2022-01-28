using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolApp.Infrastructure.DatabaseContext.Seed.Extensions;
using SchoolApp.Infrastructure.Models.Classes;

namespace Infrastructure.Models.ModelsConfiguration;
public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.HasKey(c => c.id);
        builder.HasOne(c => c.professor)
              .WithMany(p => p.courses)
              .HasForeignKey(c => c.professorid)
              .OnDelete(DeleteBehavior.NoAction);
        builder.HasOne(c => c.student)
               .WithMany(s => s.courses)
               .HasForeignKey(c => c.studentid)
               .OnDelete(DeleteBehavior.NoAction);
        builder.Seed();
    }
}