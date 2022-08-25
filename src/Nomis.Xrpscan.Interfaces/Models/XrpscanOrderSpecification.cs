using System.Text.Json.Serialization;

namespace Nomis.Xrpscan.Interfaces.Models
{
    /// <summary>
    /// Xrpscan order specification.
    /// </summary>
    public class XrpscanOrderSpecification
    {
        /// <summary>
        /// Direction.
        /// </summary>
        [JsonPropertyName("direction")]
        public string? Direction { get; set; }

        /// <summary>
        /// Quantity.
        /// </summary>
        [JsonPropertyName("quantity")]
        public XrpscanOrderSpecificationQuantity? Quantity { get; set; }

        /// <summary>
        /// Total price.
        /// </summary>
        [JsonPropertyName("totalPrice")]
        public XrpscanOrderSpecificationTotalPrice? TotalPrice { get; set; }
    }
}