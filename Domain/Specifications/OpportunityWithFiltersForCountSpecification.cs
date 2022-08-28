using Core.Domain.MasterData;
using Core.Specifications.Parameters;
namespace Core.Specifications
{
    public class OpportunityWithFiltersForCountSpecification : BaseSpecification<Opportunity>
    {
        public OpportunityWithFiltersForCountSpecification(OpportunitySpecParam param) : base(i =>
               (string.IsNullOrEmpty(param.OpportunityName) || i.OpportunityName.Contains(param.OpportunityName))
            && (param.OpportunityAmount == null || i.OpportunityAmount == param.OpportunityAmount)
             && (param.Probability == null || i.Probability == param.Probability) &&
               (param.ExpectedCloseDate == null || i.ExpectedCloseDate == param.ExpectedCloseDate)

             && (!param.IsActive.HasValue || i.IsActive == param.IsActive) && (i.IsDeleted == false)
             && (string.IsNullOrEmpty(param.Search) || i.OpportunityName.Contains(param.Search))
            )
        {

        }
    }
}
