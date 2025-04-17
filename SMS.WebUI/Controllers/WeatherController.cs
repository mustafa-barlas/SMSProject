using Microsoft.AspNetCore.Mvc;

namespace SMS.WebUI.Controllers;

public class WeatherController(IHttpClientFactory httpClientFactory) : Controller
{
    // public async Task<IActionResult> Partial(double lat, double lon)
    // {
    //     var model = await GetWeatherAsync(lat, lon);
    //     return ViewComponent("Weather", new { model });
    // }
    //
    // private async Task<WeatherViewModel> GetWeatherAsync(double lat, double lon)
    // {
    //     var client = httpClientFactory.CreateClient();
    //     var request = new HttpRequestMessage
    //     {
    //         Method = HttpMethod.Get,
    //         RequestUri = new Uri($"https://yahoo-weather5.p.rapidapi.com/weather?lat={lat}&long={lon}&format=json&u=f"),
    //         Headers =
    //         {
    //             { "x-rapidapi-key", "a117ffd5f6mshf7d2d72feb8df5dp157f20jsn23f9d3dd0c7d" },
    //             { "x-rapidapi-host", "yahoo-weather5.p.rapidapi.com" },
    //         },
    //     };
    //
    //     using var response = await client.SendAsync(request);
    //     response.EnsureSuccessStatusCode();
    //     var jsonString = await response.Content.ReadAsStringAsync();
    //     
    //     var weatherData = JsonSerializer.Deserialize<WeatherViewModel>(jsonString);
    //     return weatherData;
    // }
}