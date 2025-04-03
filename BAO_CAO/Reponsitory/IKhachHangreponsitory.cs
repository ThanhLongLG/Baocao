using BAO_CAO.Models;

namespace BAO_CAO.Reponsitory
{
    public interface IKhachHangreponsitory
    {
        Task<KhachHang?> GetByUserIdAsync(string userId);
        Task<IEnumerable<KhachHang>> GetAllAsync(string? searchValue);
        Task<IEnumerable<KhachHang>> GetAllAsync();
        Task<KhachHang> GetByIdAsync(string MaKH);
        Task AddAsync(KhachHang khachHang);
        Task DeleteAsync(string MaKH);
        Task UpdateAsync(KhachHang khachHang);
        Task<int> GetTotalCountAsync();
    }
}
