using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Infrastructure.Models.MapObjects;
public class LoggedUser
{
    public string? Message { get; set; }
    public User? User { get; set; }
    public string? Token { get; set; }
}