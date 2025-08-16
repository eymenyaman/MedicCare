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
    public class EfCoreProfileDal
    {
        private readonly DataContext _Context;
        public EfCoreProfileDal(DataContext context)
        {
            _Context = context;
        }

        public Profile GetProfile()
        {
            return _Context.Profiles.FirstOrDefault();
        }

    }
}
