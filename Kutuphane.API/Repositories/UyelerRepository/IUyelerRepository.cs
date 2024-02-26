using Kutuphane.API.Dtos.UyelerDtos;


namespace Kutuphane.API.Repositories.UyelerRepository
{
    public interface IUyelerRepository
    {
        Task<List<AllUyelerDto>> GetAllAsync();
        void CreateAsync(CreateUyelerDto entity);
        void DeleteUyeler(int id);
        void UpdateUyeler(CreateUyelerDto entity);
        Task<AllUyelerDto> GetUyeler(int id);
    }
}
