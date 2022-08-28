using Core.Domain.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration.MasterData
{
    class LeadEntityTypeConfiguration : IEntityTypeConfiguration<Lead>
    {
        public void Configure(EntityTypeBuilder<Lead> entityConfiguration)
        {
            entityConfiguration.ToTable("Leads");
            entityConfiguration.HasKey(o => new { o.LeadId });
            entityConfiguration.Property(o => o.LeadId).ValueGeneratedOnAdd();
            entityConfiguration.Property(b => b.FirstName).HasColumnType("varchar(100)").IsRequired(true);
            entityConfiguration.Property(b => b.OfficePhone).HasColumnType("varchar(100)");
            entityConfiguration.Property(b => b.Fax).HasColumnType("varchar(100)");

            entityConfiguration.Property(b => b.Description).HasColumnType("varchar(MAX)");

            entityConfiguration.Property(b => b.CreatedById).IsRequired(true);
            entityConfiguration.Property(b => b.CreatedOn).IsRequired(true);

            entityConfiguration.Property(b => b.UpdatedById).IsRequired(false);
            entityConfiguration.Property(b => b.UpdatedOn).IsRequired(false);

            entityConfiguration.HasOne(x => x.LeadSource)
                .WithMany(x => x.Leads)
                .HasForeignKey(x => new { x.LeadSourceId })
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);

        }
    }
}
