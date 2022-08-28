using Core.Common;
using Core.Domain.UserData;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.MasterData
{
    public class Lead : AuditableEntity
    {
        public int LeadId { get; set; }
        public int? PrefixTitleId { get; set; }
        public PrefixTitle PrefixTitle { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficePhone { get; set; }
        public string Mobile { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string AccountName { get; set; }
        
        
        public string Fax { get; set; }
        public string Website { get; set; }
       
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }

        
        public string Other_City { get; set; }
        public string Other_State { get; set; }
        public string Other_PostalCode { get; set; }
        public string Other_Country { get; set; }
        public string Other_Address { get; set; }

        public ICollection<EmailAddress> EmailAddress { get; set; } = new List<EmailAddress>(); // One-Many relation
        public string Description { get; set; }
        public int? StatusId { get; set; }
        public Status Status { get; set; }
        public string StatusDescription { get; set; }
        public int? LeadSourceId { get; set; }
        public LeadSource LeadSource { get; set; }
        public string LeadSourceDescription { get; set; }
        public string OpportunityAmount { get; set; }
        public string ReferredBy { get; set; }
        public int? AssignedToUserId { get; set; }
        public User AssignedToUser { get; set; }
        /// <summary>
        ///Only use Converted to Contact and Converted to Oppertunity for conversion purposes, do not allow in rest of CRUD.
        /// </summary>

        [DefaultValue(false)]
        public bool ConvertedToContact { get; set; }
        [DefaultValue(false)]
        public bool ConvertedToOpportunity { get; set; }

        //This is collection will be used to fetch, how many oppertunities are created with this lead
        public ICollection<Opportunity> Oppertunities { get; set; } = new List<Opportunity>();
    }
}
