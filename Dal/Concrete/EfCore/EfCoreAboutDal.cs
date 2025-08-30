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
    public class EfCoreAboutDal : EfCoreGenericRepository<About, DataContext>,IAboutDal
    {

        private readonly DataContext _Context;
        public EfCoreAboutDal(DataContext context) : base(context)
        {
            _Context = context;
        }
    }
}

