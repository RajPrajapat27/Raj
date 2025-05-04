using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using N3DStudio.Models;
using static System.Net.Mime.MediaTypeNames;
using RestSharp;
using Microsoft.AspNetCore.DataProtection.KeyManagement;

namespace N3DStudio.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient _httpClient;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IWebHostEnvironment _environment;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient, IHttpClientFactory httpClientFactory, IWebHostEnvironment environment)
        {
            _logger = logger;
            _httpClient = httpClient;
            _httpClientFactory = httpClientFactory;
            _environment = environment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        [HttpGet("text-to-voice")]
        public async Task<IActionResult> GenerateVideo()
        {
            string apiKey = "sk_4d420f20b26c29d27fcd2c1870000355d67a8c9c07ecbd57"; // Secure this in real app!
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("xi-api-key", apiKey);

            var response = await _httpClient.GetAsync("https://api.elevenlabs.io/v1/voices");
            if (!response.IsSuccessStatusCode)
                throw new Exception("Failed to fetch voices from Eleven Labs.");

            var responseData = await response.Content.ReadAsStringAsync();
            var voices = JsonSerializer.Deserialize<ElevenLabsVoicesResponse>(responseData);
            return View(voices);

        }
        //[HttpGet("text-prompt")]
        //public async Task<IActionResult> GenerateScript()
        //{

        //    int wordCount = 1 * 130;
        //    string fullPrompt = $"On topic animals for kids Write a video script of approximately {wordCount} words.";

        //    var result = await _api.Completions.CreateCompletionAsync(new OpenAI_API.Completions.CompletionRequest
        //    {
        //        Prompt = fullPrompt,
        //        Model = "text-davinci-003",
        //        MaxTokens = wordCount * 2,
        //        Temperature = 0.7
        //    });

        //    return result.Completions[0].Text.Trim();

        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
