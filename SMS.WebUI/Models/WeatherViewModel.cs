namespace SMS.WebUI.Models;

public class WeatherViewModel
{
    public string City { get; set; }
    public string Country { get; set; }
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public string Timezone { get; set; }
    public string ConditionText { get; set; }
    public int Temperature { get; set; }
    // Diğer alanlar eklenebilir
}