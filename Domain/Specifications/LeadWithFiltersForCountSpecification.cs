using Core.Domain.MasterData;
using Core.Specifications.Parameters;
namespace Core.Specifications
{
    public class LeadWithFiltersForCountSpecification : BaseSpecification<Lead>
    {
        public LeadWithFiltersForCountSpecification(LeadSpecParam param) : base(i =>
                (string.IsNullOrEmpty(param.FirstName) || i.FirstName.Contains(param.FirstName))
         && (string.IsNullOrEmpty(param.LastName) || i.FirstName.Contains(param.LastName))
             && (string.IsNullOrEmpty(param.OfficePhone) || i.OfficePhone.Contains(param.OfficePhone))
             && (string.IsNullOrEmpty(param.Mobile) || i.Mobile.Contains(param.Mobile))
              && (string.IsNullOrEmpty(param.Country) || i.LastName.Contains(param.Country)) &&
                (string.IsNullOrEmpty(param.City) || i.Country.Contains(param.City))
              && (!param.IsActive.HasValue || i.IsActive == param.IsActive) && (i.IsDeleted == false)
              && (string.IsNullOrEmpty(param.Search) || i.FirstName.Contains(param.Search))
             )
        {

        }
    }
}
