using DAL.Concrete.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.EfCore
{
    public class EfCoreGenericRepository<T, TContext>
        where T : class
        where TContext : DbContext
    {
        private readonly DataContext _context;
        public EfCoreGenericRepository(DataContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var profile = await _context.Set<T>().FindAsync(id);
            if (profile != null)
            {
                _context.Set<T>().Remove(profile);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<T> GetAsync()
        {
            return await _context.Set<T>().FirstOrDefaultAsync();
        }

    }
}
