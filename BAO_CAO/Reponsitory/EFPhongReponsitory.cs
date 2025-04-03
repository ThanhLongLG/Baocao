using System.Drawing.Printing;
using BAO_CAO.Models;
using Microsoft.EntityFrameworkCore;

namespace BAO_CAO.Reponsitory
{
    public class EFPhongReponsitory:Iphongreponsitory
    {

        private readonly Baocaodbcontext _context;

        public EFPhongReponsitory(Baocaodbcontext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Phong>> GetAllAsync()
        {
            return await _context.Phong.ToListAsync();
        }
        public async Task<IEnumerable<Phong>> GetAllAsync(string? searchValue)
        {
            var query = _context.Phong.AsQueryable();

            if (!string.IsNullOrEmpty(searchValue))
            {
                query = query.Where(c => c.Name.Contains(searchValue));
            }

            return await query.ToListAsync();
        }
        public async Task AddAsync(Phong phong)
        {
            _context.Phong.Add(phong);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int Maphong)
        {
            var phong = await _context.Phong.FindAsync(Maphong);
            _context.Phong.Remove(phong);
            await _context.SaveChangesAsync();
        }

        public async Task<Phong> GetByIdAsync(int Maphong)
        {
            return await _context.Phong.FindAsync(Maphong);
        }

        public async Task UpdateAsync(Phong phong)
        {
            _context.Phong.Update(phong);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await _context.Phong.CountAsync();
        }
    }
}
