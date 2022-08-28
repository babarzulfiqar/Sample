using Core.Domain.MasterData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.EntityConfiguration.MasterData
{
    class EmailAddressEntityTypeConfiguration : IEntityTypeConfiguration<EmailAddress>
    {
        public void Configure(EntityTypeBuilder<EmailAddress> entityConfiguration)
        {
            entityConfiguration.ToTable("EmailAddresses");
            entityConfiguration.HasKey(o => new { o.EmailAddressId });
            entityConfiguration.Property(o => o.EmailAddressId).ValueGeneratedOnAdd();
            entityConfiguration.Property(b => b.Email).HasColumnType("varchar(100)");

            entityConfiguration.Property(b => b.CreatedById).IsRequired(true);
            entityConfiguration.Property(b => b.CreatedOn).IsRequired(true);

            entityConfiguration.Property(b => b.UpdatedById).IsRequired(false);
            entityConfiguration.Property(b => b.UpdatedOn).IsRequired(false);

            entityConfiguration.HasOne(x => x.Account)
                .WithMany(x => x.EmailAddress)
                .HasForeignKey(x => new { x.AccountId })
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);

            entityConfiguration.HasOne(x => x.Contact)
                .WithMany(x => x.EmailAddress)
                .HasForeignKey(x => new { x.ContactId })
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Restrict);
            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);

        }
    }
}
