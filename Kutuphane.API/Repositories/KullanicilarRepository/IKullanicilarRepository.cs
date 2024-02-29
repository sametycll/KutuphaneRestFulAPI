using Kutuphane.API.Dtos.KullanicilarDtos;

namespace Kutuphane.API.Repositories.KullanicilarRepository
{
    public interface IKullanicilarRepository
    {
        Task<List<AllKullanicilarDto>> GetAllAsync();
        void CreateAsync(CreateKullanicilarDto entity);
        void DeleteKullanicilar(int id);
        void UpdateKullanicilar(AllKullanicilarDto entity);
        Task<AllKullanicilarDto> GetKullanicilar(int id);
    }
}
