using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Infrastructure.DatabaseContext.Seed.Data;
public class CourseSeed
{
    public static IList<Course> getCoursesMockUp()
    {
        return new List<Course>()
        {
            new Course()
            {
                id = 1,
                studentid = 1,
                professorid = 1,
                coursename = "Course 1",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Course()
            {
                id = 2,
                studentid = 2,
                professorid = 2,
                coursename = "Course 2",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Course()
            {
                id = 3,
                studentid = 3,
                professorid = 3,
                coursename = "Course 3",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            }
        };
    }
}