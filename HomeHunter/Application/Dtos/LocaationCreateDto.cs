using Domain.Entities;

namespace Application.Dtos;

public class LocaationCreateDto
{
    public string Country { get; set; }
    public string City { get; set; }
    public string District { get; set; }
    public string Street { get; set; }
    public string? HouseNumber { get; set; }
    public string? ZipCode { get; set; }
}
