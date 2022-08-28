using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Domain.MasterData;

namespace Infrastructure.EntityConfiguration
{
    class CurrencyEntityTypeConfiguration : IEntityTypeConfiguration<Currency>
    {
        public void Configure(EntityTypeBuilder<Currency> entityConfiguration)
        {
            entityConfiguration.ToTable("Currencies");
            entityConfiguration.HasKey(o => new { o.CurrencyId });
            entityConfiguration.Property(o => o.CurrencyId).ValueGeneratedOnAdd();
            entityConfiguration.Property(b => b.Name).HasColumnType("varchar(100)").IsRequired(true);
            entityConfiguration.Property(b => b.CurrencyCode).HasColumnType("varchar(10)").IsRequired(true);
            entityConfiguration.HasIndex(x => x.CurrencyCode).IsUnique();

            entityConfiguration.Property(b => b.CreatedById).IsRequired(true);
            entityConfiguration.Property(b => b.UpdatedById).IsRequired(false);
            entityConfiguration.Property(b => b.UpdatedOn).IsRequired(false);
            entityConfiguration.Property(b => b.CreatedOn).IsRequired(true);
            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
