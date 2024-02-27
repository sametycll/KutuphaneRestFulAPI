using Kutuphane.API.Dtos.KitaplarDtos;

namespace Kutuphane.API.Repositories.KitaplarRepository
{
    public interface IKitaplarRepository
    {
        Task<List<AllKitaplarDto>> GetAllAsync();
        Task<List<AllKitaplarWithParametersDto>> GetAllWithParametersAsync();
        void CreateAsync(CreateKitaplarDto entity);
        void DeleteKitaplar(int id);
        void UpdateKitaplar(AllKitaplarDto entity);
        Task<AllKitaplarDto> GetKitaplar(int id);
    }
}
