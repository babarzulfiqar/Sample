using Core.Domain.MasterData;
using Core.Specifications.Parameters;

namespace Core.Specifications
{
    public class AccountWithFiltersForCountSpecification : BaseSpecification<Account>
    {
        public AccountWithFiltersForCountSpecification(AccountSpecParam accountParam)
            : base(i =>
                (string.IsNullOrEmpty(accountParam.Name) || i.Name.Contains(accountParam.Name))
         && (string.IsNullOrEmpty(accountParam.OfficePhone) || i.OfficePhone.Contains(accountParam.OfficePhone))
              && (string.IsNullOrEmpty(accountParam.Website) || i.Website.Contains(accountParam.Website)) &&
                (string.IsNullOrEmpty(accountParam.BillingCountry) || i.BillingCountry.Contains(accountParam.BillingCountry))
              && (string.IsNullOrEmpty(accountParam.ShippingCountry) || i.ShippingCountry.Contains(accountParam.ShippingCountry))
              && (string.IsNullOrEmpty(accountParam.BillingCity) || i.BillingCity.Contains(accountParam.BillingCity)) &&
              (string.IsNullOrEmpty(accountParam.ShippingCity) || i.ShippingCity.Contains(accountParam.ShippingCity))
              && (!accountParam.IsActive.HasValue || i.IsActive == accountParam.IsActive) && (i.IsDeleted == false)
              && (string.IsNullOrEmpty(accountParam.Search) || i.Name.Contains(accountParam.Search))
            )
        {

        }
    }
}
