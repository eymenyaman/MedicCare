using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete.Context
{
    public class DataContext : DbContext //MSSQL
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Experiences> Experiences { get; set; }
        public DbSet<Testimonials> Testimonials { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    } 
}
