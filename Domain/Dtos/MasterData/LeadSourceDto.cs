namespace Core.Dtos.MasterData
{
    public class LeadSourceDto : Common.AuditableDto
    {
        public int LeadSourceId { get; set; }
        public string LeadSourceTitle { get; set; }
        public string Description { get; set; }
    }
}
