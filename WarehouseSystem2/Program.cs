using WarehouseSystem.Domain.Abstractions;
using WarehouseSystem.Data.Repositories;
using WarehouseSystem.Domain.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(60);
    options.Cookie.HttpOnly = true;
});

var connStr = builder.Configuration.GetConnectionString("Warehousesystem");
builder.Services.AddScoped<IWarehouseRepository>(provider => new WarehouseRepository(connStr!));
builder.Services.AddScoped<IGebruikerService, GebruikerService>();

var app = builder.Build();
app.UseStaticFiles();
app.UseRouting();
app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();