using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BAO_CAO.Models
{
    public class KhachHang
    {
        [Key]
        public string MaKH { get; set; }
        [Required, StringLength(100)]
        public string TenKh { get; set; }
        [Required, StringLength(100)]
        public string DiaChi { get; set; }

        public string SDT {  get; set; }

        public string email { get; set; }

        public string? danhgia  { get; set; }
        public string UserId { get; set; }
        public ICollection<HopDongThue> HopDongThues { get; set; } = new List<HopDongThue>();


    }
}
