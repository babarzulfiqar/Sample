using Core.Domain.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration.MasterData
{
    class AccountTypeEntityTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> entityConfiguration)
        {
            entityConfiguration.HasIndex(x => x.AccountTypeName).IsUnique().HasFilter("isDeleted=0");
            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
