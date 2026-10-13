using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly InventarioContext _context;

        public PaisesController(InventarioContext context)
        {
            _context = context;
        }

        // GET: api/Paises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pais>>> GetPaises([FromQuery] string filtro = "")
        {
            filtro = filtro.ToUpper();
            return await _context.Paises
                .Where(p => p.Name.ToUpper().Contains(filtro))
                .Where(p => !p.isDeleted)  // Filtramos solo los paises que no están eliminados
                .ToListAsync();
        }

        // GET: api/Paises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pais>> GetPais(int id)
        {
            var pais = await _context.Paises.FindAsync(id);

            if (pais == null)
            {
                return NotFound();
            }

            return pais;
        }

        // PUT: api/Paises/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPais(int id, Pais pais)
        {
            if (id != pais.Id)
            {
                return BadRequest();
            }

            _context.Entry(pais).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaisExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Paises
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pais>> PostPais(Pais pais)
        {
            _context.Paises.Add(pais);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPais", new { id = pais.Id }, pais);
        }

        // DELETE: api/Paises/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePais(int id)
        {
            var pais = await _context.Paises.FindAsync(id);
            if (pais == null)
            {
                return NotFound();
            }
            pais.isDeleted = true;
            _context.Entry(pais).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PaisExists(int id)
        {
            return _context.Paises.Any(e => e.Id == id);
        }

        // devolvemos el total de paises que no estan eliminados
        [HttpGet("total")]
        public async Task<ActionResult<int>> GetTotalPaises()
        {
            return await _context.Paises.CountAsync(c => !c.isDeleted);
        }

        // GET: api/Paises los borrados
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Pais>>> GetDeleteds()
        {
            return await _context.Paises
                .IgnoreQueryFilters()  //
                .Where(c => c.isDeleted)  // Filtramos solo los paises eliminados
                .ToListAsync();
        }

        // PUT: api/Paises/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestorePais(int id)
        {
            var pais = await _context.Paises
                                .IgnoreQueryFilters()
                                .FirstOrDefaultAsync(c => c.Id == id);
            if (pais == null)
            {
                return NotFound();
            }

            pais.isDeleted = false;
            _context.Entry(pais).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}