using Core.Common;
using Core.Domain.UserData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.MasterData
{
    public class Account : AuditableEntity
    {
        public int AccountId { get; set; }
        [Required]
        public string Name { get; set; }
        public string OfficePhone { get; set; }
        public string Website { get; set; }
        public string Fax { get; set; }
        #region BillingAddress
        public string BillingStreet { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingCountry { get; set; }
        #endregion

        #region ShippingAddress
        public string ShippingStreet { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingCountry { get; set; }
        #endregion

        public string Description { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
        public int? AccountTypeId { get; set; }
        public AccountType AccountType { get; set; }
        public int? IndustryId { get; set; }
        public Industry Industry { get; set; }
        public string AnnualRevenue { get; set; }

        public ICollection<EmailAddress> EmailAddress { get; set; } = new List<EmailAddress>(); // One-Many relation
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>(); // One-Many relation
    }
}
