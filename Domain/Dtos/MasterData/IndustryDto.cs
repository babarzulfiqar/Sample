using Core.Dtos.Common;

namespace Core.Dtos.MasterData
{
    public class IndustryDto : AuditableDto
    {
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }

    }
}
