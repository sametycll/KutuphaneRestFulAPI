using Kutuphane.API.Repositories.KategoriRepository;
using Kutuphane.API.Repositories.YayinEvleriRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YayinEvleriController : ControllerBase
    {
        public readonly IYayinEvleriRepository _yayinEvleriRepository;

        public YayinEvleriController(IYayinEvleriRepository yayinEvleriRepository)
        {
            _yayinEvleriRepository = yayinEvleriRepository;
        }

        [HttpGet]
        public async Task<IActionResult> YayinEvleriList()
        {
            var values = await _yayinEvleriRepository.GetAllAsync();
            return Ok(values);
        }
    }
}
