using Core.Dtos.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.MasterData
{
    public class OpportunityDto : AuditableDto
    {
        public int OpportunityId { get; set; }
        [Required]
        public string OpportunityName { get; set; }
        public int? CurrencyId { get; set; }
        public string CurrencyName { get; set; }
        public string CurrencyCode { get; set; }
        public string Symbol { get; set; }
        [Required]
        public decimal OpportunityAmount { get; set; }
        //Required
        public int SaleStageId { get; set; }
        public string SaleStageDescription { get; set; }
        /// <summary>
        /// In Percentage
        /// </summary>
        public decimal Probability { get; set; }
        public string NextStep { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        public int? BusinessTypeId { get; set; }
        public string BusinessTypeDescription { get; set; }

        public int? LeadSourceId { get; set; }
        public string LeadSourceDescription { get; set; }
        public string Description { get; set; }

        public int? AssignedToUserId { get; set; }
        public string AssignedToUsername { get; set; }
        public string AssignedToFullName { get; set; }

        //this will be used to indicate that this opportunity is converted FROM lead and which lead
        public int? ConvertedFromLeadId { get; set; }
        public LeadDto ConvertedFromLead { get; set; }
    }
}
