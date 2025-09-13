namespace Domain.Entities;

public class Report
{
    public long Id { get; set; }
    public long ReporterId { get; set; }
    public long ReportedHomeId { get; set; }
    public string Description { get; set; }
}
