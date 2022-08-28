using Core.Domain.MasterData;
using Core.Specifications.Parameters;

namespace Core.Specifications
{
    public class LeadFilterSpecification : BaseSpecification<Lead>
    {
        public LeadFilterSpecification(LeadSpecParam param) : base(i =>
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
            AddInclude(x => x.PrefixTitle);
            AddInclude(x => x.Status);
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
                    case "Country_desc":
                        AddOrderByDescending(x => x.Country);
                        break;
                    case "Country_asc":
                        AddOrderBy(x => x.Country);
                        break;
                 
                    case "City_desc":
                        AddOrderByDescending(x => x.City);
                        break;
                    case "City_asc":
                        AddOrderBy(x => x.City);
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

        public LeadFilterSpecification(int id) : base(x => x.LeadId == id)
        {
            AddInclude(x => x.PrefixTitle);
            AddInclude(x => x.AssignedToUser);
            AddInclude(x => x.LeadSource);
            AddInclude(x => x.Status);
            AddInclude(x => x.LeadSource);
            AddInclude(x => x.EmailAddress);
            AddInclude(x => x.CreatedBy);
        }
    }
}
