using Nomis.Web.Client.Common.Routes;

namespace Nomis.Web.Client.Ripple.Routes
{
    /// <summary>
    /// Ripple endpoints.
    /// </summary>
    public class RippleEndpoints :
        BaseEndpoints
    {
        /// <summary>
        /// Initialize <see cref="RippleEndpoints"/>.
        /// </summary>
        /// <param name="baseUrl">Ripple API base URL.</param>
        public RippleEndpoints(string baseUrl)
            : base(baseUrl)
        {
        }

        /// <inheritdoc/>
        public override string Blockchain => "ripple";
    }
}