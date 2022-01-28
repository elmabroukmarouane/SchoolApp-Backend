using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Infrastructure.DatabaseContext.Seed.Data;
public class ProfessorSeed
{
    public static IList<Professor> getProfessorsMockUp()
    {
        return new List<Professor>()
        {
            new Professor()
            {
                id = 1,
                personid = 4,
                profcode = "CODE_1",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Professor()
            {
                id = 2,
                personid = 5,
                profcode = "CODE_2",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Professor()
            {
                id = 3,
                personid = 6,
                profcode = "CODE_3",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            }
        };
    }
}