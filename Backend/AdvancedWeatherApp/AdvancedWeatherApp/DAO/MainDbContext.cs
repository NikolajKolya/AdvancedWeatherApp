using AdvancedWeatherApp.DAO.DBO;
using AdvancedWeatherApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace AdvancedWeatherApp.DAO;

public class MainDbContext: DbContext
{
    public MainDbContext(DbContextOptions<MainDbContext> options)
        : base(options)
    {
        
    }
    
    public DbSet<WeatherDbo> Weathers { get; set; }
}