using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Client.DtoModel.Models;
public class PersonViewModel : Entity
{
    public string? firstname { get; set; }
    public string? lastname { get; set; }
    public DateTime birthdate { get; set; }
    public virtual ICollection<UserViewModel> users { get; set; }
}
