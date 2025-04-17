using Microsoft.AspNetCore.Mvc;

namespace SMS.WebUI.ViewComponent;

public class WeatherViewComponent : Microsoft.AspNetCore.Mvc.ViewComponent
{
    private readonly HttpClient _httpClient;

    public WeatherViewComponent(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IViewComponentResult> InvokeAsync(double lat, double lon)
    {
        //     var request = new HttpRequestMessage
        //     {
        //         Method = HttpMethod.Get,
        //         RequestUri = new Uri($"https://yahoo-weather5.p.rapidapi.com/weather?lat={lat}&long={lon}&format=json&u=c"),
        //         Headers =
        //         {
        //             { "x-rapidapi-key", "a117ffd5f6mshf7d2d72feb8df5dp157f20jsn23f9d3dd0c7d" },
        //             { "x-rapidapi-host", "yahoo-weather5.p.rapidapi.com" },
        //         },
        //     };
        //
        //     using var response = await _httpClient.SendAsync(request);
        //
        //     // Eğer HTTP isteği başarısızsa, hata mesajı dönebiliriz
        //     if (!response.IsSuccessStatusCode)
        //     {
        //         return View("Error", "Hava durumu verisi alınamadı.");
        //     }
        //
        //     var jsonString = await response.Content.ReadAsStringAsync();
        //
        //     // İsteğe bağlı: Logla
        //     Console.WriteLine(jsonString);
        //
        //     using var jsonDoc = JsonDocument.Parse(jsonString);
        //     var root = jsonDoc.RootElement;
        //
        //     // JSON yapısına göre model doldur
        //     var model = new WeatherViewModel
        //     {
        //         City = root.GetProperty("location").GetProperty("city").GetString(),
        //         Country = root.GetProperty("location").GetProperty("country").GetString(),
        //         Latitude = root.GetProperty("location").GetProperty("lat").GetDouble(),
        //         Longitude = root.GetProperty("location").GetProperty("long").GetDouble(),
        //         Timezone = root.GetProperty("location").GetProperty("timezone_id").GetString(),
        //         ConditionText = root.GetProperty("current_observation").GetProperty("condition").GetProperty("text")
        //             .GetString(),
        //         Temperature = root.GetProperty("current_observation").GetProperty("condition").GetProperty("temperature")
        //             .GetInt32(),
        //         // Diğer alanlar eklenecekse burada tanımlayabilirsin
        //     };
        //
        //     return View(model);

        return View();
    }
}