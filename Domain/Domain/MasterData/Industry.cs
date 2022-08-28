using Core.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Domain.MasterData
{
    public class Industry : AuditableEntity
    {
        public int IndustryId { get; set; }
        public string IndustryName { get; set; }
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
