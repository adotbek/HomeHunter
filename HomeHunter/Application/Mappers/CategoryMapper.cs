using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class CategoryMapper
{
     public static Category ToCategoryEntity (CategoryDto dto)
    {
        return new Category
        {
            Name = dto.Name,
        };
    }
    public static CategoryDto ToCategoryDto (Category category)
    {
        return new CategoryDto
        {
            Name = category.Name
        };
    }
}
