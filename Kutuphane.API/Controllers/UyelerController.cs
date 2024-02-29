using Kutuphane.API.Authentication;
using Kutuphane.API.Repositories.KategoriRepository;
using Kutuphane.API.Repositories.UyelerRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(ApiKeyAuthFilter))]
    public class UyelerController : ControllerBase
    {
        public readonly IUyelerRepository _uyelerRepository;

        public UyelerController(IUyelerRepository uyelerRepository)
        {
            _uyelerRepository = uyelerRepository;
        }

        [HttpGet]
        public async Task<IActionResult> UyelerList()
        {
            var values = await _uyelerRepository.GetAllAsync();
            return Ok(values);
        }
    }
}
