using System.Text.Json.Serialization;

namespace Nomis.Xrpscan.Interfaces.Models
{
    /// <summary>
    /// Xrpscan counterparty name.
    /// </summary>
    public class XrpscanCounterpartyName
    {
        /// <summary>
        /// Name.
        /// </summary>
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Description.
        /// </summary>
        [JsonPropertyName("desc")]
        public string? Description { get; set; }

        /// <summary>
        /// Account.
        /// </summary>
        [JsonPropertyName("account")]
        public string? Account { get; set; }

        /// <summary>
        /// Domain.
        /// </summary>
        [JsonPropertyName("domain")]
        public string? Domain { get; set; }

        /// <summary>
        /// Twitter.
        /// </summary>
        [JsonPropertyName("twitter")]
        public string? Twitter { get; set; }
    }
}