using Core.Common;

namespace Core.Domain.MasterData
{
    public class Status:AuditableEntity
    {
        public int StatusId { get; set; }
        public string StatusTitle { get; set; }
        public string Description { get; set; }
    }
}
