using Core.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Domain.MasterData
{
    public class EmailAddress : AuditableEntity
    {
        public int EmailAddressId { get; set; }
        [Required]
        public string Email { get; set; }
        [DefaultValue(null)]
        public bool? IsPrimary { get; set; }
        [DefaultValue(true)]
        public bool IsValid { get; set; }
        /// <summary>
        /// Opt out 
        /// false = do not send emails
        /// true = send emails
        /// by default/if not provided=false
        /// </summary>
        /// 
        [DefaultValue(false)]
        public bool OptOut { get; set; }
        public int? AccountId { get; set; }
        public Account Account { get; set; }
        public int? ContactId { get; set; }
        public Contact Contact { get; set; }
        public int? LeadId { get; set; }
        public Lead Lead { get; set; }
    }
}
