using BAO_CAO.Models;

namespace BAO_CAO.Reponsitory
{
    public interface Iphongreponsitory
    {

        Task<IEnumerable<Phong>> GetAllAsync(string? searchValue);
        Task<IEnumerable<Phong>> GetAllAsync();
        Task<Phong> GetByIdAsync(int Maphong);
        Task AddAsync(Phong phong);
        Task DeleteAsync(int Maphong);
        Task UpdateAsync(Phong phong);
        Task<int> GetTotalCountAsync();
    }
}
