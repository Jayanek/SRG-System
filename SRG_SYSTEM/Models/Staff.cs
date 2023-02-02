using ProtoBuf;

namespace SRG_SYSTEM.Models
{
    [ProtoContract]
    public class Staff
    {
        [ProtoMember(1)]
        public int StaffId { get; set; }
        [ProtoMember(2)]
        public string FirstName { get; set; } = null!;
        [ProtoMember(3)]
        public string LastName { get; set; } = null!;
        [ProtoMember(4)]
        public int AddressId { get; set; }
        [ProtoMember(5)]
        public string Picture { get; set; }
        [ProtoMember(6)]
        public string? Email { get; set; }
        [ProtoMember(7)]
        public int StoreId { get; set; }
        [ProtoMember(8)]
        public bool? Active { get; set; }
        [ProtoMember(9)]
        public string Username { get; set; } = null!;
        [ProtoMember(10)]
        public string? Password { get; set; }
        [ProtoMember(11)]
        public DateTime LastUpdate { get; set; }
        [ProtoMember(12)]
        public virtual Address Address { get; set; } = null!;

    }
}
