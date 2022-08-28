using Core.Domain.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.EntityConfiguration.MasterData
{
    class SaleStageEntityTypeConfiguration : IEntityTypeConfiguration<SaleStage>
    {
        public void Configure(EntityTypeBuilder<SaleStage> entityConfiguration)
        {
        entityConfiguration.HasData(
        new SaleStage { SaleStageId = 1, SaleStageTitle = "Prospecting",Description= "Prospecting", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new SaleStage { SaleStageId = 2, SaleStageTitle = "Qualification",Description= "Qualification", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new SaleStage { SaleStageId = 3, SaleStageTitle = "Needs-Analysis",Description= "Needs Analysis", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new SaleStage { SaleStageId = 4, SaleStageTitle = "Value-Proposition",Description= "Value Proposition", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new SaleStage { SaleStageId = 5, SaleStageTitle = "Identifying-Decision-Makers",Description= "Identifying Decision Makers", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new SaleStage { SaleStageId = 6, SaleStageTitle = "Perception-Analysis",Description= "Perception Analysis", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new SaleStage { SaleStageId = 7, SaleStageTitle = "Proposal-Price-Quote", Description = "Proposal/Price Quote", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new SaleStage { SaleStageId = 8, SaleStageTitle = "Negotiation-Review", Description = "Negotiation Review", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new SaleStage { SaleStageId = 9, SaleStageTitle = "Closed-Won", Description = "Closed Won", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
        new SaleStage { SaleStageId = 10, SaleStageTitle = "Closed-Lost", Description = "Closed Lost", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false }
        );
            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
