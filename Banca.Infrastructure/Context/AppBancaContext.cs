using Banca.Infrastructure.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Banca.Infrastructure.Context
{
    public class AppBancaContext : DbContext
    {
        public AppBancaContext(DbContextOptions<AppBancaContext> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Deposito> Depositos { get; set; } 
    }
}
