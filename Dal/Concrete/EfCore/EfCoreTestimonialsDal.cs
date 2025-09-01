using DAL.Abstract;
using DAL.Concrete.Context;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EfCore
{
    public class EfCoreTestimonialsDal:EfCoreGenericRepository<Testimonials, DataContext>,ITestimonialsDal
    {
        private readonly DataContext dataContext;
        public EfCoreTestimonialsDal(DataContext context) : base(context)
        {
            dataContext = context;
        }
    }
}
