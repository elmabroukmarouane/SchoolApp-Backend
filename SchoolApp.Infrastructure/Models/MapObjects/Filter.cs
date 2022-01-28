namespace Infrastructure.Models.MapObjects;
public class Filter
{
    public string? value { get; set; }
    public bool disableTracking { get; set; }
    public int take { get; set; }
    public int offset { get; set; }
    public string? includes { get; set; }
}