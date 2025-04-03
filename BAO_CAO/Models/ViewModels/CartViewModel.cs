using System.Collections.Generic;

namespace BAO_CAO.Models.ViewModels
{
    public class CartItemViewModel
    {
        public int Id { get; set; }
        public string PhongName { get; set; }
        public decimal Gia { get; set; }
        public DateTime CheckInDate { get; set; }
        public DateTime CheckOutDate { get; set; }
        public string Status { get; set; }
    }

    public class CartViewModel
    {
        public List<CartItemViewModel> Items { get; set; } = new List<CartItemViewModel>();
        public decimal Total => Items.Sum(item => item.Gia);
        public int ItemCount => Items.Count;
    }
} 