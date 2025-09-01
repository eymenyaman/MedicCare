using DAL.Abstract;
using DAL.Concrete.Context;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EfCore
{
    public class EfCoreContactDal:EfCoreGenericRepository<Contact, DataContext>,IContactDal
    {
        private readonly DataContext _Context;
        public EfCoreContactDal(DataContext context) : base(context)
        {
            _Context = context;
        }
    }
}
