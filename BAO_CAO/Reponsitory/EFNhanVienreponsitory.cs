using System.Drawing.Printing;
using BAO_CAO.Models;
using Microsoft.EntityFrameworkCore;

namespace BAO_CAO.Reponsitory
{
    public class EFNhanVienreponsitory : INhanVienreponsitory
    {

        private readonly Baocaodbcontext _context;

        public EFNhanVienreponsitory(Baocaodbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Nhanvien>> GetAllAsync(string? searchValue)
        {
            var query = _context.Nhanvien.AsQueryable();

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(c => c.TenNV.Contains(searchValue));
            }

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<Nhanvien>> GetAllAsync()
        {
            return await _context.Nhanvien.ToListAsync();
        }
 
        public async Task AddAsync(Nhanvien nhanvien)
        {
            _context.Nhanvien.Add(nhanvien);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int MaNv)
        {
            var nhanvien = await _context.Nhanvien.FindAsync(MaNv);
            _context.Nhanvien.Remove(nhanvien);
            await _context.SaveChangesAsync();
        }

        public async Task<Nhanvien> GetByIdAsync(int MaNv)
        {
            return await _context.Nhanvien.FindAsync(MaNv);
        }

        public async Task UpdateAsync(Nhanvien nhanvien)
        {
            _context.Nhanvien.Update(nhanvien);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Nhanvien.CountAsync();
        }
    }
}
