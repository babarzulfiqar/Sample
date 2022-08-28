using Core.Domain.UserData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Infrastructure.EntityConfiguration.UserData
{
    class UserEntityTypeConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> entityConfiguration)
        {
            entityConfiguration.ToTable("Users");
            entityConfiguration.HasKey(o => new { o.UserId });
            entityConfiguration.Property(o => o.UserId).ValueGeneratedOnAdd();

            entityConfiguration.Property(b => b.CreatedById).IsRequired(true);
            entityConfiguration.Property(b => b.CreatedOn).IsRequired(true);

            entityConfiguration.Property(b => b.UpdatedById).IsRequired(false);
            entityConfiguration.Property(b => b.UpdatedOn).IsRequired(false);

            entityConfiguration.HasOne(x => x.CreatedBy)
                .WithMany(x => x.Users)
                .OnDelete(DeleteBehavior.NoAction);

            entityConfiguration.HasQueryFilter(x => x.IsDeleted == false);
            entityConfiguration.HasData
                (
                  new User { UserId = 1, Username = "admin", FullName = "Administrator", CreatedById = 1, CreatedOn = DateTime.UtcNow, IsActive = true, IsDeleted = false }
                );
        }
    }
}
