using Core.Domain.MasterData;
using Core.Specifications.Parameters;
namespace Core.Specifications
{
    public class OpportunityFilterSpecification : BaseSpecification<Opportunity>
    {
        public OpportunityFilterSpecification(OpportunitySpecParam param) : base(i =>
               (string.IsNullOrEmpty(param.OpportunityName) || i.OpportunityName.Contains(param.OpportunityName))
            && (param.OpportunityAmount == null || i.OpportunityAmount == param.OpportunityAmount)
             && (param.Probability == null || i.Probability == param.Probability) &&
               (param.ExpectedCloseDate == null || i.ExpectedCloseDate.Date == param.ExpectedCloseDate.Value.Date)

             && (!param.IsActive.HasValue || i.IsActive == param.IsActive) && (i.IsDeleted == false)
             && (string.IsNullOrEmpty(param.Search) || i.OpportunityName.Contains(param.Search))
            )
        {
            AddInclude(x => x.Currency);
            AddInclude(x => x.SaleStage);
            AddInclude(x => x.Account);
            AddInclude(x => x.AssignedToUser);
            AddInclude(x => x.LeadSource);
            AddOrderBy(x => x.OpportunityName);
            if (param.PageIndex > 0 || param.PageSize > 0)
            {
                ApplyPaging(param.PageSize * (param.PageIndex - 1), param.PageSize);
            }
            if (!string.IsNullOrEmpty(param.Sort))
            {
                switch (param.Sort)
                {
                    case "OpportunityName_desc":
                        AddOrderByDescending(x => x.OpportunityName);
                        break;
                    case "OpportunityName_asc":
                        AddOrderBy(x => x.OpportunityName);
                        break;
                    case "Currency_desc":
                        AddOrderByDescending(x => x.Currency);
                        break;
                    case "Currency_asc":
                        AddOrderBy(x => x.Currency);
                        break;
                    case "OpportunityAmount_desc":
                        AddOrderByDescending(x => x.OpportunityAmount);
                        break;
                    case "OpportunityAmount_asc":
                        AddOrderBy(x => x.OpportunityAmount);
                        break;
                    case "IsActive_desc":
                        AddOrderByDescending(x => x.IsActive);
                        break;
                    case "IsActive_asc":
                        AddOrderBy(x => x.IsActive);
                        break;
                }
            }
        }

        public OpportunityFilterSpecification(int id) : base(x => x.OpportunityId == id)
        {
            AddInclude(x => x.Currency);
            AddInclude(x => x.SaleStage);
            AddInclude(x => x.Account);
            AddInclude(x => x.AssignedToUser);
            AddInclude(x => x.LeadSource);
            AddInclude(x => x.BusinessType);
            AddInclude(x => x.CreatedBy);
        }
    }
}
