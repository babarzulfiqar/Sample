using Core.Domain.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.EntityConfiguration.MasterData
{
    class BusinessTypeEntityTypeConfiguration : IEntityTypeConfiguration<BusinessType>
    {
        public void Configure(EntityTypeBuilder<BusinessType> entityConfiguration)
        {
            entityConfiguration.HasData(
            new BusinessType { BusinessTypeId = 1, BusinessTypeTitle = "Existing-Business", Description = "Existing Business", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new BusinessType { BusinessTypeId = 2, BusinessTypeTitle = "New-Business", Description = "New-Business", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false }
            );
            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
