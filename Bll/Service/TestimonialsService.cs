using BLL.Abstract;
using DAL.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class TestimonialsService : ITestimonialsService
    {
        private readonly ITestimonialsDal testimonials;
        public TestimonialsService(ITestimonialsDal testimonialsDal)
        {
            testimonials = testimonialsDal;
        }

        public async Task CreateAsync(Testimonials entity)
        {
            await testimonials.CreateAsync(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            await testimonials.DeleteAsync(Id);
        }

        public async Task<List<Testimonials>> GetAllAsync()
        {
          return await testimonials.GetAllAsync();
        }

        public async Task<Testimonials> GetAsync()
        {
            return await testimonials.GetAsync();
        }

        public async Task<Testimonials> GetByIdAsync(int Id)
        {
            return await testimonials.GetByIdAsync(Id);
        }

        public async Task UpdateAsync()
        {
            await testimonials.UpdateAsync();
        }
    }
}
