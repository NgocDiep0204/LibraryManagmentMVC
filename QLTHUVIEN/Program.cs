using Microsoft.EntityFrameworkCore;
using QLTHUVIEN.Models;

var builder = WebApplication.CreateBuilder(args);

// Đăng ký DbContext với MySQL
builder.Services.AddDbContext<QltvContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("qltvContext"),
    new MySqlServerVersion(new Version(8, 0, 21)))); // Thay phiên bản MySQL bằng phiên bản bạn đang sử dụng

// Add services to the container.
builder.Services.AddControllersWithViews();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Saches}/{action=Index}/{id?}");

app.Run();
