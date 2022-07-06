using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models.Entities;

namespace Web.Models.Configurations
{
    public class StaffsConfiguration : BaseConfigurations<Staffs>
    {
        public override void Configure(EntityTypeBuilder<Staffs> builder)
        {
            base.Configure(builder);
            builder.HasKey(p => new { p.StaffId });
        }
    }
}
