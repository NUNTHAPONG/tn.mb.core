using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models.Entites;

namespace Web.Models.Configurations
{
    public class StocksConfiguration : BaseConfigurations<Stocks>
    {
        public override void Configure(EntityTypeBuilder<Stocks> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => new { p.StoreId });
        }
    }
}
