using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models.Entites;

namespace Web.Models.Configurations
{
    public class OrderItemsConfiguration : BaseConfigurations<OrderItem>
    {
        public override void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => new { p.ItemId });
        }
}
}
