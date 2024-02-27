using Kutuphane.API.Repositories.KategoriRepository;
using Kutuphane.API.Repositories.KitaplarRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KitaplarController : ControllerBase
    {
        public readonly IKitaplarRepository _kitaplarRepository;

        public KitaplarController(IKitaplarRepository kitaplarRepository)
        {
            _kitaplarRepository = kitaplarRepository;
        }

        [HttpGet]
        public async Task<IActionResult> KitaplarList()
        {
            var values = await _kitaplarRepository.GetAllAsync();
            return Ok(values);
        }
        [HttpGet("KitaplarListWithParameters")]
        public async Task<IActionResult> KitaplarListWithParameters()
        {
            var values = await _kitaplarRepository.GetAllWithParametersAsync();
            return Ok(values);
        }
    }
}
