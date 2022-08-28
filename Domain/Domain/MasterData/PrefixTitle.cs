using Core.Common;

namespace Core.Domain.MasterData
{
    //Pre-seed API - NO CRUD
    public class PrefixTitle: AuditableEntity
    {
        public int PrefixTitleId { get; set; }
        public string Title { get; set; }        
    }
}
