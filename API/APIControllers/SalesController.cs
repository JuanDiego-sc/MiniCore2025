using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.APIControllers
{
    public class SalesController(AppDbContext context) : BaseApiController
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Sale>>> GetSales()
        {
            try
            {
                var sales = await _context.Sales
                    .Select( s => new
                    {
                        s.Id,
                        s.TotalValue,
                        s.RuleId,
                        s.SellerId
                    })
                    .ToListAsync();

                return Ok(sales);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener las ventas", error = ex.Message });
            }
        }

    }
}
