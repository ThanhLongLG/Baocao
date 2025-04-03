using BAO_CAO.Models;
using BAO_CAO.Reponsitory;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
[ApiController]
[Route("api/booking")]
public class BookingController : ControllerBase
{
    private readonly Baocaodbcontext _context;
    private readonly IKhachHangreponsitory _khachangreponsitory;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly Iphongreponsitory _phongreponsitory;

    public BookingController(Baocaodbcontext context, UserManager<ApplicationUser> userManager,IKhachHangreponsitory khachHangreponsitory,Iphongreponsitory iphongreponsitory)
    {
        _context = context;
        _userManager = userManager;
        _khachangreponsitory =khachHangreponsitory;
        _phongreponsitory= iphongreponsitory;
    }
    [HttpPost("book")]
    public async Task<IActionResult> BookRoom([FromBody] PayCheck request)
    {
        // ✅ Log dữ liệu nhận được từ frontend
        Console.WriteLine($"📥 Request nhận được: {JsonConvert.SerializeObject(request)}");

        if (request == null)
        {
            return BadRequest(new { Message = "Dữ liệu gửi lên bị null!" });
        }

        if (string.IsNullOrEmpty(request.MaKH))
        {
            return BadRequest(new { Message = "Thiếu MaKH!" });
        }

        if (request.Maphong <= 0)
        {
            return BadRequest(new { Message = "Thiếu Maphong!" });
        }

        if (request.CheckInDate == default || request.CheckOutDate == default)
        {
            return BadRequest(new { Message = "Thiếu thông tin ngày check-in hoặc check-out!" });
        }

        if (request.CheckInDate >= request.CheckOutDate)
        {
            return BadRequest(new { Message = "Ngày check-in phải trước ngày check-out!" });
        }

        var phong = await _context.Phong.FindAsync(request.Maphong);
        if (phong == null)
        {
            return NotFound("Phòng không tồn tại.");
        }

        // Kiểm tra xem phòng đã được đặt trong khoảng thời gian này chưa
        var existingBooking = await _context.PayCheck
            .Where(p => p.Maphong == request.Maphong 
                && p.Status != "Cancelled"
                && ((p.CheckInDate <= request.CheckInDate && p.CheckOutDate > request.CheckInDate)
                    || (p.CheckInDate < request.CheckOutDate && p.CheckOutDate >= request.CheckOutDate)
                    || (p.CheckInDate >= request.CheckInDate && p.CheckOutDate <= request.CheckOutDate)))
            .FirstOrDefaultAsync();

        if (existingBooking != null)
        {
            return BadRequest(new { Message = "Phòng đã được đặt trong khoảng thời gian này!" });
        }

        var paycheck = new PayCheck
        {
            MaKH = request.MaKH,
            Maphong = request.Maphong,
            CheckInDate = request.CheckInDate,
            CheckOutDate = request.CheckOutDate,
            BookingDate = DateTime.UtcNow,
            Status = "Pending",
            Phong = phong
        };

        _context.PayCheck.Add(paycheck);
        await _context.SaveChangesAsync();

        return Ok(new { Message = "Đặt phòng thành công!", PaycheckId = paycheck.Id });
    }



    [HttpGet("cart")]
    public async Task<IActionResult> GetCart()
    {
        var user = await _userManager.GetUserAsync(User);
        if (user == null)
        {
            return Unauthorized();
        }

        var cartItems = await _context.PayCheck
            .Where(p => p.MaKH == user.Id && p.Status == "Pending")
            .Select(p => new
            {
                p.Id,
                PhongName = p.Phong.Name, // Lấy tên phòng từ bảng Phong
                p.Maphong,
                p.Phong.sophong,
                p.Phong.gia,
                p.BookingDate,
                p.Status
            })
            .ToListAsync();

        return Ok(cartItems);
    }

}


