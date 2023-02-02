namespace SRG_SYSTEM.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public int StoreId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Email { get; set; }

        public int AddressId { get; set; }

        public bool? Active { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime? LastUpdate { get; set; }

        public virtual Address Address { get; set; } = null!;

        public virtual Store Store { get; set; } = null!;
    }
}
