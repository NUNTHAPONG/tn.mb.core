using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models.Entites;

namespace Web.Models.Configurations
{
    public class ProductsConfiguration : BaseConfigurations<Products>
    {
        public override void Configure(EntityTypeBuilder<Products> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => new { p.ProductId });
            builder.HasOne(f => f.Brands).WithMany().HasForeignKey(p => p.BrandId).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(f => f.Categories).WithMany().HasForeignKey(p => p.CategoryId).OnDelete(DeleteBehavior.Cascade);
        }
}
}
