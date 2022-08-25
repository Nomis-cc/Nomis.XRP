using Microsoft.Extensions.Options;
using Nomis.Utils.Wrapper;
using Nomis.Web.Client.Common.Extensions;
using Nomis.Web.Client.Common.Settings;
using Nomis.Web.Client.Ripple.Routes;
using Nomis.Xrpscan.Interfaces.Models;

namespace Nomis.Web.Client.Ripple.Managers
{
    /// <inheritdoc cref="IRippleManager" />
    public class RippleManager :
        IRippleManager
    {
        private readonly HttpClient _httpClient;
        private readonly RippleEndpoints _endpoints;

        /// <summary>
        /// Initialize <see cref="RippleManager"/>.
        /// </summary>
        /// <param name="webApiSettings"><see cref="WebApiSettings"/>.</param>
        public RippleManager(
            IOptions<WebApiSettings> webApiSettings)
        {
            _httpClient = new()
            {
                BaseAddress = new(webApiSettings.Value?.ApiBaseUrl ?? throw new ArgumentNullException(nameof(webApiSettings.Value.ApiBaseUrl)))
            };
            _endpoints = new(webApiSettings.Value?.ApiBaseUrl ?? throw new ArgumentNullException(nameof(webApiSettings.Value.ApiBaseUrl)));
        }

        /// <inheritdoc />
        public async Task<IResult<RippleWalletScore>> GetWalletScoreAsync(string address)
        {
            var response = await _httpClient.GetAsync(_endpoints.GetWalletScore(address));
            return await response.ToResultAsync<RippleWalletScore>();
        }
    }
}