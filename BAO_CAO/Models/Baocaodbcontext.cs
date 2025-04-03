using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace BAO_CAO.Models
{
    public class Baocaodbcontext: IdentityDbContext<ApplicationUser>
    {
        public Baocaodbcontext( DbContextOptions<Baocaodbcontext> options ) : base( options ) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình quan hệ 1-N giữa Nhanvien và HopDongThue
            modelBuilder.Entity<HopDongThue>()
                .HasOne(hd => hd.Nhanvien)
                .WithMany(nv => nv.HopDongThues)
                .HasForeignKey(hd => hd.MaNV)
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ 1-N giữa KhachHang và HopDongThue
            modelBuilder.Entity<HopDongThue>()
                .HasOne(hd => hd.KhachHang)
                .WithMany(kh => kh.HopDongThues)
                .HasForeignKey(hd => hd.MaKH)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<HopDongThue>()
                .HasOne(hd => hd.Phong)
                .WithMany(kh => kh.HopDongThues)
                .HasForeignKey(hd => hd.Maphong)
                .OnDelete(DeleteBehavior.Cascade);
        }
        public DbSet<PayCheck> PayCheck { get; set; }
        public DbSet<Phong> Phong { get; set; }
        public DbSet<Nhanvien> Nhanvien { get; set; }
        public DbSet<HopDongThue> HopDongThue { get; set; }
        public DbSet<KhachHang> KhachHang { get; set; }


    }
}
