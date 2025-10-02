using Application.Dtos;
using Application.Interfaces.Services;

namespace HomeHunter.Endpoints;

public static class UserEndpoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/users")
                       .WithTags("Users");

        
        group.MapPost("/create", async (UserCreateDto dto, IUserService service) =>
        {
            var id = await service.CreateAsync(dto);
            return Results.Ok(new { UserId = id });
        })
        .WithName("CreateUser");

        
        group.MapPut("/update/{id:long}", async (long id, UserCreateDto dto, IUserService service) =>
        {
            await service.UpdateAsync(id, dto);
            return Results.Ok(new { Message = "User updated successfully" });
        })
        .WithName("UpdateUser");


        group.MapDelete("/delete/{id:long}", async (long id, IUserService service) =>
        {
            await service.DeleteAsync(id);
            return Results.Ok(new { Message = "User deleted successfully" });
        })
        .WithName("DeleteUser");


        group.MapGet("/get-by-id/{id:long}", async (long id, IUserService service) =>
        {
            var user = await service.GetByIdAsync(id);
            return user is null ? Results.NotFound() : Results.Ok(user);
        })
        .WithName("GetUserById");

        // Get all users
        group.MapGet("/get-all", async (IUserService service) =>
        {
            var users = await service.GetAllAsync();
            return Results.Ok(users);
        })
        .WithName("GetAllUsers");

        // Get by username
        group.MapGet("/get-by-name", async (string userName, IUserService service) =>
        {
            var user = await service.GetByNameAsync(userName);
            return user is null ? Results.NotFound() : Results.Ok(user);
        })
        .WithName("GetUserByName");

        // Get by email
        group.MapGet("/get-by-email", async (string email, IUserService service) =>
        {
            var user = await service.GetByEmailAsync(email);
            return user is null ? Results.NotFound() : Results.Ok(user);
        })
        .WithName("GetUserByEmail");

        // Get by role
        group.MapGet("/get-by-role/{roleId:long}", async (long roleId, IUserService service) =>
        {
            var users = await service.GetByRoleIdAsync(roleId);
            return Results.Ok(users);
        })
        .WithName("GetUsersByRoleId");

        // Login
        group.MapPost("/login", async (UserLoginDto dto, IUserService service) =>
        {
            var user = await service.LoginAsync(dto);
            return user is null
                ? Results.Unauthorized()
                : Results.Ok(user);
        })
        .WithName("LoginUser");
    }
}
