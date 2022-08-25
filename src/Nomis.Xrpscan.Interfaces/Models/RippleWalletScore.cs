namespace Nomis.Xrpscan.Interfaces.Models
{
    /// <summary>
    /// Ripple wallet score.
    /// </summary>
    public class RippleWalletScore
    {
        /// <summary>
        /// Nomis Score in range of [0; 1].
        /// </summary>
        public double Score { get; set; }

        /// <summary>
        /// Additional stat data used in score calculations.
        /// </summary>
        public RippleWalletStats? Stats { get; set; }
    }
}