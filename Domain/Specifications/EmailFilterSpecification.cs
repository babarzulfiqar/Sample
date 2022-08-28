using Core.Domain.MasterData;
using Core.Specifications.Parameters;

namespace Core.Specifications
{
    public class EmailFilterSpecification : BaseSpecification<EmailAddress>
    {
        public EmailFilterSpecification(EmailSpecParam param) : base(i =>
                (string.IsNullOrEmpty(param.Email) || i.Email.ToLower().Trim() == param.Email.ToLower().Trim())
       && (!param.isPrimary.HasValue || i.IsPrimary == param.isPrimary)
        && (!param.isValid.HasValue || i.IsValid == param.isValid)
        && (!param.OptOut.HasValue || i.OptOut == param.OptOut)
         && (!param.isActive.HasValue || i.IsActive == param.isActive) && (i.IsDeleted == false)
        )
        {
            AddOrderBy(x => x.Email);
        }
    }
}
