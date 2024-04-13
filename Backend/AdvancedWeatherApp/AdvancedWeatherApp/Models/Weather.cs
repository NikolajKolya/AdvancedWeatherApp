namespace AdvancedWeatherApp.Models;

public class Weather
{
    public Guid Id { get; set; }
    
    public double Temperature { get; set; }
    
    public DateTime DateTimeStamp { get; set; }
	
    public double Pressure { get; set; }
	
    public double Humidity { get; set; }
}