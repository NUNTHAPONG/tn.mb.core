using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models.Configurations;
using Web.Models.Entities;

namespace Web.Models
{
    public class BrandsConfiguration : BaseConfigurations<Brands>
    {
        public override void Configure(EntityTypeBuilder<Brands> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => new { p.BrandId });
        }
}
}
