using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models.Entities;

namespace Web.Models.Configurations
{
    public class OrdersConfiguration : BaseConfigurations<Orders>
    {
        public override void Configure(EntityTypeBuilder<Orders> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => p.OrderId);
        }
}
}
