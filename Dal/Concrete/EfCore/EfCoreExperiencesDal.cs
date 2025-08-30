using DAL.Abstract;
using DAL.Concrete.Context;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EfCore
{
    public class EfCoreExperiencesDal : EfCoreGenericRepository<Experiences, DataContext>, IExperiencesDal
    {
        private readonly DataContext _Context;
        public EfCoreExperiencesDal(DataContext context) : base(context)
        {
            _Context = context;
        }
      
    }
}