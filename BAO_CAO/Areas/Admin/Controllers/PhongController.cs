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
    public class PhongController : Controller
    {
        private readonly Iphongreponsitory _phongreponsitory;
        public PhongController(Iphongreponsitory phongreponsitory)
        {
            _phongreponsitory = phongreponsitory;
        }
        public async Task<IActionResult> Index(string? searchValue)
        {


            var phong = await _phongreponsitory.GetAllAsync(searchValue);


            ViewBag.searchValue = searchValue;

            return View(phong);
        }
        public async Task<IActionResult> Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(Phong phong, IFormFile ImageUrl, List<IFormFile> ImageUrls)
        {

            if (ModelState.IsValid)
            {
                if (ImageUrl != null)
                {
                    phong.ImageUrl = await SaveImage(ImageUrl);
                }
                if (ImageUrls != null)
                {
                    phong.ImageUrls = new List<string>();
                    foreach (var file in ImageUrls)
                    {
                        phong.ImageUrls.Add(await SaveImage(file));
                    }
                }
                await _phongreponsitory.AddAsync(phong);
                return RedirectToAction(nameof(Index));
            }
            

            return View(phong);
        }
        private async Task<string> SaveImage(IFormFile image)
        {
            var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

            // Tạo thư mục nếu chưa tồn tại
            if (!Directory.Exists(uploadsFolder))
            {
                Directory.CreateDirectory(uploadsFolder);
            }

            // Tạo đường dẫn file
            var filePath = Path.Combine(uploadsFolder, image.FileName);

            // Lưu file vào thư mục
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            // Trả về đường dẫn tương đối để hiển thị ảnh
            return "/images/" + image.FileName;
        }
        public async Task<IActionResult> Display(int id)
        {
            var phong = await _phongreponsitory.GetByIdAsync(id);
            if (phong == null)
            {
                return NotFound();
            }
            return View(phong);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var phong = await _phongreponsitory.GetByIdAsync(id);
            if (phong == null)
            {
                return NotFound();
            }
            return View(phong);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfired(int id)
        {
            await _phongreponsitory.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int id)
        {
            var phong = await _phongreponsitory.GetByIdAsync(id);
            if (phong == null)
            {
                return NotFound();
            }
            return View(phong);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id, Phong phong, IFormFile? imageFile)
        {
            if (id != phong.Maphong)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                // Tìm sản phẩm cũ để cập nhật
                var existingProduct = await _phongreponsitory.GetByIdAsync(id);
                if (existingProduct == null)
                {
                    return NotFound();
                }

                // Nếu có ảnh mới, lưu ảnh và cập nhật ImageUrl
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Tạo thư mục lưu trữ nếu chưa có
                    var uploadPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }

                    // Tạo tên file duy nhất
                    var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine(uploadPath, uniqueFileName);

                    // Lưu file ảnh vào server
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await imageFile.CopyToAsync(stream);
                    }

                    // Xóa ảnh cũ (nếu có)
                    if (!string.IsNullOrEmpty(existingProduct.ImageUrl))
                    {
                        var oldImagePath = Path.Combine(uploadPath, Path.GetFileName(existingProduct.ImageUrl));
                        if (System.IO.File.Exists(oldImagePath))
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    // Cập nhật đường dẫn ảnh mới
                    existingProduct.ImageUrl = "/images/" + uniqueFileName;
                }

                // Cập nhật các thuộc tính khác
                existingProduct.Name = phong.Name;
                existingProduct.gia = phong.gia;
                existingProduct.sogiuong = phong.sogiuong;
                existingProduct.sophong = phong.sophong;
                existingProduct.dientich = phong.dientich;
                // Lưu thay đổi vào cơ sở dữ liệu
                await _phongreponsitory.UpdateAsync(existingProduct);

                return RedirectToAction(nameof(Index));
            }

            return View(phong);
        }
    }
}
