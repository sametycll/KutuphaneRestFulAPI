using Kutuphane.API.Dtos.YazarlarDtos;

namespace Kutuphane.API.Repositories.YazarlarRepository
{
    public interface IYazarlarRepository
    {
        Task<List<AllYazarlarDto>> GetAllAsync();
        void CreateAsync(CreateYazarlarDto entity);
        void DeleteYazarlar(int id);
        void UpdateYazarlar(AllYazarlarDto entity);
        Task<AllYazarlarDto> GetYazarlar(int id);
    }
}
