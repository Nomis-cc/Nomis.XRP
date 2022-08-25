using System.Text.Json.Serialization;

namespace Nomis.Xrpscan.Interfaces.Models
{
    /// <summary>
    /// Xrpscan order.
    /// </summary>
    public class XrpscanOrder
    {
        /// <summary>
        /// Specification.
        /// </summary>
        [JsonPropertyName("specification")]
        public XrpscanOrderSpecification? Specification { get; set; }

        /// <summary>
        /// Properties.
        /// </summary>
        [JsonPropertyName("properties")]
        public XrpscanOrderProperties? Properties { get; set; }
    }
}