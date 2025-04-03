using System.Drawing.Printing;
using BAO_CAO.Areas.Admin.Models;
using BAO_CAO.Models;
using BAO_CAO.Reponsitory;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BAO_CAO.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class KhachHangController : Controller
    {
        private readonly Iphongreponsitory _phongreponsitory;
        private readonly IKhachHangreponsitory _khachangreponsitory;
        private readonly INhanVienreponsitory _nhanvienreponsitory;
        private readonly IHopdongthuereponsitory _hopdongreponsitory;
        public KhachHangController(Iphongreponsitory phongreponsitory, IHopdongthuereponsitory hopdongthuereponsitory, IKhachHangreponsitory khachHangreponsitory, INhanVienreponsitory nhanVienreponsitory)
        {
            _phongreponsitory = phongreponsitory;
            _hopdongreponsitory = hopdongthuereponsitory;
            _khachangreponsitory = khachHangreponsitory;
            _nhanvienreponsitory = nhanVienreponsitory;
        }
        public async Task<IActionResult> Index(string? searchValue)
        {
            var khachHangs = await _khachangreponsitory.GetAllAsync(searchValue);
            ViewBag.searchValue = searchValue;

            return View(khachHangs);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                await _khachangreponsitory.AddAsync(khachHang);
                return RedirectToAction(nameof(Index));
            }
             return View(khachHang);
        }
    
        public async Task<IActionResult> Display(int id)
        {
            var khachHang = await _khachangreponsitory.GetByIdAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var khachHang = await _khachangreponsitory.GetByIdAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfired(int id)
        {
            await _khachangreponsitory.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var khachHang = await _khachangreponsitory.GetByIdAsync(id);
            if (khachHang == null)
            {
                return NotFound();
            }
            return View(khachHang);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, KhachHang khachHang)
        {
            if (id != khachHang.MaKH)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                // Tìm sản phẩm cũ để cập nhật
                var existingProduct = await _khachangreponsitory.GetByIdAsync(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

               

                // Cập nhật các thuộc tính khác
                existingProduct.TenKh = khachHang.TenKh;
                existingProduct.DiaChi = khachHang.DiaChi;
                existingProduct.danhgia = khachHang.danhgia;
             
                // Lưu thay đổi vào cơ sở dữ liệu
                await _khachangreponsitory.UpdateAsync(existingProduct);

                return RedirectToAction(nameof(Index));
            }

            return View(khachHang);
        }
    }
}
