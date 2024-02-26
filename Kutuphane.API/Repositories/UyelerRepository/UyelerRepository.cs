using Dapper;
using Kutuphane.API.Dtos.KategoriDtos;
using Kutuphane.API.Dtos.UyelerDtos;
using Kutuphane.API.Models.DapperContext;

namespace Kutuphane.API.Repositories.UyelerRepository
{
    public class UyelerRepository : IUyelerRepository
    {
        public readonly Context _context;

        public UyelerRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<AllUyelerDto>> GetAllAsync()
        {
            string query = "Select * From Uyeler";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<AllUyelerDto>(query);
                return values.ToList();
            }
        }

        public void CreateAsync(CreateUyelerDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteUyeler(int id)
        {
            throw new NotImplementedException();
        }  

        public Task<AllUyelerDto> GetUyeler(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateUyeler(CreateUyelerDto entity)
        {
            throw new NotImplementedException();
        }
    }
}
