using System.Text.Json.Serialization;

namespace Nomis.Xrpscan.Interfaces.Models
{
    /// <summary>
    /// Xrpscan account.
    /// </summary>
    public class XrpscanAccount
    {
        /// <summary>
        /// XRP balance.
        /// </summary>
        [JsonPropertyName("xrpBalance")]
        public string? XrpBalance { get; set; }

        /// <summary>
        /// Inception.
        /// </summary>
        [JsonPropertyName("inception")]
        public DateTime Inception { get; set; }
    }
}