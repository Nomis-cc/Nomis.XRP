using System.Text.Json.Serialization;

namespace Nomis.Xrpscan.Interfaces.Models
{
    /// <summary>
    /// Xrpscan order specification quantity.
    /// </summary>
    public class XrpscanOrderSpecificationQuantity
    {
        /// <summary>
        /// Currency.
        /// </summary>
        [JsonPropertyName("currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// Value.
        /// </summary>
        [JsonPropertyName("value")]
        public string? Value { get; set; }

        /// <summary>
        /// Counterparty.
        /// </summary>
        [JsonPropertyName("counterparty")]
        public string? Counterparty { get; set; }
    }
}