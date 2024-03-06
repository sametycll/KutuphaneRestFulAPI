using Dapper;
using Kutuphane.API.Dtos.KullanicilarDtos;
using Kutuphane.API.Models.DapperContext;
using Kutuphane.API.Repositories.KullanicilarRepository;
using Kutuphane.API.Tools;
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
            string query = "Select * From Kullanicilar Where KullaniciAdi=@kullaniciAdi and Sifre=@sifre";// and Yetki=@yetki";
            var parameters = new DynamicParameters();
            parameters.Add("@kullaniciAdi", dto.KullaniciAdi);
            parameters.Add("@sifre", dto.Sifre);
            //parameters.Add("@yetki", dto.Yetki);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<LoginKullanicilarDto>(query,parameters);
                if (values != null)
                {
                    CheckUser model = new CheckUser();
                    model.Username = values.KullaniciAdi;
                    model.Id = (int)values.KullaniciID;
                    model.Role = values.Yetki;
                    var token = JwtTokenGenerator.GenerateToken(model);
                    return Ok(token);
                }
                else
                {
                    return BadRequest();
                }
            }

        }


        [HttpPost("CreateToken")]
        public IActionResult CreateToken(CheckUser model)
        {
            var values = JwtTokenGenerator.GenerateToken(model);
            return Ok(values);
        }
    }
}
