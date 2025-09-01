using BLL.Abstract;
using DAL.Abstract;
using Entity;
using Entity.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class AboutService : IAboutService
    {
        private readonly IAboutDal _aboutDal;
        public AboutService(IAboutDal aboutdal)
        {
            _aboutDal = aboutdal;
        }

        public async Task CreateAsync(About entity)
        {
            await _aboutDal.CreateAsync(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            await _aboutDal.DeleteAsync(Id);
        }

        public Task<List<About>> GetAllAsync()
        {
            return _aboutDal.GetAllAsync();
        }

        public async Task<About> GetAsync()
        {
            return await _aboutDal.GetAsync();
        }

        public async Task<About> GetByIdAsync(int Id)
        {
            return await _aboutDal.GetByIdAsync(Id);
        }

        public async Task UpdateAsync()
        {
            await _aboutDal.UpdateAsync();
        }

      
    }
}
