using BAO_CAO.Models;

namespace BAO_CAO.Reponsitory
{
    public interface INhanVienreponsitory
    {

        Task<IEnumerable<Nhanvien>> GetAllAsync(string? searchValue);
        Task<IEnumerable<Nhanvien>> GetAllAsync();
        Task<Nhanvien> GetByIdAsync(int MaNV);
        Task AddAsync(Nhanvien nhanvien);
        Task DeleteAsync(int MaNV);
        Task UpdateAsync(Nhanvien nhanvien);
        Task<int> GetTotalCountAsync();
    }
}
