using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BAO_CAO.Models
{
    public class Nhanvien
    {
        [Key]
        public int MaNV { get; set; }
        [Required, StringLength(100)]
        public string TenNV { get; set; }
        [Required, StringLength(100)]
        public string DiaChi { get; set; }


        public string ChucVu { get; set; }

        public float hesoluong { get; set; }
        public ICollection<HopDongThue> HopDongThues { get; set; } = new List<HopDongThue>();


    }
}
