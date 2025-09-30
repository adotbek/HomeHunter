using HomeHunter.Configurations;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
var sss = builder.Configuration.GetConnectionString("DatabaseConnectionMS");
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(sss));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


builder.ConfigureDataBase();
builder.ConfigurationJwtAuth();
builder.ConfigureJwtSettings();
builder.ConfigureSerilog();
builder.Services.ConfigureDependecies();




app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
