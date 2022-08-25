using System.Text.Json.Serialization;

namespace Nomis.Xrpscan.Interfaces.Models
{
    /// <summary>
    /// Xrpscan order properties.
    /// </summary>
    public class XrpscanOrderProperties
    {
        /// <summary>
        /// Maker.
        /// </summary>
        [JsonPropertyName("maker")]
        public string? Maker { get; set; }

        /// <summary>
        /// Sequence.
        /// </summary>
        [JsonPropertyName("sequence")]
        public ulong Sequence { get; set; }

        /// <summary>
        /// Maker exchange rate.
        /// </summary>
        [JsonPropertyName("makerExchangeRate")]
        public string? MakerExchangeRate { get; set; }
    }
}