using System.Text.Json.Serialization;

namespace Nomis.Xrpscan.Interfaces.Models
{
    /// <summary>
    /// Xrpscan KYC status.
    /// </summary>
    public class XrpscanKyc
    {
        /// <summary>
        /// Account.
        /// </summary>
        [JsonPropertyName("account")]
        public string? Account { get; set; }

        /// <summary>
        /// KYC approved.
        /// </summary>
        [JsonPropertyName("kycApproved")]
        public bool KycApproved { get; set; }
    }
}