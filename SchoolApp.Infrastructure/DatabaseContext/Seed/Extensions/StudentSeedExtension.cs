using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolApp.Infrastructure.DatabaseContext.Seed.Data;
using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Infrastructure.DatabaseContext.Seed.Extensions;
public static class StudentSeedExtension
{
    public static void Seed(this EntityTypeBuilder<Student> builder)
    {
        builder.HasData(StudentSeed.getStudentsMockUp());
    }
}