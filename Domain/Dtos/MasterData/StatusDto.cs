
using Core.Dtos.Common;

namespace Core.Dtos.MasterData
{
    public class StatusDto : AuditableDto
    {
        public int StatusId { get; set; }
        public string StatusTitle { get; set; }
        public string Description { get; set; }

    }
}
