using API.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.APIControllers
{

    public class CommissionsController(CalculateCommissionsService calculateCommissions) : BaseApiController
    {
        private readonly CalculateCommissionsService _calculateCommissions = calculateCommissions;

        [HttpGet("calculate")]
        public async Task<ActionResult<List<Seller>>> Commissions(
            [FromQuery] DateTime StartDate,
            [FromQuery] DateTime EndDate
        )
        {
            var startDateUtc = StartDate.Kind == DateTimeKind.Unspecified
                ? DateTime.SpecifyKind(StartDate, DateTimeKind.Utc)
                : StartDate.ToUniversalTime();

            var endDateUtc = EndDate.Kind == DateTimeKind.Unspecified
               ? DateTime.SpecifyKind(EndDate, DateTimeKind.Utc)
               : EndDate.ToUniversalTime();

            try
            {
                var results = await _calculateCommissions.CommissionsPerSeller(startDateUtc, endDateUtc);
                return Ok(results);
            }
            catch (Exception ex)
            {
                return BadRequest(new {message = "Error", error = ex.Message});
            }
        }
    }
}
