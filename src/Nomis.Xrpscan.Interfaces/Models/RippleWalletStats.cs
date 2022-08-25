using System.ComponentModel;
using Nomis.Blockchain.Abstractions;

namespace Nomis.Xrpscan.Interfaces.Models
{
    /// <summary>
    /// Ripple wallet stats.
    /// </summary>
    public class RippleWalletStats :
        IWalletStats
    {
        /// <summary>
        /// No data.
        /// </summary>
        public bool NoData { get; init; }

        /// <inheritdoc/>
        [Description("Wallet balance (XRP)")]
        public decimal Balance { get; set; }

        /// <inheritdoc/>
        [Description("Wallet age (months)")]
        public int WalletAge { get; set; }

        /// <inheritdoc/>
        [Description("Total transactions on wallet (number)")]
        public int TotalTransactions { get; set; }

        /// <inheritdoc/>
        [Description("Average time interval between transactions (hours)")]
        public double AverageTransactionTime { get; set; }

        /// <inheritdoc/>
        [Description("Maximum time interval between transactions (hours)")]
        public double MaxTransactionTime { get; set; }

        /// <inheritdoc/>
        [Description("Minimal time interval between transactions (hours)")]
        public double MinTransactionTime { get; set; }

        /// <inheritdoc/>
        [Description("The movement of funds on the wallet (XRP)")]
        public decimal WalletTurnover { get; set; }

        /// <inheritdoc/>
        [Description("Total NFTs on wallet (number)")]
        public int NftHolding { get; set; }

        /// <inheritdoc/>
        [Description("Time since last transaction (months)")]
        public int TimeFromLastTransaction { get; set; }

        /// <inheritdoc/>
        [Description("NFT trading activity (XRP)")]
        public decimal NftTrading { get; set; }

        /// <inheritdoc/>
        [Description("NFT worth on wallet (XRP)")]
        public decimal NftWorth { get; set; }

        /// <inheritdoc/>
        [Description("Last month transactions (number)")]
        public int LastMonthTransactions { get; set; }

        /// <inheritdoc/>
        [Description("Average transaction per months (number)")]
        public double TransactionsPerMonth => WalletAge != 0 ? (double)TotalTransactions / WalletAge : 0;

        /// <inheritdoc/>
        [Description("Value of all holding tokens (number)")]
        public int TokensHolding { get; set; }
    }
}