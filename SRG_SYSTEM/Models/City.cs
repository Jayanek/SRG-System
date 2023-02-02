using ProtoBuf;
using System.Diagnostics.Metrics;

namespace SRG_SYSTEM.Models
{
    [ProtoContract]
    public class City
    {
        [ProtoMember(1)]
        public int CityId { get; set; }
        [ProtoMember(2)]
        public string City1 { get; set; } = null!;
        [ProtoMember(3)]
        public int CountryId { get; set; }
        [ProtoMember(4)]
        public virtual Country Country { get; set; } = null!;
    }
}
