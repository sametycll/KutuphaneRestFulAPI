using Dapper;
using Kutuphane.API.Dtos.KategoriDtos;
using Kutuphane.API.Dtos.YayinEvleriDtos;
using Kutuphane.API.Models.DapperContext;

namespace Kutuphane.API.Repositories.YayinEvleriRepository
{
    public class YayinEvleriRepository : IYayinEvleriRepository
    {
        public readonly Context _context;

        public YayinEvleriRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<AllYayinEvleriDto>> GetAllAsync()
        {
            string query = "Select * From YayinEvleri";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<AllYayinEvleriDto>(query);
                return values.ToList();
            }
        }

        public void CreateAsync(CreateYayinEvleriDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteYayinEvleri(int id)
        {
            throw new NotImplementedException();
        }    

        public Task<AllYayinEvleriDto> GetYayinEvleri(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateYayinEvleri(AllYayinEvleriDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
