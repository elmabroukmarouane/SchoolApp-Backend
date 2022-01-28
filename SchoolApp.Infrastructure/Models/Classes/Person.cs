namespace SchoolApp.Infrastructure.Models.Classes;
public class Person : Entity
{
    public string? firstname { get; set; }
    public string? lastname { get; set; }
    public DateTime birthdate { get; set; }
    public virtual ICollection<User>? users { get; set; }
    public virtual ICollection<Professor>? professors { get; set; }
    public virtual ICollection<Student>? students { get; set; }
}
