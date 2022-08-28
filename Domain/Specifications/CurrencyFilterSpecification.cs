using Core.Domain.MasterData;

namespace Core.Specifications
{
    public class CurrencyFilterSpecification : BaseSpecification<Currency>
    {
        public CurrencyFilterSpecification(string CurrencyCode, string Name, bool? isActive)
            : base(i =>
                 (string.IsNullOrEmpty(CurrencyCode) || i.CurrencyCode.ToLower().Trim() == CurrencyCode.ToLower().Trim())
            && (string.IsNullOrEmpty(Name) || i.Name.ToLower().Trim() == Name.ToLower().Trim())
           && (!isActive.HasValue || i.IsActive == isActive) && (i.IsDeleted == false)
            )
        {
            AddOrderBy(x => x.Name);
        }
    }
}
