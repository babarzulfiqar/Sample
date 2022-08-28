using Core.Dtos.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.MasterData
{
    public class AccountDto:AuditableDto
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

        public int AssignedToUserId { get; set; }
        public string AssignedToUsername { get; set; }
        public string AssignedToFullName { get; set; }

        public int? AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }
        public int? IndustryId { get; set; }
        public string IndustryName { get; set; }
        public string AnnualRevenue { get; set; }
        public ICollection<EmailAddressDto> EmailAddress { get; set; } = new List<EmailAddressDto>();
        public ICollection<ContactDto> Contacts { get; set; } = new List<ContactDto>();

    }
}
