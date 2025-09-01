using BLL.Abstract;
using BLL.Service;
using DAL.Abstract;
using DAL.Concrete.Context;
using DAL.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

namespace WebUI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddHttpClient();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("EfCoreConnection"),
                    b => b.MigrationsAssembly("DAL")
                );
            });

            // Servisler
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IProfileDal, EfCoreProfileDal>();

            var app = builder.Build();

            // Hata yakalama ve güvenlik ayarları
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            // Varsayılan route
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Admin}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
