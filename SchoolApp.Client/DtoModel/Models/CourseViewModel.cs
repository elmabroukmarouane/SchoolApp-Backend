using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Client.DtoModel.Models;
public class CourseViewModel : Entity
{
    public int studentid { get; set; }
    public int professorid { get; set; }
    public string? coursename { get; set; }
    public virtual StudentViewModel? student {get; set;}
    public virtual ProfessorViewModel? professor {get; set;}
}
