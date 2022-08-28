using Core.Common;
using System.Collections.Generic;

namespace Core.Domain.MasterData
{
    //Pre-seed API - NO CRUD
    public class LeadSource : AuditableEntity
    {
        public int LeadSourceId { get; set; }
        public string LeadSourceTitle { get; set; }
        public string Description { get; set; }
        public ICollection<Lead> Leads { get; set; } = new List<Lead>();
    }
}
