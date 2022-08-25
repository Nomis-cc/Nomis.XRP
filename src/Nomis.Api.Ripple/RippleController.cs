using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nomis.Api.Ripple.Abstractions;
using Nomis.Utils.Wrapper;
using Nomis.Xrpscan.Interfaces;
using Nomis.Xrpscan.Interfaces.Models;
using Swashbuckle.AspNetCore.Annotations;

namespace Nomis.Api.Ripple
{
    /// <summary>
    /// A controller to aggregate all Ripple-related actions.
    /// </summary>
    [Route(BasePath)]
    [ApiVersion("1")]
    [SwaggerTag("Ripple.")]
    internal sealed partial class RippleController :
        RippleBaseController
    {
        private readonly ILogger<RippleController> _logger;
        private readonly IXrpscanService _xrpscanService;

        /// <summary>
        /// Initialize <see cref="RippleController"/>.
        /// </summary>
        /// <param name="xrpscanService"><see cref="IXrpscanService"/>.</param>
        /// <param name="logger"><see cref="ILogger{T}"/>.</param>
        public RippleController(
            IXrpscanService xrpscanService,
            ILogger<RippleController> logger)
        {
            _xrpscanService = xrpscanService ?? throw new ArgumentNullException(nameof(xrpscanService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get Nomis Score for given wallet address.
        /// </summary>
        /// <param name="address" example="rDHokd6RdyWPXSaZzepd6B1ewLkD4v7cAN">Ripple wallet address to get Nomis Score.</param>
        /// <returns>An NomisScore value and corresponding statistical data.</returns>
        /// <remarks>
        /// Sample request:
        ///     GET /api/v1/ripple/wallet/rDHokd6RdyWPXSaZzepd6B1ewLkD4v7cAN/score
        /// </remarks>
        /// <response code="200">Returns Nomis Score and stats.</response>
        /// <response code="400">Address not valid.</response>
        /// <response code="404">No data found.</response>
        /// <response code="500">Unknown internal error.</response>
        [HttpGet("wallet/{address}/score", Name = "GetRippleWalletScore")]
        [AllowAnonymous]
        [SwaggerOperation(
            OperationId = "GetRippleWalletScore",
            Tags = new[] { RippleTag })]
        [ProducesResponseType(typeof(Result<RippleWalletScore>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ErrorResult<string>), StatusCodes.Status500InternalServerError)]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> GetRippleWalletScoreAsync(
            [Required(ErrorMessage = "Wallet address should be set")] string address)
        {
            var result = await _xrpscanService.GetWalletStatsAsync(address);
            return Ok(result);
        }
    }
}