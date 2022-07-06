using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models.Entities;

namespace Web.Models.Configurations
{
    public class CustomersConfiguration : BaseConfigurations<Customers>
    {
        public override void Configure(EntityTypeBuilder<Customers> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => p.CustomerId);
            builder.Property(p => p.CustomerId).UseIdentityColumn();
            //builder.HasMany(f => f.Orders).WithOne().HasForeignKey(p => p.CustomerId).OnDelete(DeleteBehavior.Cascade);
        }
}
}
