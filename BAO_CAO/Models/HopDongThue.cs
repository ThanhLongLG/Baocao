using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BAO_CAO.Models
{
    public class HopDongThue
    {
        [Key]
        public int MaHopDong { get; set; }
      
        public float Tongtien {  get; set; }

        public DateTime ngaythanhtoan {  get; set; }
        [ForeignKey("MaNV")]
        public int MaNV { get; set; }
        public Nhanvien Nhanvien { get; set; }

        [ForeignKey("MaKH")]
        public int MaKH { get; set; }
        public KhachHang KhachHang { get; set; }
        [ForeignKey("Maphong")]
        public int Maphong { get; set; }
        public Phong Phong { get; set; }

    }
}
