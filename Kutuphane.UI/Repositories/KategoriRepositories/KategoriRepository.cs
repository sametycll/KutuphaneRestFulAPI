using Dapper;
using Kutuphane.UI.DbContext;
using Kutuphane.UI.Dtos.KategoriDtos;

namespace Kutuphane.UI.Repositories.KategoriRepositories
{
    public class KategoriRepository : IKategoriRepository
    {
        public readonly Context _context;

        public KategoriRepository(Context context)
        {
            _context = context;
        }

        public async Task CreateAsync(List<AllKategoriDto> entities)
        {
            string query = "insert into tstKategoriler (KategoriAdi,CategoryStatus) values (@kategoriAdi,@categoryStatus) ";
            

            foreach (var entity in entities)
            {
                var parameters = new DynamicParameters();
                parameters.Add("@kategoriAdi", entity.KategoriAdi);
                parameters.Add("@categoryStatus", entity.CategoryStatus);
                using (var connection = _context.CreateConnection())
                {
                    await connection.ExecuteAsync(query, parameters);
                }

            }           
        }

        public bool kontrolDb(List<AllKategoriDto> entities)
        {          
            return false;
        }
     
    }
}
