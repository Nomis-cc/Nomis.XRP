using Nomis.Utils.Contracts.Common;

namespace Nomis.Xrpscan.Interfaces.Settings
{
    /// <summary>
    /// Xrpscan settings.
    /// </summary>
    public class XrpscanSettings :
        ISettings
    {
        /// <summary>
        /// API base URL.
        /// </summary>
        /// <remarks>
        /// <see href="https://docs.xrpscan.com/api-doc.html"/>
        /// </remarks>
        public string? ApiBaseUrl { get; set; }
    }
}