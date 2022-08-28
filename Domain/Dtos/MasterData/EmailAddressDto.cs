using Core.Dtos.Common;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Dtos.MasterData
{
    public class EmailAddressDto : AuditableDto
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
        public string AccountName { get; set; }
        public int? ContactId { get; set; }
        public string ContactName { get; set; }
        public int? LeadId { get; set; }
        public string LeadName { get; set; }

    }
}
