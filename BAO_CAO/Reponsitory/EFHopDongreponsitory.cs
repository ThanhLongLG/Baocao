using System.Drawing.Printing;
using BAO_CAO.Models;
using Microsoft.EntityFrameworkCore;

namespace BAO_CAO.Reponsitory
{
    public class EFHopDongreponsitory : IHopdongthuereponsitory
    {

        private readonly Baocaodbcontext _context;

        public EFHopDongreponsitory(Baocaodbcontext context)
        {
            _context = context;
        }
    
        public async Task<IEnumerable<HopDongThue>> GetAllAsync()
        {
            return await _context.HopDongThue.ToListAsync();
        }

        public async Task AddAsync(HopDongThue hopDongThue)
        {
            _context.HopDongThue.Add(hopDongThue);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int mahd)
        {
            var hopDongThue = await _context.HopDongThue.FindAsync(mahd);
            _context.HopDongThue.Remove(hopDongThue);
            await _context.SaveChangesAsync();
        }

        public async Task<HopDongThue> GetByIdAsync(int mahd)
        {
            return await _context.HopDongThue.FindAsync(mahd);
        }

        public async Task UpdateAsync(HopDongThue hopDongThue)
        {
            _context.HopDongThue.Update(hopDongThue);
            await _context.SaveChangesAsync();
        }
        public async Task<int> GetTotalCountAsync()
        {
            return await _context.HopDongThue.CountAsync();
        }
    }
}
