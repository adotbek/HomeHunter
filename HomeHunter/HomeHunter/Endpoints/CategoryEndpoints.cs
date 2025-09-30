using Application.Dtos;
using Application.Interfaces;
using Application.Interfaces.Services;

namespace HomeHunter.Endpoints;

public static class CategoryEndpoints
{
    public static void MapCategoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/categories")
                       .WithTags("Categories");

        group.MapGet("/get-all", async (ICategoryService service) =>
        {
            var categories = await service.GetAllAsync();
            return Results.Ok(categories);
        })
        .WithName("GetAllCategories");

        group.MapGet("/get-by-id/{id:long}", async (long id, ICategoryService service) =>
        {
            var category = await service.GetByIdAsync(id);
            return category is null ? Results.NotFound() : Results.Ok(category);
        })
        .WithName("GetCategoryById");

        group.MapGet("/get-by-name/{name}", async (string name, ICategoryService service) =>
        {
            var category = await service.GetByNameAsync(name);
            return category is null ? Results.NotFound() : Results.Ok(category);
        })
        .WithName("GetCategoryByName");

        group.MapPost("/create", async (string name, ICategoryService service) =>
        {
            var id = await service.AddCategoryAsync(name);
            return Results.Ok(new { CategoryId = id });
        })
        .WithName("CreateCategory");

        group.MapPut("/update", async (CategoryDto dto, ICategoryService service) =>
        {
            await service.UpdateCategoryAsync(dto);
            return Results.Ok(new { Message = "Category updated successfully" });
        })
        .WithName("UpdateCategory");

        group.MapDelete("/delete/{id:long}", async (long id, ICategoryService service) =>
        {
            await service.DeleteCategoryAsync(id);
            return Results.Ok(new { Message = "Category deleted successfully" });
        })
        .WithName("DeleteCategory");
    }
}
