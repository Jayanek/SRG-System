using System.Diagnostics.Metrics;

namespace SRG_SYSTEM.Models
{
    public class City
    {
        public int CityId { get; set; }

        public string City1 { get; set; } = null!;

        public int CountryId { get; set; }

        public virtual Country Country { get; set; } = null!;
    }
}
