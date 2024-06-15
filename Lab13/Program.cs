using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Lab13.Models; // Asegúrate de ajustar el namespace si es necesario
using Microsoft.OpenApi.Models;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Configura servicios
        ConfigureServices(builder.Services);

        var app = builder.Build();

        // Configura la aplicación
        Configure(app);

        app.Run();
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        // Agrega servicios de controladores y DbContext
        services.AddControllers();

        // Configuración del DbContext
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer("Server=LAB1504-22\\SQLEXPRESS;Initial Catalog=Lab13;Integrated Security=True;TrustServerCertificate=True"));

        // Configuración de Swagger
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "Laboratorio 13", Version = "v1" });
        });
    }

    private static void Configure(WebApplication app)
    {
        // Configuración para desarrollo
        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();

            // Habilita Swagger UI
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Laboratorio 13");
            });
        }

        // Middleware para redirección HTTPS y autorización
        app.UseHttpsRedirection();
        app.UseAuthorization();

        // Mapea los controladores
        app.MapControllers();
    }
}
