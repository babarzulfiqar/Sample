using Core.Domain.UserData;
using System;
using System.ComponentModel;

namespace Core.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreatedOn { get; set; }        
        public int? CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }
        public int? UpdatedById { get; set; }
        public User UpdateBy { get; set; }

        [DefaultValue(true)]
        public bool IsActive { get; set; }
        [DefaultValue(false)]
        public bool IsDeleted { get; set; }

    }
}
