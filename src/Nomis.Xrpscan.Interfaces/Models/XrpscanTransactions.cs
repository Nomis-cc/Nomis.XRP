using System.Text.Json.Serialization;

namespace Nomis.Xrpscan.Interfaces.Models
{
    /// <summary>
    /// Xrpscan transactions.
    /// </summary>
    public class XrpscanTransactions
    {
        /// <summary>
        /// Account.
        /// </summary>
        [JsonPropertyName("account")]
        public string? Account { get; set; }

        /// <summary>
        /// Limit.
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        /// <summary>
        /// Marker.
        /// </summary>
        [JsonPropertyName("marker")]
        public string? Marker { get; set; }

        /// <summary>
        /// Transactions.
        /// </summary>
        [JsonPropertyName("transactions")]
        public List<XrpscanTransaction> Transactions { get; set; } = new();
    }
}