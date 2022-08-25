using System.Globalization;

using Nomis.Utils.Exceptions;
using Nomis.Xrpscan.Interfaces.Models;

namespace Nomis.Xrpscan.Calculators
{
    /// <summary>
    /// Ripple wallet stats calculator.
    /// </summary>
    internal sealed class RippleStatCalculator
    {
        private readonly XrpscanAccount _account;
        private readonly XrpscanKyc _kycStatus;
        private readonly IEnumerable<XrpscanAsset> _assets;
        private readonly IEnumerable<XrpscanOrder> _orders;
        private readonly IEnumerable<XrpscanObligation> _obligations;
        private readonly IEnumerable<XrpscanTransaction> _transactions;

        /// <summary>
        /// Initialize <see cref="RippleStatCalculator"/>.
        /// </summary>
        /// <param name="account">Account data.</param>
        /// <param name="kycStatus">KYC status.</param>
        /// <param name="assets">List of assets.</param>
        /// <param name="orders">List of orders.</param>
        /// <param name="obligations">List of obligations.</param>
        /// <param name="transactions">List of transactions.</param>
        public RippleStatCalculator(
            XrpscanAccount account,
            XrpscanKyc kycStatus,
            IEnumerable<XrpscanAsset> assets,
            IEnumerable<XrpscanOrder> orders,
            IEnumerable<XrpscanObligation> obligations,
            IEnumerable<XrpscanTransaction> transactions)
        {
            _account = account;
            _kycStatus = kycStatus;
            _assets = assets;
            _orders = orders;
            _obligations = obligations;
            _transactions = transactions;
        }

        private int GetWalletAge()
        {
            return (int)((DateTime.UtcNow - _account.Inception).TotalDays / 30);
        }

        private static IEnumerable<double> GetTransactionsIntervals(IEnumerable<DateTime?> transactionDates)
        {
            var result = new List<double>();
            DateTime? lasDateTime = null;
            foreach (var transactionDate in transactionDates)
            {
                if (transactionDate == null)
                {
                    continue;
                }

                if (!lasDateTime.HasValue)
                {
                    lasDateTime = transactionDate;
                    continue;
                }

                var interval = Math.Abs((transactionDate.Value - lasDateTime.Value).TotalHours);
                result.Add(interval);
            }

            return result;
        }

        public RippleWalletStats GetStats()
        {
            var transactionIntervals = GetTransactionsIntervals(_transactions.Select(x => x.Date)).ToList();
            if (!transactionIntervals.Any())
            {
                throw new NoDataException("There is no transactions for this wallet");
            }

            var monthAgo = DateTime.Now.AddMonths(-1);

            return new()
            {
                Balance = decimal.TryParse(_account.XrpBalance, NumberStyles.AllowDecimalPoint, new NumberFormatInfo() {CurrencyDecimalSeparator = "."}, out var balance) ? balance : 0,
                WalletAge = GetWalletAge(),
                TotalTransactions = _transactions.Count(),
                MinTransactionTime = transactionIntervals.Min(),
                MaxTransactionTime = transactionIntervals.Max(),
                AverageTransactionTime = transactionIntervals.Average(),
                /*WalletTurnover = _solTransfers.Data.Sum(x => x.Lamport).ToSol(),*/
                LastMonthTransactions = _transactions.Count(x => x.Date > monthAgo) + _transactions.Count(x => x.Date > monthAgo),
                TimeFromLastTransaction = (int)((DateTime.UtcNow - _transactions.Where(x => x.Date != null).Min(x => x.Date!.Value)).TotalDays / 30),
                /*NftHolding = _tokens.Count(x => x.TokenAmount is { Decimals: 0, UiAmount: > 0 }),
                NftTrading = magicEdenWalletSells.Sum(x => x.Price) - magicEdenWalletBuys.Sum(x => x.Price),
                NftWorth = magicEdenWalletBuys.Where(x => !magicEdenWalletSells.Select(y => y.TokenMint).Contains(x.TokenMint)).Sum(x => x.Price),
                TokensHolding = _tokens.Count(x => x.TokenAmount?.UiAmount > 0)*/
            };
        }
    }
}