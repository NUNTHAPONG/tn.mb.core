using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Models.Entities;

namespace Web.Models.Configurations
{
    public class BaseConfigurations<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : EntityBase
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.Ignore(e => e.RowState);
            builder.Property(e => e.RowVersion).HasColumnName("xmin").HasColumnType("xid").ValueGeneratedOnAddOrUpdate().IsConcurrencyToken();

        }
    }
}
