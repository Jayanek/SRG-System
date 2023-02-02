using ProtoBuf;

namespace SRG_SYSTEM.Models
{
    [ProtoContract]
    public class Customer
    {
        [ProtoMember(1)]
        public int CustomerId { get; set; }
        [ProtoMember(2)]
        public int StoreId { get; set; }
        [ProtoMember(3)]
        public string FirstName { get; set; } = null!;
        [ProtoMember(4)]
        public string LastName { get; set; } = null!;
        [ProtoMember(5)]
        public string? Email { get; set; }
        [ProtoMember(6)]
        public int AddressId { get; set; }
        [ProtoMember(7)]
        public bool? Active { get; set; }
        [ProtoMember(8)]
        public DateTime CreateDate { get; set; }
        [ProtoMember(9)]
        public DateTime? LastUpdate { get; set; }
        [ProtoMember(10)]
        public virtual Address Address { get; set; } = null!;
        [ProtoMember(11)]
        public virtual Store Store { get; set; } = null!;
    }
}
