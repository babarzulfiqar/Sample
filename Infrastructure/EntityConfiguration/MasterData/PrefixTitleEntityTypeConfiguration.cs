using Core.Domain.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.EntityConfiguration.MasterData
{
    class PrefixTitleEntityTypeConfiguration : IEntityTypeConfiguration<PrefixTitle>
    {
        public void Configure(EntityTypeBuilder<PrefixTitle> entityConfiguration)
        {
        entityConfiguration.HasData(
        new PrefixTitle { PrefixTitleId = 1, Title = "Mr.", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new PrefixTitle { PrefixTitleId = 2, Title = "Ms.", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new PrefixTitle { PrefixTitleId = 3, Title = "Mrs.", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new PrefixTitle { PrefixTitleId = 4, Title = "Miss", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new PrefixTitle { PrefixTitleId = 5, Title = "Dr.", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new PrefixTitle { PrefixTitleId = 6, Title = "Prof.", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new PrefixTitle { PrefixTitleId = 7, Title = "HH", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new PrefixTitle { PrefixTitleId = 8, Title = "Engr.", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false }
        );
            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
