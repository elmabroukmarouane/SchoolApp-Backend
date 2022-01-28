using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolApp.Infrastructure.DatabaseContext.Seed.Data;
using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Infrastructure.DatabaseContext.Seed.Extensions;
public static class ProfessorSeedExtension
{
    public static void Seed(this EntityTypeBuilder<Professor> builder)
    {
        builder.HasData(ProfessorSeed.getProfessorsMockUp());
    }
}