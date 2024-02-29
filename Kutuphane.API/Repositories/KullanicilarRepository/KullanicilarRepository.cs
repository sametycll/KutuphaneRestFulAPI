using Dapper;
using Kutuphane.API.Dtos.KullanicilarDtos;
using Kutuphane.API.Models.DapperContext;

namespace Kutuphane.API.Repositories.KullanicilarRepository
{
    public class KullanicilarRepository : IKullanicilarRepository
    {
        public readonly Context _context;

        public KullanicilarRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<AllKullanicilarDto>> GetAllAsync()
        {
            string query = "Select * From Kullanicilar";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<AllKullanicilarDto>(query);
                return values.ToList();
            }
        }

        public Task<AllKullanicilarDto> GetKullanicilar(int id)
        {
            throw new NotImplementedException();
        }
        public void CreateAsync(CreateKullanicilarDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteKullanicilar(int id)
        {
            throw new NotImplementedException();
        }     

        public void UpdateKullanicilar(AllKullanicilarDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
