using SchoolApp.Infrastructure.Models.Classes;

namespace SchoolApp.Infrastructure.Models.MapObjects;
public class QueryParams
{
    public string? fields { get; set; }
    public string? table { get; set; }
    public string? where { get; set; }
    public string? groupby { get; set; }
    public string? having { get; set; }
    public string? orderby { get; set; }
    public int limit { get; set; }
    public int offset { get; set; }
}