using Application.Interfaces;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using Application.Services;
using Infrastructure.Repositories;

namespace HomeHunter.Configurations;

public static class DependecyInjectionsConfiguration
{
    public static void ConfigureDependecies  (this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<IHomeService, HomeService>();
        services.AddScoped<IImageService, ImageService>();
        services.AddScoped<ILocationService, LocationService>();
        services.AddScoped<IReportService,ReportService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICategoryRepository,CategoryRepository>();
        services.AddScoped<IHomeRepository, HomeRepository>();
        services.AddScoped<ILocationRepository, LocationRepository>();
        services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
        services.AddScoped<IReportRepository, ReportRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
