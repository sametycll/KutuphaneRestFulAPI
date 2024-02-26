using Kutuphane.API.Dtos.YayinEvleriDtos;

namespace Kutuphane.API.Repositories.YayinEvleriRepository
{
    public interface IYayinEvleriRepository
    {
        Task<List<AllYayinEvleriDto>> GetAllAsync();
        void CreateAsync(CreateYayinEvleriDto entity);
        void DeleteYayinEvleri(int id);
        void UpdateYayinEvleri(AllYayinEvleriDto entity);
        Task<AllYayinEvleriDto> GetYayinEvleri(int id);
    }
}
