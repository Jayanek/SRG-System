
using ProtoBuf;

namespace SRG_SYSTEM.Models
{
    [ProtoContract]
    public class Address
    {
        [ProtoMember(1)]
        public int AddressId { get; set; }
        [ProtoMember(2)]
        public string Address1 { get; set; } = null!;
        [ProtoMember(3)]
        public string? Address2 { get; set; }
        [ProtoMember(4)]
        public string District { get; set; } = null!;
        [ProtoMember(5)]
        public int CityId { get; set; }
        [ProtoMember(6)]
        public string? PostalCode { get; set; }
        [ProtoMember(7)]
        public string Phone { get; set; } = null!;
        [ProtoMember(8)]
        public string Location { get; set; } = null!;
        [ProtoMember(9)]
        public DateTime LastUpdate { get; set; }
        [ProtoMember(10)]
        public virtual City City { get; set; } = null!;

    }
}
