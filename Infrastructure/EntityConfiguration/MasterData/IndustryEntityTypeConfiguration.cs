using Core.Domain.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration.MasterData
{
    class IndustryEntityTypeConfiguration : IEntityTypeConfiguration<Industry>
    {
        public void Configure(EntityTypeBuilder<Industry> entityConfiguration)
        {
            entityConfiguration.HasIndex(x => x.IndustryName).IsUnique().HasFilter("isDeleted=0");
            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
