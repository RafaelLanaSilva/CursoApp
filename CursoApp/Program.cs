using CursoApp.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(map => { map.LowercaseUrls = true; });

SwaggerConfiguration.AddSwaggerConfiguration(builder.Services);
CorsConfiguration.AddCorsConfiguration(builder.Services);
DepedencyInjectionConfiguration.AddDependencyInjection(builder.Services);

var app = builder.Build();

SwaggerConfiguration.UseSwaggerConfiguration(app);
CorsConfiguration.UseCorsConfiguration(app);

app.UseAuthorization();

app.MapControllers();

app.Run();
