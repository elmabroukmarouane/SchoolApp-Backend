namespace SchoolApp.Infrastructure.Models.Classes;
public class Professor : Entity
{
    public int personid { get; set; }
    public string? profcode { get; set; }
    public virtual Person? person { get; set; }
    public virtual ICollection<Course>? courses { get; set; }
}
