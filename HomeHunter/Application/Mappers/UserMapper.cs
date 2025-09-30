using Application.Dtos;
using Domain.Entities;

namespace Application.Mappers;

public class UserMapper
{
    public static UserGetDto ToUserGetDto(User dto)
    {
        return new UserGetDto
        {
            FirstName = dto.FirstName,
            SecondName = dto.SecondName,
            UserName = dto.UserName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Role = dto.Role.Name,
        };
    }
}
