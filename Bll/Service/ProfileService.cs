using DAL.Concrete.EfCore;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ProfileService
    {
        private readonly EfCoreProfileDal profileDal;

        public ProfileService(EfCoreProfileDal profile)
        {
            profileDal = profile;
        }
        public Profile GetProfile()
        {
            return profileDal.GetProfile();
        }


    }
}
