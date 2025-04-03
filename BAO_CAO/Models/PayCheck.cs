using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BAO_CAO.Models
{
    public class PayCheck
    {
        [Key]
        public int Id { get; set; }
        public DateTime BookingDate { get; set; } = DateTime.UtcNow; 

        [Required]
        [MaxLength(20)]
        public string Status { get; set; } = "Pending"; 

        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }

        [ForeignKey("Maphong")]
        [Required]
        public int Maphong { get; set; }
        public Phong? Phong { get; set; }

        [ForeignKey("MaKH")]
        [Required]
        public string MaKH { get; set; }
        public virtual KhachHang? KhachHang { get; set; }
    }
}
