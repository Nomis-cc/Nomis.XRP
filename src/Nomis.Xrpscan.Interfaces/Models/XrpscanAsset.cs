using System.Text.Json.Serialization;

namespace Nomis.Xrpscan.Interfaces.Models
{
    /// <summary>
    /// Xrpscan asset.
    /// </summary>
    public class XrpscanAsset
    {
        /// <summary>
        /// Counterparty.
        /// </summary>
        [JsonPropertyName("counterparty")]
        public string? Counterparty { get; set; }

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
        /// Counterparty name.
        /// </summary>
        [JsonPropertyName("counterpartyName")]
        public XrpscanCounterpartyName? CounterpartyName { get; set; }
    }
}