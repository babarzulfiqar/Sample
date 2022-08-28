using Core.Domain.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration.MasterData
{
    class ContactEntityTypeConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> entityConfiguration)
        {
            entityConfiguration.ToTable("Contacts");
            entityConfiguration.HasKey(o => new { o.ContactId });
            entityConfiguration.Property(o => o.ContactId).ValueGeneratedOnAdd();
            entityConfiguration.Property(b => b.FirstName).HasColumnType("varchar(100)").IsRequired(true);
            entityConfiguration.Property(b => b.OfficePhone).HasColumnType("varchar(100)");
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

            entityConfiguration.Property(b => b.Description).HasColumnType("varchar(MAX)");

            entityConfiguration.Property(b => b.CreatedById).IsRequired(true);
            entityConfiguration.Property(b => b.CreatedOn).IsRequired(true);

            entityConfiguration.Property(b => b.UpdatedById).IsRequired(false);
            entityConfiguration.Property(b => b.UpdatedOn).IsRequired(false);

            entityConfiguration.HasOne(x => x.Account)
                .WithMany(x => x.Contacts)
                .HasForeignKey(x => new { x.AccountId })
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);


        }
    }
}
