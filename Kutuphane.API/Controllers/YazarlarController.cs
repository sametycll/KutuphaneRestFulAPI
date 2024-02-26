using Kutuphane.API.Repositories.KategoriRepository;
using Kutuphane.API.Repositories.YazarlarRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YazarlarController : ControllerBase
    {
        public readonly IYazarlarRepository _yazarlarRepository;

        public YazarlarController(IYazarlarRepository yazarlarRepository)
        {
            _yazarlarRepository = yazarlarRepository;
        }


        [HttpGet]
        public async Task<IActionResult> KategoriList()
        {
            var values = await _yazarlarRepository.GetAllAsync();
            return Ok(values);
        }
    }
}
