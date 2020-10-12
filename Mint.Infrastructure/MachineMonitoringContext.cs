using Microsoft.EntityFrameworkCore;
using Mint.Repository.Entities;
using System.Reflection;

namespace Mint.Repository.Data
{
    public class MachineMonitoringContext : DbContext
    {
        public MachineMonitoringContext(DbContextOptions<MachineMonitoringContext> options) : base(options)
        {

        }
        public DbSet<Machine> Machines { get; set; }
        public DbSet<MachineProduction> MachineProductions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
