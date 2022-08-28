using Core.Dtos.Common;

namespace Core.Dtos.MasterData
{
    public class BusinessTypeDto : AuditableDto
    {
        public int BusinessTypeId { get; set; }
        public string BusinessTypeTitle { get; set; }
        public string Description { get; set; }
    }
}
