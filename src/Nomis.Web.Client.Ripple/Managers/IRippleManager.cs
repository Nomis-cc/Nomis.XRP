using Nomis.Utils.Wrapper;
using Nomis.Web.Client.Common.Managers;
using Nomis.Xrpscan.Interfaces.Models;

namespace Nomis.Web.Client.Ripple.Managers
{
    /// <summary>
    /// Ripple manager.
    /// </summary>
    public interface IRippleManager :
        IManager
    {
        /// <summary>
        /// Get ripple wallet score.
        /// </summary>
        /// <param name="address">Wallet address.</param>
        /// <returns>Returns result of <see cref="RippleWalletScore"/>.</returns>
        Task<IResult<RippleWalletScore>> GetWalletScoreAsync(string address);
    }
}