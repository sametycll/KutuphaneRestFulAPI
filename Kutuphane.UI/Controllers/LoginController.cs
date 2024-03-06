using Kutuphane.UI.Dtos.KullaniciDtos;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Text;
using Humanizer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;


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
            var content = new StringContent(System.Text.Json.JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");
            var response = await client.PostAsync("https://localhost:44313/api/Login", content);

            if(response.IsSuccessStatusCode)
            {
                var jsonData = await response.Content.ReadAsStringAsync();
                var tokenModel = System.Text.Json.JsonSerializer.Deserialize<JwtResponseVm>(jsonData, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                });

                if(tokenModel != null)
                {
                    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
                    var token =handler.ReadJwtToken(tokenModel.Token);
                    var claims=token.Claims.ToList();
                    
                    if(tokenModel.Token != null)
                    {
                        claims.Add(new Claim("userToken", tokenModel.Token));
                        var claimsIdentity = new ClaimsIdentity(claims,JwtBearerDefaults.AuthenticationScheme);
                        var authProps = new AuthenticationProperties
                        {
                            ExpiresUtc = tokenModel.ExpireDate,
                            IsPersistent = true,
                        };

                        await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), authProps);
                        return RedirectToAction("Index", "Kategori");

                    }
                }
              
            }
            return View();

        }

        public async Task<IActionResult> LogOut()
        {
            //await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }




    }
}



//var values = JsonConvert.DeserializeObject<KullaniciYetki>(jsonData);
//var claims = new List<Claim>
//{
//                    new Claim(ClaimTypes.Name,dto.KullaniciAdi),
//                    new Claim(ClaimTypes.Role,values.Yetki)
//                };
//var useridentity = new ClaimsIdentity(claims, "admin");
//ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
//await HttpContext.SignInAsync(principal);