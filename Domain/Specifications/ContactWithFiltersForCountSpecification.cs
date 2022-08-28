using Core.Domain.MasterData;
using Core.Specifications.Parameters;

namespace Core.Specifications
{
    public class ContactWithFiltersForCountSpecification : BaseSpecification<Contact>
    {
        public ContactWithFiltersForCountSpecification(ContactSpecParam param) : base(i =>
               (string.IsNullOrEmpty(param.FirstName) || i.FirstName.Contains(param.FirstName))
        && (string.IsNullOrEmpty(param.LastName) || i.FirstName.Contains(param.LastName))
            && (string.IsNullOrEmpty(param.OfficePhone) || i.OfficePhone.Contains(param.OfficePhone))
            && (string.IsNullOrEmpty(param.Mobile) || i.Mobile.Contains(param.Mobile))
            && (string.IsNullOrEmpty(param.BillingCountry) || i.BillingCountry.Contains(param.BillingCountry))
             && (string.IsNullOrEmpty(param.ShippingCountry) || i.ShippingCountry.Contains(param.ShippingCountry))
             && (string.IsNullOrEmpty(param.BillingCity) || i.BillingCity.Contains(param.BillingCity)) &&
             (string.IsNullOrEmpty(param.ShippingCity) || i.ShippingCity.Contains(param.ShippingCity))
             && (!param.IsActive.HasValue || i.IsActive == param.IsActive) && (i.IsDeleted == false)
              && (string.IsNullOrEmpty(param.Search) || i.FirstName.Contains(param.Search))
            )
        {

        }
    }
}
