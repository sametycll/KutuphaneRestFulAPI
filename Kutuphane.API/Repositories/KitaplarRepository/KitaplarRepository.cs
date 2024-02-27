using Dapper;
using Kutuphane.API.Dtos.KategoriDtos;
using Kutuphane.API.Dtos.KitaplarDtos;
using Kutuphane.API.Models.DapperContext;

namespace Kutuphane.API.Repositories.KitaplarRepository
{
    public class KitaplarRepository : IKitaplarRepository
    {
        public readonly Context _context;

        public KitaplarRepository(Context context)
        {
            _context = context;
        }

        public async Task<List<AllKitaplarDto>> GetAllAsync()
        {
            string query = "Select * From Kitaplar";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<AllKitaplarDto>(query);
                return values.ToList();
            }
        }
        public async Task<List<AllKitaplarWithParametersDto>> GetAllWithParametersAsync()
        {
            string query = "";
            query = "SELECT dbo.Kitaplar.KitapID, dbo.Kitaplar.KitapAd, dbo.Kitaplar.YayinTarihi, dbo.Kitaplar.SayfaSayisi, dbo.Kategoriler.KategoriAdi, dbo.Yazarlar.AdSoyad AS YazarAdSoyad, dbo.YayinEvleri.YayinEviAdi ";
            query += "FROM dbo.Kitaplar LEFT OUTER JOIN ";
            query += "dbo.YayinEvleri ON dbo.Kitaplar.YayinEviID = dbo.YayinEvleri.YayinEviID LEFT OUTER JOIN ";
            query += "dbo.Kategoriler ON dbo.Kitaplar.KategoriID = dbo.Kategoriler.KategoriID LEFT OUTER JOIN ";
            query += "dbo.Yazarlar ON dbo.Kitaplar.YazarID = dbo.Yazarlar.YazarID";

            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<AllKitaplarWithParametersDto>(query);
                return values.ToList();
            }
        }

        public void CreateAsync(CreateKitaplarDto entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteKitaplar(int id)
        {
            throw new NotImplementedException();
        }       

        public Task<AllKitaplarDto> GetKitaplar(int id)
        {
            throw new NotImplementedException();
        }

        public void UpdateKitaplar(AllKitaplarDto entity)
        {
            throw new NotImplementedException();
        }

       
    }
}
