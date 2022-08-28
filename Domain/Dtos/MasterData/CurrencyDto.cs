using Core.Dtos.Common;

namespace Core.Dtos.MasterData
{
    public class CurrencyDto : AuditableDto
    {
        public int CurrencyId { get; set; }
        public string Name { get; set; }
        public string CurrencyCode { get; set; }
        public string Symbol { get; set; }
    }
}
