using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Infrastructure.DatabaseContext.Seed.Data;
public class PersonSeed
{
    public static IList<Person> getPersonsMockUp()
    {
        return new List<Person>()
        {
            new Person()
            {
                id = 1,
                firstname = "Marouane",
                lastname = "EL MABROUK",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Person()
            {
                id = 2,
                firstname = "Smith",
                lastname = "JOHN",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Person()
            {
                id = 3,
                firstname = "William",
                lastname = "MILLER",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Person()
            {
                id = 4,
                firstname = "Prof",
                lastname = "EL MABROUK",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Person()
            {
                id = 5,
                firstname = "Prof",
                lastname = "JOHN",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Person()
            {
                id = 6,
                firstname = "Prof",
                lastname = "MILLER",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            }
        };
    }
}