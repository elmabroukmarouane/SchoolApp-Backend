namespace SchoolApp.Infrastructure.Models.Interfaces;
public interface ICommonFields
{
    DateTime? createdate { get; set; }
    DateTime? updatedate { get; set; }
    string? createdby { get; set; }
    string? updatedby { get; set; }
}