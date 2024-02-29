using Kutuphane.UI.Dtos.KullaniciDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Kutuphane.UI.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginKullaniciDto dto)
        {
            var client = _httpClientFactory.CreateClient();
            var content = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44313/api/Login", content);
            if(response.IsSuccessStatusCode)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,dto.KullaniciAdi)
                };
                var useridentity = new ClaimsIdentity(claims,"admin");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Kategori");
            }
            else
            {
                return View();

            }
        }
    }
}
