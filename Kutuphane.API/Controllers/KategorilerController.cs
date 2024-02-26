using Kutuphane.API.Dtos.KategoriDtos;
using Kutuphane.API.Repositories.KategoriRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorilerController : ControllerBase
    {
        public readonly IKategoriRepository _kategoriRepository;

        public KategorilerController(IKategoriRepository kategoriRepository)
        {
            _kategoriRepository = kategoriRepository;
        }

        [HttpGet]
        public async Task<IActionResult> KategoriList()
        {
            var values = await _kategoriRepository.GetAllAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetKategori(int id)
        {
            var value =await _kategoriRepository.GetKategori(id);
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateKategori(CreateKategoriDto entity)
        {
            _kategoriRepository.CreateAsync(entity);
            return Ok(entity);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateKategori(AllKategoriDto entity)
        {
            _kategoriRepository.UpdateKategori(entity);
            return Ok(entity);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteKategori(int id)
        {
            _kategoriRepository.DeleteKategori(id);
            return Ok("Kategori başarılı bir şekilde silindi");
        }
    }
}
