using CadFunc.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CadFunc.Infra.Configuration
{
    public class ContextBase : DbContext
    {
        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {
        }

        public DbSet<CadMedicos> CadMedicos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ContextBase).Assembly);
            base.OnModelCreating(modelBuilder);
        }

    }
}
