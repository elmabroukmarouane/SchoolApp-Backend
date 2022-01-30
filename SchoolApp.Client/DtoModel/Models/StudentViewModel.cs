using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Client.DtoModel.Models;
public class StudentViewModel : Entity
{
    public int personid { get; set; }
    public int levelid { get; set; }
    public string? photostudent { get; set; }
    public virtual PersonViewModel? person { get; set; }
    public virtual LevelViewModel? level {get; set;}
    public virtual ICollection<CourseViewModel>? courses { get; set; }
}
