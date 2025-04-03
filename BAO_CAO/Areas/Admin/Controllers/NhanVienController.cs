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
    public class NhanVienController : Controller
    {
        private readonly Iphongreponsitory _phongreponsitory;
        private readonly IKhachHangreponsitory _khachangreponsitory;
        private readonly INhanVienreponsitory _nhanvienreponsitory;
        private readonly IHopdongthuereponsitory _hopdongreponsitory;
        public NhanVienController(Iphongreponsitory phongreponsitory, IHopdongthuereponsitory hopdongthuereponsitory, IKhachHangreponsitory khachHangreponsitory, INhanVienreponsitory nhanVienreponsitory)
        {
            _phongreponsitory = phongreponsitory;
            _hopdongreponsitory = hopdongthuereponsitory;
            _khachangreponsitory = khachHangreponsitory;
            _nhanvienreponsitory = nhanVienreponsitory;
        }
        public async Task<IActionResult> Index(string? searchValue)
        {
            var nhanviens = await _nhanvienreponsitory.GetAllAsync(searchValue);
            ViewBag.searchValue = searchValue;

            return View(nhanviens);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Nhanvien nhanvien)
        {
            if (ModelState.IsValid)
            {
                await _nhanvienreponsitory.AddAsync(nhanvien);
                return RedirectToAction(nameof(Index));
            }
             return View(nhanvien);
        }
    
        public async Task<IActionResult> Display(int id)
        {
            var nhanvien = await _nhanvienreponsitory.GetByIdAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var nhanvien = await _nhanvienreponsitory.GetByIdAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfired(int id)
        {
            await _nhanvienreponsitory.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var nhanvien = await _nhanvienreponsitory.GetByIdAsync(id);
            if (nhanvien == null)
            {
                return NotFound();
            }
            return View(nhanvien);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Nhanvien nhanvien)
        {
            if (id != nhanvien.MaNV)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                // Tìm sản phẩm cũ để cập nhật
                var existingProduct = await _nhanvienreponsitory.GetByIdAsync(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

               

                // Cập nhật các thuộc tính khác
                existingProduct.TenNV = nhanvien.TenNV;
                existingProduct.DiaChi = nhanvien.DiaChi;
                existingProduct.ChucVu = nhanvien.ChucVu;
                existingProduct.hesoluong = nhanvien.hesoluong;

                // Lưu thay đổi vào cơ sở dữ liệu
                await _nhanvienreponsitory.UpdateAsync(existingProduct);

                return RedirectToAction(nameof(Index));
            }

            return View(nhanvien);
        }
    }
}
