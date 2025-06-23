using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.APIControllers
{
    public class RulesController(AppDbContext context) : BaseApiController
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public async Task<ActionResult<List<Rule>>> GetRules()
        {
            try
            {
                var rules = await _context.Rules.ToListAsync();
                return Ok(rules);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = "Error al obtener las reglas", error = ex.Message });
            }
        }
    }
}
