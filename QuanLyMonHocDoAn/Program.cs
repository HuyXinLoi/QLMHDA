using Microsoft.EntityFrameworkCore;
using QuanLyMonHocDoAn.Models;
using QuanLyMonHocDoAn.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IThongBaoRepository, EFThongbaoRepository>();
builder.Services.AddDbContext<QldetainckhContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("db")));
builder.Services.AddHttpContextAccessor();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
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
app.UseSession();
app.UseAuthorization();
//Lỗi này giết chết một người xác thực mà không có thì fix đã lun 
app.UseAuthentication();

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=TrangChu}/{action=TrangChu}/{id?}");
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(name: "Admin", pattern: "{area:exists}/{controller=Account}/{action=Login}/{id?}");
    endpoints.MapControllerRoute(name: "default", pattern: "{controller=TrangChu}/{action=TrangChu}/{id?}");
});

app.Run();
