using ProtoBuf;

namespace SRG_SYSTEM.Models
{
    [ProtoContract]
    public class Country
    {
        [ProtoMember(1)]
        public int CountryId { get; set; }
        [ProtoMember(2)]
        public string Country1 { get; set; } = null!;

    }
}
