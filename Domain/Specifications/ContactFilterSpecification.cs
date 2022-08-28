using Core.Domain.MasterData;
using Core.Specifications.Parameters;

namespace Core.Specifications
{
    public class ContactFilterSpecification : BaseSpecification<Contact>
    {
        public ContactFilterSpecification(ContactSpecParam param) : base(i =>
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
            AddInclude(x => x.PrefixTitle);
            AddInclude(x => x.Account);
            AddInclude(x => x.AssignedToUser);
            AddInclude(x => x.LeadSource);
            AddInclude(x => x.EmailAddress);
            AddOrderBy(x => x.FirstName);
            if (param.PageIndex > 0 || param.PageSize > 0)
            {
                ApplyPaging(param.PageSize * (param.PageIndex - 1), param.PageSize);
            }
            if (!string.IsNullOrEmpty(param.Sort))
            {
                switch (param.Sort)
                {
                    case "firstName_desc":
                        AddOrderByDescending(x => x.FirstName);
                        break;
                    case "firstName_asc":
                        AddOrderBy(x => x.FirstName);
                        break;
                    case "lastName_desc":
                        AddOrderByDescending(x => x.LastName);
                        break;
                    case "lastName_asc":
                        AddOrderBy(x => x.LastName);
                        break;
                    case "OfficePhone_desc":
                        AddOrderByDescending(x => x.OfficePhone);
                        break;
                    case "OfficePhone_asc":
                        AddOrderBy(x => x.OfficePhone);
                        break;
                    case "mobile_desc":
                        AddOrderByDescending(x => x.Mobile);
                        break;
                    case "mobile_asc":
                        AddOrderBy(x => x.Mobile);
                        break;
                    case "billingCountry_desc":
                        AddOrderByDescending(x => x.BillingCountry);
                        break;
                    case "billingCountry_asc":
                        AddOrderBy(x => x.BillingCountry);
                        break;
                    case "ShippingCountry_desc":
                        AddOrderByDescending(x => x.ShippingCountry);
                        break;
                    case "ShippingCountry_asc":
                        AddOrderBy(x => x.ShippingCountry);
                        break;
                    case "billingCity_desc":
                        AddOrderByDescending(x => x.BillingCity);
                        break;
                    case "billingCity_asc":
                        AddOrderBy(x => x.BillingCity);
                        break;
                    case "shippingCity_desc":
                        AddOrderByDescending(x => x.ShippingCity);
                        break;
                    case "shippingCity_asc":
                        AddOrderBy(x => x.ShippingCity);
                        break;
                    case "isActive_desc":
                        AddOrderByDescending(x => x.IsActive);
                        break;
                    case "isActive_asc":
                        AddOrderBy(x => x.IsActive);
                        break;
                }
            }
        }

        public ContactFilterSpecification(int id) : base(x => x.ContactId == id)
        {
            AddInclude(x => x.PrefixTitle);
            AddInclude(x => x.Account);
            AddInclude(x => x.EmailAddress);
            AddInclude(x => x.AssignedToUser);
            AddInclude(x=>x.LeadSource);
        }
    }
}
