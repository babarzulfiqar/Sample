using System;

namespace Core.Dtos.Common
{
    public abstract class AuditableDto
    {
        public DateTime? CreatedOn { get; set; }
        public int? CreatedById { get; set; }
        public string CreatedByName { get; set; }
        public bool IsActive { get; set; }

    }
}
