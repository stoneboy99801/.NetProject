using Microsoft.EntityFrameworkCore;
using Template_Integration.Models;

namespace Template_Integration.Conection
{
    public class App : DbContext
    { 
        public App(DbContextOptions<App> options) : base(options)
        {
        }
        public DbSet<Contact> ContactForm { get; set; }
        public DbSet<Register> RegisterForm { get; set; }
        public DbSet<Product> AddProducts { get; set; }
        
    }
}
