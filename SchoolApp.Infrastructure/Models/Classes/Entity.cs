using SchoolApp.Infrastructure.Models.Interfaces;

namespace SchoolApp.Infrastructure.Models.Classes;
public class Entity : IIds, ICommonFields
{
    public int id { get; set; }
    public DateTime? createdate { get; set; }
    public DateTime? updatedate { get; set; }
    public string? createdby { get; set; }
    public string? updatedby { get; set; }
}