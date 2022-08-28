using Core.Dtos.Common;

namespace Core.Dtos.MasterData
{
    public class SaleStageDto : AuditableDto
    {
        public int SaleStageId { get; set; }
        public string SaleStageTitle { get; set; }
        public string Description { get; set; }
    }
}
