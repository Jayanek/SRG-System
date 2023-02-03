using Newtonsoft.Json;

namespace SRG_SYSTEM.DataAccess
{
    public class PageTracker
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("lastPageNo")]
        public int LastPageNo { get; set; }

    }
}
