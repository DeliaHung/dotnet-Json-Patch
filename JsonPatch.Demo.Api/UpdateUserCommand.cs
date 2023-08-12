namespace JsonPatch.Demo.Api
{
    public class UpdateUserCommand
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public int Age { get; internal set; }
        public bool IsNewsletterSubscribed { get; internal set; }
        public List<string> EmailList { get; set; } = new List<string>();
        public List<UpdateUserShippingAddress> ShippingAddresses { get; set; } = new List<UpdateUserShippingAddress>();
    }

    public class UpdateUserShippingAddress
    {
        public string? ZipCode { get; set; }
        public string? Address { get; set; }
    }
}
