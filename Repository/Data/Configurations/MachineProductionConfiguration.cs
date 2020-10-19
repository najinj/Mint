using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Repository.Entities;

namespace Repository.Data.Configurations
{
    public class MachineProductionConfiguration : IEntityTypeConfiguration<MachineProduction>
    {
        public void Configure(EntityTypeBuilder<MachineProduction> builder)
        {
            builder.Property(p => p.TotalProduction).HasDefaultValue(0);
            //builder.HasOne(m => m.Machine).WithMany().HasForeignKey(p => p.MachineId);
        }
    }
}
