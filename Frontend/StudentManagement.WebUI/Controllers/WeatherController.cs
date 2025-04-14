using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using StudentManagement.WebUI.Models;

namespace StudentManagement.WebUI.Controllers;

public class WeatherController(IHttpClientFactory httpClientFactory) : Controller
{
    [HttpGet("Weather/GetWeather")]
    public async Task<IActionResult> GetWeather(double lat, double lon)
    {
        var client = httpClientFactory.CreateClient();
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri =
                new Uri(
                    $"https://weather-api167.p.rapidapi.com/api/weather/current?lat={lat}&lon={lon}&units=metric&lang=tr"),
            Headers =
            {
                { "x-rapidapi-key", "a117ffd5f6mshf7d2d72feb8df5dp157f20jsn23f9d3dd0c7d" },
                { "x-rapidapi-host", "weather-api167.p.rapidapi.com" },
                { "Accept", "application/json" },
            }
        };

        using var response = await client.SendAsync(request);
        var body = await response.Content.ReadAsStringAsync();

        if (!response.IsSuccessStatusCode)
            return BadRequest("API isteği başarısız oldu: " + body);

        using var jsonDoc = JsonDocument.Parse(body);
        var root = jsonDoc.RootElement;

        var weather = new WeatherViewModel
        {
            City = root.GetProperty("city").GetString(),
            Country = root.GetProperty("country").GetString(),
            Latitude = root.GetProperty("latitude").GetDouble(),
            Longitude = root.GetProperty("longitude").GetDouble(),
            Timezone = root.GetProperty("timezone").GetString(),
            ConditionText = root.GetProperty("condition").GetProperty("text").GetString(),
            Temperature = root.GetProperty("temperature").GetProperty("celsius").GetInt32(),
            Humidity = root.GetProperty("humidity").GetInt32()
        };

        return Json(new
        {
            city = weather.City,
            country = weather.Country,
            temperature = weather.Temperature,
            conditionText = weather.ConditionText
        });
    }
}