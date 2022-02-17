namespace SchoolApp.Infrastructure.Models.Classes;
public class User : Entity
{
    public int roleid { get; set; }
    public int personid { get; set; }
    public string? email { get; set; }
    public string? password { get; set; }
    public bool isOnline { get; set; }
    public virtual Role? role { get; set; }
    public virtual Person? person { get; set; }
}