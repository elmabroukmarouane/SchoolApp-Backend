using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Client.DtoModel.Models;
public class ProfessorViewModel : Entity
{
    public int personid { get; set; }
    public string? profcode { get; set; }
    public string? photoprofessor { get; set; }
    public virtual PersonViewModel? person { get; set; }
    public virtual ICollection<CourseViewModel>? courses { get; set; }
}
