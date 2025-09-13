using System.Reflection.Metadata.Ecma335;

namespace Domain.Entities;

public class Category
{
    public long Id { get; set; }
    public string Name { get; set; }
    public List<ICollection<Home>> Homes { get; set; }
}
