using Core.Common;

namespace Core.Domain.MasterData
{
    public class BusinessType : AuditableEntity
    {
        public int BusinessTypeId { get; set; }
        public string BusinessTypeTitle { get; set; }
        public string Description { get; set; }
    }
}
