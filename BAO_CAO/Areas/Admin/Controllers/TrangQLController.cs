using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using BAO_CAO.Models;
using BAO_CAO.Reponsitory;
using BAO_CAO.Areas.Admin.Models;

namespace BAO_CAO.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class TrangQLController : Controller
    {

        private readonly Iphongreponsitory _phongreponsitory;
        private readonly IKhachHangreponsitory _khachangreponsitory;
        private readonly INhanVienreponsitory _nhanvienreponsitory;
        private readonly IHopdongthuereponsitory _hopdongreponsitory;
        public TrangQLController(Iphongreponsitory phongreponsitory, IHopdongthuereponsitory hopdongthuereponsitory, IKhachHangreponsitory khachHangreponsitory, INhanVienreponsitory nhanVienreponsitory)
        {
            _phongreponsitory = phongreponsitory;
            _hopdongreponsitory = hopdongthuereponsitory;
            _khachangreponsitory = khachHangreponsitory;
            _nhanvienreponsitory = nhanVienreponsitory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Phongcount = await _phongreponsitory.GetTotalCountAsync();
            ViewBag.Khachhangcount = await _khachangreponsitory.GetTotalCountAsync();
            ViewBag.nhanviencount = await _nhanvienreponsitory.GetTotalCountAsync();
            return View();
        }
    }
}
