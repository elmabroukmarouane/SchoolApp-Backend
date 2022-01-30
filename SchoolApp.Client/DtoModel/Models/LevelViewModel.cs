using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Client.DtoModel.Models;
public class LevelViewModel : Entity
{
    public string? levelname { get; set; }
    public virtual ICollection<StudentViewModel>? students { get; set; }
}
