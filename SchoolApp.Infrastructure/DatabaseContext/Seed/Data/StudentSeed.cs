using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Infrastructure.DatabaseContext.Seed.Data;
public class StudentSeed
{
    public static IList<Student> getStudentsMockUp()
    {
        return new List<Student>()
        {
            new Student()
            {
                id = 1,
                personid = 1,
                levelid = 1,
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Student()
            {
                id = 2,
                personid = 2,
                levelid = 2,
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Student()
            {
                id = 3,
                personid = 3,
                levelid = 3,
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            }
        };
    }
}