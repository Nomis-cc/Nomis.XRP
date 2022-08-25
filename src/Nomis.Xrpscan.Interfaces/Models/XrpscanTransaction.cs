using System.Text.Json.Serialization;

namespace Nomis.Xrpscan.Interfaces.Models
{
    /// <summary>
    /// Xrpscan transaction.
    /// </summary>
    public class XrpscanTransaction
    {
        /// <summary>
        /// Meta.
        /// </summary>
        [JsonPropertyName("meta")]
        public XrpscanTransactionMeta? Meta { get; set; }

        /// <summary>
        /// Validated.
        /// </summary>
        [JsonPropertyName("validated")]
        public bool Validated { get; set; }

        /// <summary>
        /// Account.
        /// </summary>
        [JsonPropertyName("Account")]
        public string? Account { get; set; }

        /// <summary>
        /// Fee.
        /// </summary>
        [JsonPropertyName("Fee")]
        public string? Fee { get; set; }

        /// <summary>
        /// Flags.
        /// </summary>
        [JsonPropertyName("Flags")]
        public ulong Flags { get; set; }

        /// <summary>
        /// Transaction type.
        /// </summary>
        [JsonPropertyName("TransactionType")]
        public string? TransactionType { get; set; }

        /// <summary>
        /// Transaction signature.
        /// </summary>
        [JsonPropertyName("TxnSignature")]
        public string? TxnSignature { get; set; }

        /// <summary>
        /// Date.
        /// </summary>
        [JsonPropertyName("date")]
        public DateTime? Date { get; set; }

        /// <summary>
        /// Hash.
        /// </summary>
        [JsonPropertyName("hash")]
        public string? Hash { get; set; }
    }
}