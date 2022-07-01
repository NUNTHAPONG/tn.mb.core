using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models.Entites;

namespace Web.Models.Configurations
{
    public class CategoriesConfiguration : BaseConfigurations<Categories>
    {
        public override void Configure(EntityTypeBuilder<Categories> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => new { p.CategoryId });
        }
}
}
