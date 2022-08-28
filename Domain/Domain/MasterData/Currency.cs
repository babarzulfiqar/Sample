using Core.Common;
namespace Core.Domain.MasterData
{
    public class Currency : AuditableEntity
    {
        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string Symbol { get; set; }
    }
}
