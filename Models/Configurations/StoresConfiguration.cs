using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models.Entities;

namespace Web.Models.Configurations
{
    public class StoresConfiguration : BaseConfigurations<Stores>
    {
        public override void Configure(EntityTypeBuilder<Stores> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => new { p.StoreId });
            builder.Property(p => p.StoreId).UseIdentityColumn();
        }
}
}
