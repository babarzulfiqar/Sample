namespace Core.Specifications.Parameters
{
    public class ContactSpecParam
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;
        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string Sort { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OfficePhone { get; set; }
        public string Mobile { get; set; }
        public string BillingCountry { get; set; }
        public string ShippingCountry { get; set; }
        public string BillingCity { get; set; }
        public string ShippingCity { get; set; }
        public bool? IsActive { get; set; }
        private string _search;
        public string Search
        {
            get => _search;
            set => _search = value.ToLower();
        }
    }
}
