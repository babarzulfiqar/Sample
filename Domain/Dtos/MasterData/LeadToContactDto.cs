using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.MasterData
{
    public class LeadToContactDto
    {
        public int LeadId { get; set; }
        public int? PrefixTitleId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string AccountName { get; set; }
        public string OfficePhone { get; set; }
        public string Mobile { get; set; }
        public string Fax { get; set; }
        public string Website { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }

        public string Other_Address { get; set; }
        public string Other_City { get; set; }
        public string Other_State { get; set; }
        public string Other_PostalCode { get; set; }
        public string Other_Country { get; set; }
        public ICollection<EmailAddressDto> EmailAddress { get; set; } = new List<EmailAddressDto>(); // One-Many relation
        public string Description { get; set; }
        public int? LeadSourceId { get; set; }
        public string LeadSourceData { get; set; }
        public string LeadSourceDescription { get; set; } // This is different description than leadSource.description
        public string OpportunityAmount { get; set; }
        public string ReferredBy { get; set; }
        public int? AssignedToUserId { get; set; }

    }
}
