using Core.Domain.MasterData;
using Core.Specifications.Parameters;

namespace Core.Specifications
{
    public class AccountFilterSpecification : BaseSpecification<Account>
    {
        public AccountFilterSpecification(AccountSpecParam accountParam) : base(i =>
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
            AddInclude(x => x.User);
            AddInclude(x => x.AccountType);
            AddInclude(x => x.Industry);
            AddInclude(x => x.EmailAddress);
            AddOrderBy(x => x.Name);
            if (accountParam.PageIndex > 0 || accountParam.PageSize > 0)
            {
                ApplyPaging(accountParam.PageSize * (accountParam.PageIndex - 1), accountParam.PageSize);
            }
            if (!string.IsNullOrEmpty(accountParam.Sort))
            {
                switch (accountParam.Sort)
                {
                    case "name_desc":
                        AddOrderByDescending(x => x.Name);
                        break;
                    case "name_asc":
                        AddOrderBy(x => x.Name);
                        break;
                    case "OfficePhone_desc":
                        AddOrderByDescending(x => x.OfficePhone);
                        break;
                    case "OfficePhone_asc":
                        AddOrderBy(x => x.OfficePhone);
                        break;
                    case "Website_desc":
                        AddOrderByDescending(x => x.Website);
                        break;
                    case "Website_asc":
                        AddOrderBy(x => x.Website);
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
        public AccountFilterSpecification(int id) : base(x => x.AccountId == id)
        {
            AddInclude(x => x.User);
            AddInclude(x => x.AccountType);
            AddInclude(x => x.Industry);
            AddInclude(x => x.EmailAddress);
            AddInclude(x => x.Contacts);
            AddInclude("Contacts.PrefixTitle");
        }
    }
}
