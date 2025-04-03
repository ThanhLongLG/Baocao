using BAO_CAO.Models;

namespace BAO_CAO.Reponsitory
{
    public interface IKhachHangreponsitory
    {

        Task<IEnumerable<KhachHang>> GetAllAsync(string? searchValue);
        Task<IEnumerable<KhachHang>> GetAllAsync();
        Task<KhachHang> GetByIdAsync(int MaKH);
        Task AddAsync(KhachHang khachHang);
        Task DeleteAsync(int MaKH);
        Task UpdateAsync(KhachHang khachHang);
        Task<int> GetTotalCountAsync();
    }
}
