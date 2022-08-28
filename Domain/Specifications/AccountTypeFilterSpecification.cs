using Core.Domain.MasterData;

namespace Core.Specifications
{
    public class AccountTypeFilterSpecification : BaseSpecification<AccountType>
    {
        public AccountTypeFilterSpecification(string accountTypeName,bool? isActive) : base(i =>
                (string.IsNullOrEmpty(accountTypeName) || i.AccountTypeName.ToLower().Trim() == accountTypeName.ToLower().Trim())
        &&  (!isActive.HasValue || i.IsActive == isActive) && (i.IsDeleted == false)
        )
        {
            AddOrderBy(x => x.AccountTypeName);
        }
    }
}
