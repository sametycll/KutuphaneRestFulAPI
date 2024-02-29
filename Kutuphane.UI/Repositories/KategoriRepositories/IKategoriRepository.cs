using Kutuphane.UI.Dtos.KategoriDtos;

namespace Kutuphane.UI.Repositories.KategoriRepositories
{
    public interface IKategoriRepository
    {       
        Task CreateAsync(List<AllKategoriDto> entities);
      
    }
}
