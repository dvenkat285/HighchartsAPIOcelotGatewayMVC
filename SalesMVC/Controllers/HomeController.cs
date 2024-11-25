using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesMVC.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SalesMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Main action to load the view
        public async Task<IActionResult> Index()
        {
            // Fetch data from the API (through Ocelot Gateway)
            var response = await _httpClient.GetStringAsync("http://localhost:5000/api/sales");
            var sales = JsonConvert.DeserializeObject<List<Sales>>(response);

            // Pass the data to the view
            return View(sales);
        }

        // Action to provide JSON data for Highcharts
        [HttpGet]
        public async Task<JsonResult> GetChartData()
        {
            // Fetch data from the API (through Ocelot Gateway)
            var response = await _httpClient.GetStringAsync("http://localhost:5000/api/sales");
            var sales = JsonConvert.DeserializeObject<List<Sales>>(response);

            // Transform the data for Highcharts
            var chartData = sales.Select(s => new
            {
                Months = s.Months,
                SalesAmount = s.SalesAmount
            });

            // Return the data as JSON
            return Json(chartData);
        }
    }

    // Sales model to match API response
    public class Sales
    {
        public int Id { get; set; }
        public string? Months { get; set; }
        public int? SalesAmount { get; set; }
    }
}
