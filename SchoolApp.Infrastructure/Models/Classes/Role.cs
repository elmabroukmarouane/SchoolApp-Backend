using SchoolApp.Infrastructure.Models.Interfaces;

namespace SchoolApp.Infrastructure.Models.Classes;
public enum Roles
{
    SUPER_ADMIN = 1,
    ADMIN,
    PROFESSOR,
    STUDENT,
    USER
}
public class Role : Entity
{
    public Roles role { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public virtual ICollection<User>? users { get; set; }
}