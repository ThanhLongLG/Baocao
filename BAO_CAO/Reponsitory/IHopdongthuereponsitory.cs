using BAO_CAO.Models;

namespace BAO_CAO.Reponsitory
{
    public interface IHopdongthuereponsitory
    {

 
        Task<IEnumerable<HopDongThue>> GetAllAsync();
        Task<HopDongThue> GetByIdAsync(int mahd);
        Task AddAsync(HopDongThue hopDongThue);
        Task DeleteAsync(int mahd);
        Task UpdateAsync(HopDongThue hopDongThue);
        Task<int> GetTotalCountAsync();
    }
}
