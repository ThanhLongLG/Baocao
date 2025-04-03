using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace BAO_CAO.Models
{
    public class ApplicationUser :IdentityUser
    {
        [Required]
        public string Fullname {  get; set; }
        public string? Address { get; set; }
        public string? Age { get; set; }
    }
}
