using Core.Common;
using Core.Domain.UserData;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Domain.MasterData
{
    [Table("Opportunities")]
    public class Opportunity : AuditableEntity
    {
        public int OpportunityId { get; set; }
        [Required]
        public string OpportunityName { get; set; }
        public int? CurrencyId { get; set; }
        public Currency Currency { get; set; }
        [Required]
        public decimal OpportunityAmount { get; set; }
        public int? SaleStageId { get; set; }
        public SaleStage SaleStage { get; set; }
        /// <summary>
        /// In Percentage
        /// </summary>
        public decimal Probability { get; set; }
        public string NextStep { get; set; }
        public int? AccountId { get; set; }
        public Account Account { get; set; }
        public DateTime ExpectedCloseDate { get; set; }
        //Not Required
        public int? BusinessTypeId { get; set; }
        public BusinessType BusinessType { get; set; }

        public int? LeadSourceId { get; set; }
        public LeadSource LeadSource { get; set; }
        public string Description { get; set; }
        public int? AssignedToUserId { get; set; }
        public User AssignedToUser { get; set; }

        //this will be used to indicate that this opportunity is converted FROM lead and which lead
        public int? ConvertedFromLeadId { get; set; }
        public Lead ConvertedFromLead { get; set; }
    }
}
