using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mint.Repository.Entities;

namespace Mint.Repository.Data.Configurations
{
    public class MachineConfiguration : IEntityTypeConfiguration<Machine>
    {
        public void Configure(EntityTypeBuilder<Machine> builder)
        {
            builder.Property(p => p.Name).IsRequired().HasColumnType("varchar(50)");
            builder.Property(p => p.Description).HasColumnType("varchar(250)");
        }
    }
}
