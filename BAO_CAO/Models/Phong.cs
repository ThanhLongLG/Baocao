using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BAO_CAO.Models
{
    public class Phong
    {
        [Key]
        public int Maphong { get; set; }
        [Required, StringLength(100)]
        public string sophong { get; set; }
        [Required, StringLength(100)]
        public string Name { get; set; }

        [Range(0.01, 10000.00)]
        public decimal gia { get; set; }
        public string sogiuong { get; set; }

        public int dientich { get; set; }
        public string? ImageUrl { get; set; }

        public List<string>? ImageUrls { get; set; }

        public ICollection<HopDongThue> HopDongThues { get; set; } = new List<HopDongThue>();

    }
}
