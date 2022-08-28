using Core.Common;
using System.Collections.Generic;

namespace Core.Domain.MasterData
{
    public class AccountType : AuditableEntity
    {
        public int AccountTypeId { get; set; }
        
        public string AccountTypeName { get; set; }
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
