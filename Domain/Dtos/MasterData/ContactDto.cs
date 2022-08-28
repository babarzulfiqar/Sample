using Core.Dtos.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.MasterData
{
    public class ContactDto : AuditableDto
    {
        public int ContactId { get; set; }
        public int? PrefixTitleId { get; set; }
        public string PrefixTitleName { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficePhone { get; set; }
        public string Mobile { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public int? AccountId { get; set; }
        public string AccountName { get; set; }
        public string Fax { get; set; }
        public ICollection<EmailAddressDto> EmailAddress { get; set; } = new List<EmailAddressDto>(); // One-Many relation
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

        public int? AssignedToUserId { get; set; }
        public string AssignedToUsername { get; set; }
        public string AssignedToFullName { get; set; }

        public int? LeadSourceId { get; set; }
        public string LeadSourceDescription { get; set; }

        //This will be used to indicate if a contact is created from a LEAD
        public int? ConvertedFromLeadId { get; set; }
        public LeadDto ConvertedFromLead { get; set; }
    }
}
