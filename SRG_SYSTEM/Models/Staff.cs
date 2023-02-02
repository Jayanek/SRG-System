namespace SRG_SYSTEM.Models
{
    public class Staff
    {
        public int StaffId { get; set; }

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public int AddressId { get; set; }

        public string Picture { get; set; }

        public string? Email { get; set; }

        public int StoreId { get; set; }

        public bool? Active { get; set; }

        public string Username { get; set; } = null!;

        public string? Password { get; set; }

        public DateTime LastUpdate { get; set; }

        public virtual Address Address { get; set; } = null!;

    }
}
