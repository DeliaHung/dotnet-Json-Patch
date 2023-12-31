﻿namespace JsonPatch.Demo.Api
{
    public class User
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public int Age { get; internal set; }
        public bool IsNewsletterSubscribed { get; internal set; }
        public List<string> EmailList { get; set; } = new List<string>();
        public List<ShippingAddress> ShippingAddresses { get; set; } = new List<ShippingAddress>();
    }

    public class ShippingAddress
    {
        public string? ZipCode { get; set; }
        public string? Address { get; set; }
    }
}
