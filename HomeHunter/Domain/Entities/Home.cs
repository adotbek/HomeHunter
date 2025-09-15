using System.Text.Json.Nodes;

namespace Domain.Entities;

public class Home
{
    public long Id { get; set; }
    public string Location { get; set; }
    public string OwnerNumber { get; set; }
    public string Bio { get; set; }
    public decimal Price { get; set; }
    public Category Category { get; set; }
    public int NumberOfRooms { get; set; }
    public string Type { get; set; }
    public Image Image { get; set; }
    public string Status { get; set; }
}
