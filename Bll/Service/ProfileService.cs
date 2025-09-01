using BLL.Abstract;
using DAL.Abstract;
using DAL.Concrete.EfCore;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ProfileService : IProfileService
    {
        private readonly IProfileDal _profildal;
        public ProfileService(IProfileDal profileDal)
        {
            _profildal = profileDal;
        }
        public async Task CreateAsync(Profile entity)
        {
            await _profildal.CreateAsync(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            await _profildal.DeleteAsync(Id);
        }

        public async Task<List<Profile>> GetAllAsync()
        {
            return await _profildal.GetAllAsync();
        }

        public async Task<Profile> GetAsync()
        {
            return await _profildal.GetAsync();
        }

        public async Task<Profile> GetByIdAsync(int Id)
        {
            return await _profildal.GetByIdAsync(Id);
        }

        public async Task UpdateAsync()
        {
            await _profildal.UpdateAsync();
        }
    }
}
