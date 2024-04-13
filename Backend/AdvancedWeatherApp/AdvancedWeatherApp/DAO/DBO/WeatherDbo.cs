using System.ComponentModel.DataAnnotations;

namespace AdvancedWeatherApp.DAO.DBO;

public class WeatherDbo
{
	[Key]
    public Guid Id { get; set; }
	
    public DateTime DateTimeStamp { get; set; }
    
    public double Temperature { get; set; }
	
    public double Pressure { get; set; }
	
    public double Humidity { get; set; }
}