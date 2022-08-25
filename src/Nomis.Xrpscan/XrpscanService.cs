using Microsoft.Extensions.Logging;
using Nomis.Utils.Contracts.Services;
using Nomis.Utils.Wrapper;
using Nomis.Xrpscan.Calculators;
using Nomis.Xrpscan.Interfaces;
using Nomis.Xrpscan.Interfaces.Models;

namespace Nomis.Xrpscan
{
    /// <inheritdoc cref="XrpscanService"/>
    internal sealed class XrpscanService :
        IXrpscanService,
        ITransientService
    {
        private readonly ILogger<XrpscanService> _logger;

        /// <summary>
        /// Initialize <see cref="XrpscanService"/>.
        /// </summary>
        /// <param name="solscanClient"><see cref="IXrpscanClient"/>.</param>
        /// <param name="logger"><see cref="ILogger{T}"/>.</param>
        public XrpscanService(
            IXrpscanClient solscanClient,
            ILogger<XrpscanService> logger)
        {
            _logger = logger;
            Client = solscanClient;
        }

        /// <inheritdoc/>
        public IXrpscanClient Client { get; }

        /// <inheritdoc/>
        public async Task<Result<RippleWalletScore>> GetWalletStatsAsync(string address)
        {
            var account = await Client.GetAccountDataAsync(address);
            var kycStatus = await Client.GetKycDataAsync(address);
            var assets = await Client.GetAssetsDataAsync(address);
            var orders = await Client.GetOrdersDataAsync(address);
            var obligations = await Client.GetObligationsDataAsync(address);

            var transactions = await Client.GetTransactionsDataAsync(address);

            var walletStats = new RippleStatCalculator(
                    account,
                    kycStatus,
                    assets,
                    orders,
                    obligations,
                    transactions)
                .GetStats();

            return await Result<RippleWalletScore>.SuccessAsync(new()
            {
                Stats = walletStats,
                Score = walletStats.GetScore()
            }, "Got ripple wallet score.");
        }
    }
}