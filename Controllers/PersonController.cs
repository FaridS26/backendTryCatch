using Microsoft.AspNetCore.Mvc;
using test_tryCatch.Data.Models;
using test_tryCatch.Data;
using Microsoft.EntityFrameworkCore;

namespace test_tryCatch.Controllers
{
    [ApiController]
    [Route("/person")]
    public class PersonController : ControllerBase
    {
        private readonly DataContext _context;
        public PersonController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("active")]
        public async Task<ActionResult<IEnumerable<Persona>>> GetActivePersons()
        {
            try
            {
                var activePersons = await _context.Personas
                    .Where(u => u.Status == "Activo")
                    .ToListAsync();

                return Ok(activePersons);
            }
            catch (Exception)
            {
                return StatusCode(500, "An error occurred while processing your request.");
            }
        }
    }
}
