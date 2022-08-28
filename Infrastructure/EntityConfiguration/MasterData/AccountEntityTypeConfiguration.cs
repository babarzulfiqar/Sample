using Core.Domain.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration.MasterData
{
    class AccountEntityTypeConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> entityConfiguration)
        {
            entityConfiguration.ToTable("Accounts");
            entityConfiguration.HasKey(o => new { o.AccountId });
            entityConfiguration.Property(o => o.AccountId).ValueGeneratedOnAdd();
            entityConfiguration.Property(b => b.Name).HasColumnType("varchar(100)").IsRequired(true);
            entityConfiguration.Property(b => b.OfficePhone).HasColumnType("varchar(100)");
            entityConfiguration.Property(b => b.Website).HasColumnType("varchar(100)");
            entityConfiguration.Property(b => b.Fax).HasColumnType("varchar(100)");

            entityConfiguration.Property(b => b.BillingStreet).HasColumnType("varchar(150)");
            entityConfiguration.Property(b => b.BillingCity).HasColumnType("varchar(100)");
            entityConfiguration.Property(b => b.BillingState).HasColumnType("varchar(100)");
            entityConfiguration.Property(b => b.BillingPostalCode).HasColumnType("varchar(100)");
            entityConfiguration.Property(b => b.BillingCountry).HasColumnType("varchar(100)");

            entityConfiguration.Property(b => b.ShippingStreet).HasColumnType("varchar(150)");
            entityConfiguration.Property(b => b.ShippingCity).HasColumnType("varchar(100)");
            entityConfiguration.Property(b => b.ShippingState).HasColumnType("varchar(100)");
            entityConfiguration.Property(b => b.ShippingPostalCode).HasColumnType("varchar(100)");
            entityConfiguration.Property(b => b.ShippingCountry).HasColumnType("varchar(100)");

            entityConfiguration.Property(b => b.AnnualRevenue).HasColumnType("varchar(100)");
            entityConfiguration.Property(b => b.Description).HasColumnType("varchar(MAX)");

            entityConfiguration.Property(b => b.CreatedById).IsRequired(true);
            entityConfiguration.Property(b => b.CreatedOn).IsRequired(true);

            entityConfiguration.Property(b => b.UpdatedById).IsRequired(false);
            entityConfiguration.Property(b => b.UpdatedOn).IsRequired(false);

            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);

            entityConfiguration.HasOne(x => x.User)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x =>new { x.UserId })
                .IsRequired(true)
                .OnDelete(DeleteBehavior.Restrict);

            entityConfiguration.HasOne(x => x.AccountType)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => new { x.AccountTypeId })
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entityConfiguration.HasOne(x => x.Industry)
                .WithMany(x => x.Accounts)
                .HasForeignKey(x => new { x.IndustryId })
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entityConfiguration.HasOne(x => x.CreatedBy);
            entityConfiguration.HasOne(x => x.UpdateBy);
            
        }
    }
}
