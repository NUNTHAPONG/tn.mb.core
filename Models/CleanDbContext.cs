using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Web.Models
{
    public partial class CleanDbContext : DbContext
    {
        protected CleanDbContext(DbContextOptions options) : base(options)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }
        public CleanDbContext(DbContextOptions<CleanDbContext> options)
         : base(options)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.EntityTypes().Configure(e => e.Relational().TableName = e.ClrType.Name.ToLowercaseNamingConvention());
            modelBuilder.EntityTypes().Configure(e => e.SetTableName(e.ClrType.Name.ToLowercaseNamingConvention()));

            //modelBuilder.Properties().Where(p => p.Name != "RowVersion").Configure(p => p.Relational().ColumnName = p.Name.ToLowercaseNamingConvention());
            modelBuilder.Properties().Where(p => p.Name != "RowVersion").Configure(p => p.SetColumnName(p.Name.ToLowercaseNamingConvention()));
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CleanDbContext).Assembly);
        }
    }
}
