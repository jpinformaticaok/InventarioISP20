using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocalidadesController : ControllerBase
    {
        private readonly InventarioContext _context;

        public LocalidadesController(InventarioContext context)
        {
            _context = context;
        }

        // GET: api/Localidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Localidad>>> GetLocalidades([FromQuery] string filtro = "")
        {
            filtro = filtro.ToUpper();
            return await _context.Localidades
                .Include(l => l.Provincia)
                .ThenInclude(p => p.Pais)
                .Where(c => c.Name.ToUpper().Contains(filtro) || c.Provincia.Name.ToUpper().Contains(filtro))
                .Where(c => !c.isDeleted)  // Filtramos solo las localidades que no están eliminadas
                .ToListAsync();
        }

        // GET: api/Localidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Localidad>> GetLocalidad(int id)
        {
            var localidad = await _context.Localidades.FindAsync(id);

            if (localidad == null)
            {
                return NotFound();
            }

            return localidad;
        }

        // PUT: api/Localidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLocalidad(int id, Localidad localidad)
        {
            if (id != localidad.Id)
            {
                return BadRequest();
            }

            _context.Entry(localidad).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LocalidadExists(id))
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

        // POST: api/Localidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Localidad>> PostLocalidad(Localidad localidad)
        {
            _context.Localidades.Add(localidad);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLocalidad", new { id = localidad.Id }, localidad);
        }

        // DELETE: api/Localidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLocalidad(int id)
        {
            var localidad = await _context.Localidades.FindAsync(id);
            if (localidad == null)
            {
                return NotFound();
            }
            localidad.isDeleted = true;
            _context.Entry(localidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LocalidadExists(int id)
        {
            return _context.Localidades.Any(e => e.Id == id);
        }

        // devolvemos el total de localidades que no estan eliminadas
        [HttpGet("total")]
        public async Task<ActionResult<int>> GetTotalLocalidades()
        {
            return await _context.Localidades.CountAsync(c => !c.isDeleted);
        }

        // GET: api/Localidades los borrados
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Localidad>>> GetDeleteds()
        {
            return await _context.Localidades
                .IgnoreQueryFilters()  //
                .Include(l => l.Provincia)
                .ThenInclude(p => p.Pais)
                .Where(c => c.isDeleted)  // Filtramos solo las localidades eliminadas   
                .ToListAsync();
        }

        // DELETE: api/Restore/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreCliente(int id)
        {
            var localidad = await _context.Localidades
                                .IgnoreQueryFilters()
                                .FirstOrDefaultAsync(c => c.Id == id);
            if (localidad == null)
            {
                return NotFound();
            }

            localidad.isDeleted = false;
            _context.Entry(localidad).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}