using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Infrastructure.DatabaseContext.Seed.Data;
public class RoleSeed
{
    public static IList<Role> getRolesMockUp()
    {
        return new List<Role>()
        {
            new Role()
            {
                id = 1,
                role = Roles.SUPER_ADMIN,
                title = "Super Administrator",
                description = "Super Administrator Description",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Role()
            {
                id = 2,
                role = Roles.ADMIN,
                title = "Administrator",
                description = "Administrator Description",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Role()
            {
                id = 3,
                role = Roles.PROFESSOR,
                title = "Professor",
                description = "Professor Description",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Role()
            {
                id = 4,
                role = Roles.STUDENT,
                title = "User",
                description = "Student Description",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Role()
            {
                id = 5,
                role = Roles.USER,
                title = "User",
                description = "User Description",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            }
        };
    }
}