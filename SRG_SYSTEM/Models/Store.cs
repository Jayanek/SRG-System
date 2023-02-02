using ProtoBuf;

namespace SRG_SYSTEM.Models
{
    [ProtoContract]
    public class Store
    {
        [ProtoMember(1)]
        public int StoreId { get; set; }
        [ProtoMember(2)]
        public int ManagerStaffId { get; set; }
        [ProtoMember(3)]
        public int AddressId { get; set; }
        [ProtoMember(4)]
        public DateTime LastUpdate { get; set; }
        [ProtoMember(5)]
        public virtual Address Address { get; set; } = null!;
        [ProtoMember(6)]
        public virtual Staff ManagerStaff { get; set; } = null!;

    }
}
