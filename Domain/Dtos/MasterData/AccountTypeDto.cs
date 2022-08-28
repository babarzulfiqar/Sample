using Core.Dtos.Common;

namespace Core.Dtos.MasterData
{
    public class AccountTypeDto : AuditableDto
    {
        public int AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }

    }
}
