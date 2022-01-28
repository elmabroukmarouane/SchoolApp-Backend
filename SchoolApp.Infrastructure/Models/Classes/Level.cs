using SchoolApp.Infrastructure.Models.Interfaces;

namespace SchoolApp.Infrastructure.Models.Classes;
public class Level : Entity
{
    public string? levelname { get; set; }
    public virtual ICollection<Student>? students { get; set; }
}

