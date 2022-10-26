using CQRS.Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace CQRS.Infrastructure.Context
{
    public class PsqlContext : DbContext
    {
        protected readonly IConfiguration configuration;
        
        public PsqlContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Product> Products { get; set; } = null!;
    }
}
