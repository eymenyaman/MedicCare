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
        private readonly ProfileDal profileDal;

        public ProfileService(ProfileDal profile)
        {
            profileDal = profile;
        }
        public Profile GetProfile()
        {
            return profileDal.GetProfile();
        }


    }
}
