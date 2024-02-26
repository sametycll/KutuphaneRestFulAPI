using Dapper;
using Kutuphane.API.Dtos.KategoriDtos;
using Kutuphane.API.Models.DapperContext;

namespace Kutuphane.API.Repositories.KategoriRepository
{
    public class KategoriRepository : IKategoriRepository
    {
        public readonly Context _context;

        public KategoriRepository(Context context)
        {
            _context = context;
        }
        public async Task<List<AllKategoriDto>> GetAllAsync()
        {
            string query = "Select * From Kategoriler";
            using(var connection =_context.CreateConnection())
            {
                var values = await connection.QueryAsync<AllKategoriDto>(query);
                return values.ToList(); 
            }
        }
        public async void CreateAsync(CreateKategoriDto entity)
        {
            string query = "insert into Kategoriler (KategoriAdi,CategoryStatus) values (@kategoriAdi,@categoryStatus) ";
            var parameters = new DynamicParameters();
            parameters.Add("@kategoriAdi", entity.KategoriAdi);
            parameters.Add("@categoryStatus", true);
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void DeleteKategori(int id)
        {
            string query = "Delete From Kategoriler Where KategoriID=@kategoriID";
            var parameters = new DynamicParameters();
            parameters.Add("@kategoriID", id);
            using(var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async void UpdateKategori(AllKategoriDto entity)
        {
            string query = "Update Kategoriler Set KategoriAdi=@kategoriAdi,CategoryStatus=@categoryStatus where KategoriID=@kategoriID";
            var parameters = new DynamicParameters();
            parameters.Add("@kategoriAdi",entity.KategoriAdi);
            parameters.Add("@categoryStatus", entity.CategoryStatus);
            parameters.Add("@kategoriID", entity.KategoriID);
            using( var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, parameters);
            }
        }

        public async Task<AllKategoriDto> GetKategori(int id)
        {
            string query = "Select * From Kategoriler Where KategoriID=@kategoriID";
            var parameters=new DynamicParameters();
            parameters.Add("@kategoriID", id);
            using(var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<AllKategoriDto>(query,parameters);
                return values;
            }
        }
    }
}
