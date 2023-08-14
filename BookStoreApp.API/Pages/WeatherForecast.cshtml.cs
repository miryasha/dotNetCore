using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookStoreApp.API.Pages
{
    public class WeatherForecastModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}


namespace BookStoreApp.API.Pages
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
