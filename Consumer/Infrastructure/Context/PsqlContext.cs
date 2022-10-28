using Consumer.Infrastructure.Model;
using Consumer.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Configuration;

namespace Consumer.Infrastructure.Context
{
    public class PsqlContext : DbContext
    {
        public DbSet<Product> Products { get; set; } = null!;
         
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            => optionsBuilder.UseNpgsql(Configuration.ConnectionString);
    }
}
