using BLL.Abstract;
using DAL.Abstract;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class ContactService : IContactService
    {
        private readonly IContactDal contactDall;
        public ContactService(IContactDal contactDal)
        {
            contactDall = contactDal;
        }
        public async Task CreateAsync(Contact entity)
        {
           await contactDall.CreateAsync(entity);
        }
        public async Task DeleteAsync(int Id)
        {
            await contactDall.DeleteAsync(Id);
        }

        public async Task<List<Contact>> GetAllAsync()
        {
            return await contactDall.GetAllAsync();
        }

        public async Task<Contact> GetAsync()
        {
           return await contactDall.GetAsync();
        }

        public async Task<Contact> GetByIdAsync(int Id)
        {
            return await contactDall.GetByIdAsync(Id);
        }

        public async Task UpdateAsync()
        { 
           await contactDall.UpdateAsync();
        }
    }
}
