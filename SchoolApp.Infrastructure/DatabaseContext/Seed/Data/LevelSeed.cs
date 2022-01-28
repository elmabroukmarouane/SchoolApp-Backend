using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Infrastructure.DatabaseContext.Seed.Data;
public class LevelSeed
{
    public static IList<Level> getLevelsMockUp()
    {
        return new List<Level>()
        {
            new Level()
            {
                id = 1,
                levelname = "Level 1",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Level()
            {
                id = 2,
                levelname = "Level 2",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            },
            new Level()
            {
                id = 3,
                levelname = "Level 3",
                createdate = DateTime.Now,
                createdby = "Seed Data",
                updatedate = DateTime.Now,
                updatedby = "Seed Data"
            }
        };
    }
}