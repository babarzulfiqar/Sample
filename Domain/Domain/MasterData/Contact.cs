
using Core.Common;
using Core.Domain.UserData;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.MasterData
{
    public class Contact : AuditableEntity
    {
        public int ContactId { get; set; }
        public int? PrefixTitleId { get; set; }
        public PrefixTitle PrefixTitle { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficePhone { get; set; }
        public string Mobile { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public int? AccountId { get; set; }
        public Account Account { get; set; }
        public string Fax { get; set; }
        public ICollection<EmailAddress> EmailAddress { get; set; } = new List<EmailAddress>(); // One-Many relation
        #region BillingAddress
        public string BillingStreet { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingPostalCode { get; set; }
        public string BillingCountry { get; set; }
        /// <summary>
        /// Optional
        /// </summary>
        public string BillingFullAddress { get; set; }
        #endregion

        #region ShippingAddress
        public string ShippingStreet { get; set; }
        public string ShippingCity { get; set; }
        public string ShippingState { get; set; }
        public string ShippingPostalCode { get; set; }
        public string ShippingCountry { get; set; }
        /// <summary>
        /// Optional
        /// </summary>
        public string ShippingFullAddress { get; set; }
        #endregion

        public string Description { get; set; }
        public int? AssignedToUserId { get; set; }
        public User AssignedToUser { get; set; }

        public int? LeadSourceId { get; set; }
        public LeadSource LeadSource { get; set; }

        //This will be used to indicate if a contact is created from a LEAD
        public int? ConvertedFromLeadId { get; set; }
        public Lead ConvertedFromLead { get; set; }
    }
}
