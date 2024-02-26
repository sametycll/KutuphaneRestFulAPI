using Kutuphane.API.Dtos.KategoriDtos;


namespace Kutuphane.API.Repositories.KategoriRepository
{
    public interface IKategoriRepository 
    {
        Task<List<AllKategoriDto>> GetAllAsync();
        void CreateAsync(CreateKategoriDto entity);
        void DeleteKategori(int id);
        void UpdateKategori(AllKategoriDto entity);
        Task<AllKategoriDto> GetKategori(int id);

    }
}
