using BAO_CAO.Models;
using BAO_CAO.Reponsitory;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<Baocaodbcontext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("QLKS")));


builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Identity/Account/Login";  // Trang đăng nhập
    options.LogoutPath = "/Identity/Account/Logout";  // Trang đăng xuất
    options.AccessDeniedPath = "/Identity/Account/AccessDenied";  // Trang từ chối truy cập
});

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddDefaultUI()
    .AddDefaultTokenProviders()
    .AddEntityFrameworkStores<Baocaodbcontext>();

builder.Services.AddScoped<Iphongreponsitory, EFPhongReponsitory>();
builder.Services.AddScoped<IKhachHangreponsitory, EFKhachHangreponsitory>();
builder.Services.AddScoped<INhanVienreponsitory, EFNhanVienreponsitory>();
builder.Services.AddScoped<IHopdongthuereponsitory, EFHopDongreponsitory>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Areas",
        pattern: "{area:exists}/{controller=TrangQL}/{action=Index}/{id?}"

        );
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
