using Core.Domain.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
namespace Infrastructure.EntityConfiguration.MasterData
{
    class LeadSourceEntityTypeConfiguration : IEntityTypeConfiguration<LeadSource>
    {
        public void Configure(EntityTypeBuilder<LeadSource> entityConfiguration)
        {
            entityConfiguration.HasData(
            new LeadSource { LeadSourceId = 1, LeadSourceTitle = "Cold-Call",Description= "Cold-Call", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new LeadSource { LeadSourceId = 2, LeadSourceTitle = "Existing-Customer", Description = "Existing Customer", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new LeadSource { LeadSourceId = 3, LeadSourceTitle = "Self-Generated", Description = "Self Generated", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new LeadSource { LeadSourceId = 4, LeadSourceTitle = "Employee", Description = "Employee", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new LeadSource { LeadSourceId = 5, LeadSourceTitle = "Partner", Description = "Partner", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new LeadSource { LeadSourceId = 6, LeadSourceTitle = "Public-Relation", Description = "Public Relation", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new LeadSource { LeadSourceId = 7, LeadSourceTitle = "Direct-Mail", Description = "Direct Mail", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new LeadSource { LeadSourceId = 9, LeadSourceTitle = "Conference", Description = "Conference", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new LeadSource { LeadSourceId = 10, LeadSourceTitle = "Trade-Show", Description = "Trade Show", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new LeadSource { LeadSourceId = 11, LeadSourceTitle = "Website", Description = "Website", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new LeadSource { LeadSourceId = 12, LeadSourceTitle = "Word-of-Mouth", Description = "Word of Mouth", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new LeadSource { LeadSourceId = 13, LeadSourceTitle = "Email", Description = "Email", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new LeadSource { LeadSourceId = 14, LeadSourceTitle = "Campaign", Description = "Campaign", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false },
            new LeadSource { LeadSourceId = 15, LeadSourceTitle = "Other", Description = "Other", CreatedOn = DateTime.Now, CreatedById = 1, UpdatedOn = DateTime.Now, UpdatedById = 1, IsActive = true, IsDeleted = false }
            );
            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);
        }
    }
}
