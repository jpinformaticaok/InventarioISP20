using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProvinciasController : ControllerBase
    {
        private readonly InventarioContext _context;

        public ProvinciasController(InventarioContext context)
        {
            _context = context;
        }

        // GET: api/Provincias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Provincia>>> GetProvincias([FromQuery] string filtro = "")
        {
            filtro = filtro.ToUpper();
            return await _context.Provincias
                .Include(p => p.Pais) // Incluimos la entidad relacionada Pais
                .Where(p => p.Name.ToUpper().Contains(filtro) || p.Pais.Name.ToUpper().Contains(filtro))
                .Where(p => !p.isDeleted)  // Filtramos solo las provincias que no están eliminadas
                .ToListAsync();
        }

        // GET: api/Provincias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Provincia>> GetProvincia(int id)
        {
            var provincia = await _context.Provincias.FindAsync(id);

            if (provincia == null)
            {
                return NotFound();
            }

            return provincia;
        }

        // PUT: api/Provincias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProvincia(int id, Provincia provincia)
        {
            if (id != provincia.Id)
            {
                return BadRequest();
            }

            _context.Entry(provincia).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProvinciaExists(id))
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

        // POST: api/Provincias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Provincia>> PostProvincia(Provincia provincia)
        {
            _context.Provincias.Add(provincia);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProvincia", new { id = provincia.Id }, provincia);
        }

        // DELETE: api/Provincias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvincia(int id)
        {
            var provincia = await _context.Provincias.FindAsync(id);
            if (provincia == null)
            {
                return NotFound();
            }
            provincia.isDeleted = true;
            _context.Entry(provincia).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProvinciaExists(int id)
        {
            return _context.Provincias.Any(e => e.Id == id);
        }

        // devolvemos el total de provincias que no estan eliminadas
        [HttpGet("total")]
        public async Task<ActionResult<int>> GetTotalProvincias()
        {
            return await _context.Provincias.CountAsync(c => !c.isDeleted);
        }

        // GET: api/Provincias los borrados
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Provincia>>> GetDeleteds()
        {
            return await _context.Provincias
                .IgnoreQueryFilters()  //
                .Include(p => p.Pais)
                .Where(c => c.isDeleted)  // Filtramos solo las provincias eliminadas
                .ToListAsync();
        }

        // PUT: api/Provincias/restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreProvincia(int id)
        {
            var provincia = await _context.Provincias
                                .IgnoreQueryFilters()
                                .FirstOrDefaultAsync(c => c.Id == id);
            if (provincia == null)
            {
                return NotFound();
            }

            provincia.isDeleted = false;
            _context.Entry(provincia).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}