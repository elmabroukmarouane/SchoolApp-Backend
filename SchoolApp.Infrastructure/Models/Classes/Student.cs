namespace SchoolApp.Infrastructure.Models.Classes;
public class Student : Entity
{
    public int personid { get; set; }
    public int levelid { get; set; }
    public string? photostudent { get; set; }
    public virtual Person? person { get; set; }
    public virtual Level? level {get; set;}
    public virtual ICollection<Course>? courses { get; set; }
}

