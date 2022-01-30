using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Client.DtoModel.Models;
public class RoleViewModel : Entity
{
    public Roles role { get; set; }
    public string? title { get; set; }
    public string? description { get; set; }
    public ICollection<UserViewModel>? users { get; set; }
}
