using Core.Domain.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.EntityConfiguration.MasterData
{
    class StatusEntityTypeConfiguration : IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> entityConfiguration)
        {
        entityConfiguration.HasData(
        new Status { StatusId = 1, StatusTitle = "New",Description= "New", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new Status { StatusId = 2, StatusTitle = "Assigned", Description = "Assigned", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new Status { StatusId = 3, StatusTitle = "In-Process", Description = "In Process", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new Status { StatusId = 4, StatusTitle = "Converted", Description = "Converted", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new Status { StatusId = 5, StatusTitle = "Recycled", Description = "Recycled", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new Status { StatusId = 6, StatusTitle = "Dead", Description = "Dead", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false }        
        );
            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
