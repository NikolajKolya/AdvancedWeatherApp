using AdvancedWeatherApp.DAO;
using AdvancedWeatherApp.DAO.Abstract;
using AdvancedWeatherApp.DAO.Implementations;
using AdvancedWeatherApp.Mappers.Abstract;
using AdvancedWeatherApp.Mappers.Implementation;
using AdvancedWeatherApp.Services.Abstract;
using AdvancedWeatherApp.Services.Implementations;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MainDbContext>(options =>
        options.UseNpgsql(builder.Configuration.GetConnectionString("WebApiDatabase")));

builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddScoped<IWeatherDao, WeatherDao>();

builder.Services.AddSingleton<IWeatherMapper, WeatherMapper>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
