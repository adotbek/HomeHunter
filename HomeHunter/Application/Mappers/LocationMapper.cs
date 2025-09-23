using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class LocationMapper
{
    public static Location ToLocationEntity (LocationCreateDto dto)
    {
        return new Location
        {
            Country = dto.Country,
            City = dto.City,
            District = dto.District,
            Street = dto.Street,
            HouseNumber = dto.HouseNumber,
            ZipCode = dto.ZipCode,
        };
    }
    

}

