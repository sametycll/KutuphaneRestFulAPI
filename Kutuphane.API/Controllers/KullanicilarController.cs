using Kutuphane.API.Authentication;
using Kutuphane.API.Dtos.KategoriDtos;
using Kutuphane.API.Dtos.KullanicilarDtos;
using Kutuphane.API.Repositories.KullanicilarRepository;
using Kutuphane.API.Repositories.KullanicilarRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]

    public class KullanicilarController : ControllerBase
    {
        public readonly IKullanicilarRepository _kullanicilarRepository;

        public KullanicilarController(IKullanicilarRepository kullanicilarRepository)
        {
            _kullanicilarRepository = kullanicilarRepository;
        }

        [HttpGet]
        public async Task<IActionResult> KullanicilarList()
        {
            var values = await _kullanicilarRepository.GetAllAsync();
            return Ok(values);
        }
      
    }
}
