using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class UserMapper
{
    public static UserDto ToUserGetDto(User dto)
    {
        return new UserDto
        {
            FirstName = dto.FirstName,
            SecondName = dto.SecondName,
            UserName = dto.UserName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Age = dto.Age,
            Role = dto.Role.Name,
        };
    }
}
