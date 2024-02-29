using Dapper;
using Kutuphane.API.Dtos.KullanicilarDtos;
using Kutuphane.API.Models.DapperContext;
using Kutuphane.API.Repositories.KullanicilarRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kutuphane.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        public readonly Context _context;

        public LoginController(Context context)
        {
            _context = context;
        }

        
        [HttpPost]
        public async Task<IActionResult> Login(LoginKullanicilarDto dto)
        {
            string query = "Select * From Kullanicilar Where KullaniciAdi=@kullaniciAdi and Sifre=@sifre";
            var parameters = new DynamicParameters();
            parameters.Add("@kullaniciAdi", dto.KullaniciAdi);
            parameters.Add("@sifre", dto.Sifre);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<LoginKullanicilarDto>(query,parameters);
                if (values != null)
                {
                    return Ok(values);
                }
                else
                {
                    return BadRequest();
                }
            }

        }



    }
}
