using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Wrapper;
using Nomis.Xrpscan.Interfaces.Models;

namespace Nomis.Xrpscan.Interfaces
{
    /// <summary>
    /// Xrpscan service.
    /// </summary>
    public interface IXrpscanService :
        IInfrastructureService
    {
        /// <summary>
        /// Client for interacting with Xrpscan API.
        /// </summary>
        public IXrpscanClient Client { get; }

        /// <summary>
        /// Get ripple wallet stats by address.
        /// </summary>
        /// <param name="address">Ripple wallet address.</param>
        /// <returns>Returns <see cref="RippleWalletScore"/> result.</returns>
        public Task<Result<RippleWalletScore>> GetWalletStatsAsync(string address);
    }
}