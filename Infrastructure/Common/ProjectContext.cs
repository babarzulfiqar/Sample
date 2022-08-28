using Microsoft.EntityFrameworkCore;
using Core.Common;
using Core.Domain.MasterData;
using Infrastructure.EntityConfiguration;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Core.Domain.UserData;
using Infrastructure.EntityConfiguration.MasterData;
using Infrastructure.EntityConfiguration.UserData;

namespace Infrastructure.Common
{
    public class ProjectContext : DbContext
    {
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }
        public DbSet<EmailAddress> EmailAddresses { get; set; }
        public DbSet<Industry> Industries { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<LeadSource> LeadSources { get; set; }
        public DbSet<PrefixTitle> PrefixTitles { get; set; }
        public DbSet<Lead> Leads { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<SaleStage> SaleStages { get; set; }
        public DbSet<BusinessType> BusinessTypes { get; set; }
        public DbSet<Opportunity> Opportunities { get; set; }

        public ProjectContext(DbContextOptions<ProjectContext> options)
         : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CurrencyEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AccountTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new EmailAddressEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new ContactEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new PrefixTitleEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LeadSourceEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new LeadEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new StatusEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new SaleStageEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessTypeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new OpportunityEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new IndustryEntityTypeConfiguration());
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            // get added or updated entries ///   "
            var addedOrUpdatedEntries = ChangeTracker.Entries()
                    .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified));
            int dd = addedOrUpdatedEntries.Count();
            // fill out the audit fields
            foreach (var entry in addedOrUpdatedEntries)
            {
                var entity = entry.Entity as AuditableEntity;
                try
                {
                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedOn = DateTime.UtcNow;
                        entity.CreatedById = 1;
                        entry.CurrentValues["IsDeleted"] = false;
                    }
                    if (entry.State == EntityState.Modified)
                    {
                        entity.UpdatedById = 1;
                        entity.UpdatedOn = DateTime.UtcNow;
                    }
                }
                catch (Exception)
                {
                    return base.SaveChangesAsync(cancellationToken);
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;

            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(entity, validationContext);
            }
            return base.SaveChanges();
        }
    }
}
