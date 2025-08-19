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
    public class EfCoreProfileDal:EfCoreGenericRepository<Profile,DataContext>,IProfileDal
    {
        private readonly DataContext _Context;
        public EfCoreProfileDal(DataContext context) : base(context)
        {
            _Context = context;
        }

        

    }
}
