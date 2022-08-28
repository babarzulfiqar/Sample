using Core.Common;
using System.Collections;
using System.Collections.Generic;

namespace Core.Domain.MasterData
{
    public class SaleStage : AuditableEntity
    {
        public int SaleStageId { get; set; }
        public string SaleStageTitle { get; set; }
        public string Description { get; set; }
        public ICollection<Opportunity> Opportunities { get; set; } = new List<Opportunity>();
    }
}
