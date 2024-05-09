using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class ErrorLogDatbaseContext : DbContext
    {
        private static bool _isConfigured = false;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
                optionsBuilder.UseNpgsql("Host=localhost;Database=ErrorLogDatabase;Username=postgres;Password=123456");
            
        }
        public DbSet<Datas> Datas { get; set; }
        public DbSet<Errors> Errors { get; set; }
        
    }
}
