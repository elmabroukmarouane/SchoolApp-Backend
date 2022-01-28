using SchoolApp.Infrastructure.Models.Interfaces;

namespace SchoolApp.Infrastructure.Models.Classes;
public class Course : Entity
{
    public int studentid { get; set; }
    public int professorid { get; set; }
    public string? coursename { get; set; }
    public virtual Student? student {get; set;}
    public virtual Professor? professor {get; set;}
}

