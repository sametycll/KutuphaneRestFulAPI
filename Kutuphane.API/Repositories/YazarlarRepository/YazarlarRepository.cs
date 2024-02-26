using Dapper;
using Kutuphane.API.Dtos.KategoriDtos;
using Kutuphane.API.Dtos.YazarlarDtos;
using Kutuphane.API.Models.DapperContext;

namespace Kutuphane.API.Repositories.YazarlarRepository
{
    public class YazarlarRepository : IYazarlarRepository
    {
        public readonly Context _context;

        public YazarlarRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<AllYazarlarDto>> GetAllAsync()
        {
            string query = "Select * From Yazarlar";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<AllYazarlarDto>(query);
                return values.ToList();
            }
        }

        public void CreateAsync(CreateYazarlarDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteYazarlar(int id)
        {
            throw new NotImplementedException();
        }       

        public Task<AllYazarlarDto> GetYazarlar(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateYazarlar(AllYazarlarDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
