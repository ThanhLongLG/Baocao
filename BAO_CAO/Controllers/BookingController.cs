using System.Diagnostics;
using BAO_CAO.Models;
using BAO_CAO.Reponsitory;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BAO_CAO.Controllers
{
    [ApiController]
    [Route("api/booking")]
    public class BookingController : Controller
    {
        private readonly Baocaodbcontext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        private readonly ILogger<HomeController> _logger;

        public BookingController(Baocaodbcontext context, ILogger<HomeController> logger)
        {
            _logger = logger;
            _context = context;
        }
        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult GetRooms()
        {
            var rooms = _context.Phong
                .Select(p => new
                {
                    Maphong = p.Maphong,
                    Name = p.Name,
                    ImageUrl = p.ImageUrl ?? "/images/default.jpg", // Nếu ImageUrl null thì dùng ảnh mặc định
                    gia = p.gia,
                    sogiuong = p.sogiuong ?? "Không xác định",
                    dientich = p.dientich
                })
                .ToList();

            return Json(rooms);
        }
    }
}
