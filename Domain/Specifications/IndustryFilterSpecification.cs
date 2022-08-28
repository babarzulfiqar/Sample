using Core.Domain.MasterData;

namespace Core.Specifications
{
    public class IndustryFilterSpecification : BaseSpecification<Industry>
    {
        public IndustryFilterSpecification(string industryName, bool? isActive) : base(i =>
                 (string.IsNullOrEmpty(industryName) || i.IndustryName.ToLower().Trim() == industryName.ToLower().Trim())
          && (!isActive.HasValue || i.IsActive == isActive) && (i.IsDeleted == false))
        {
            AddOrderBy(x => x.IndustryName);
        }
    }
}
