

using Core.Dtos.Common;

namespace Core.Dtos.MasterData
{
    public class PrefixTitleDto : AuditableDto
    {
        public int PrefixTitleId { get; set; }
        public string Title { get; set; }
    }
}
