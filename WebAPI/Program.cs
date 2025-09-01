
using BLL.Abstract;
using BLL.Service;
using DAL.Abstract;
using DAL.Concrete.Context;
using DAL.Concrete.EfCore;
using Microsoft.EntityFrameworkCore;

namespace WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.  

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle  
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("EfCoreConnection"));
            });
            //Servisler  
            builder.Services.AddScoped<IProfileService, ProfileService>();
            builder.Services.AddScoped<IProfileDal, EfCoreProfileDal>();
            builder.Services.AddScoped<IAboutService, AboutService>();
            builder.Services.AddScoped<IAboutDal, EfCoreAboutDal>();
            builder.Services.AddScoped<IExperiencesService, ExperiencesService>();
            builder.Services.AddScoped<IExperiencesDal, EfCoreExperiencesDal>();
            builder.Services.AddScoped<ITestimonialsService, TestimonialsService>();
            builder.Services.AddScoped<ITestimonialsDal, EfCoreTestimonialsDal>();
            builder.Services.AddScoped<IContactService, ContactService>();
            builder.Services.AddScoped<IContactDal, EfCoreContactDal>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.  
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
