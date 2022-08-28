namespace Core.Specifications.Parameters
{
    public class EmailSpecParam
    {
        public string Email { get; set; }
        public bool? isPrimary { get; set; }
        public bool? isValid { get; set; }
        public bool? OptOut { get; set; }
        public bool? isActive { get; set; }
    }
}
