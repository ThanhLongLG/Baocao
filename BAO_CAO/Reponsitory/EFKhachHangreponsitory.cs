using System.Drawing.Printing;
using BAO_CAO.Models;
using Microsoft.EntityFrameworkCore;

namespace BAO_CAO.Reponsitory
{
    public class EFKhachHangreponsitory : IKhachHangreponsitory
    {

        private readonly Baocaodbcontext _context;

        public EFKhachHangreponsitory(Baocaodbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<KhachHang>> GetAllAsync(string? searchValue)
        {
            var query = _context.KhachHang.AsQueryable();

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(c => c.TenKh.Contains(searchValue));
            }

            return await query.ToListAsync();
        }
        public async Task<IEnumerable<KhachHang>> GetAllAsync()
        {
            return await _context.KhachHang.ToListAsync();
        }
 
        public async Task AddAsync(KhachHang khachHang)
        {
            _context.KhachHang.Add(khachHang);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int Makh)
        {
            var khachHang = await _context.KhachHang.FindAsync(Makh);
            _context.KhachHang.Remove(khachHang);
            await _context.SaveChangesAsync();
        }

        public async Task<KhachHang> GetByIdAsync(int Makh)
        {
            return await _context.KhachHang.FindAsync(Makh);
        }

        public async Task UpdateAsync(KhachHang khachHang)
        {
            _context.KhachHang.Update(khachHang);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await _context.KhachHang.CountAsync();
        }
    }
}
