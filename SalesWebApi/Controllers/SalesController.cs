using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesWebApi.Models;

namespace SalesWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly SalesDbContext _context;

        public SalesController(SalesDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetSales()
        {
            return Ok(await _context.Sales.ToListAsync());
        }
    }
}
