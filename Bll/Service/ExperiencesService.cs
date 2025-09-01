using BLL.Abstract;
using DAL.Abstract;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ExperiencesService : IExperiencesService
    {
        private readonly IExperiencesDal experiences;
        public ExperiencesService(IExperiencesDal experiencesss)
        {
            experiences = experiencesss;
        }

        public async Task CreateAsync(Experiences entity)
        {
            await experiences.CreateAsync(entity);
        }

        public async Task DeleteAsync(int Id)
        {
            await experiences.DeleteAsync(Id);
        }

        public async Task<List<Experiences>> GetAllAsync()
        {
            return await experiences.GetAllAsync();
        }

        public async Task<Experiences> GetAsync()
        {
            return await experiences.GetAsync();
        }

        public async Task<Experiences> GetByIdAsync(int id)
        {
            return await experiences.GetByIdAsync(id);
        }

        public async Task UpdateAsync()
        {
            await experiences.UpdateAsync();
        }
    }
}
