using Kutuphane.UI.Dtos.KategoriDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Kutuphane.UI.Controllers
{
    public class KategoriController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public KategoriController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://localhost:44313/api/Kategoriler"),
                Headers =
                {
                    {"x-api-key","10376350E1D444D4AA49774ADEAE61D2" }
                }
            };
            var responseMessage = await client.SendAsync(request);
            
            if(responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<AllKategoriDto>>(jsonData);
                return View(values);

            }
            return View();
        }
    }
}
