using Core.Domain.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration.MasterData
{
    class OpportunityEntityTypeConfiguration : IEntityTypeConfiguration<Opportunity>
    {
        public void Configure(EntityTypeBuilder<Opportunity> entityConfiguration)
        {
            entityConfiguration.ToTable("Opportunities");

            entityConfiguration.HasOne(x => x.SaleStage)
                .WithMany(x => x.Opportunities)
                .HasForeignKey(x => new { x.SaleStageId })
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entityConfiguration.HasOne(x => x.CreatedBy);
            entityConfiguration.HasOne(x => x.UpdateBy);
            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);

            entityConfiguration.HasOne(x => x.ConvertedFromLead)
                .WithMany(x => x.Oppertunities)
                .HasForeignKey(x => new { x.ConvertedFromLeadId })
                .OnDelete(DeleteBehavior.SetNull)
                .IsRequired(false);
        }
    }
}
