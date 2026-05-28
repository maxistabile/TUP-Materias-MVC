using Microsoft.EntityFrameworkCore;
using TUP_Materias.Data;
var builder = WebApplication.CreateBuilder(args);
// 1. Buscamos la cadena de conexión que guardamos en appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// 2. Registramos el ApplicationDbContext en el sistema
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString) // Pomelo detecta automáticamente si usás MySQL o MariaDB
    )
);
// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

// Bloque para sembrar la base de datos al iniciar
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ApplicationDbContext>();
        DbInitializer.Seed(context); // Ejecuta nuestra siembra
    }
    catch (Exception ex)
    {
        // Si algo falla sembrando, te enterás acá
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Un error ocurrió al sembrar la base de datos.");
    }
}

app.Run();
