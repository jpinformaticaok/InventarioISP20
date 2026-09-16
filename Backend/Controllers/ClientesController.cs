using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Backend.Data;
using Services.Models;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly InventarioContext _context;

        public ClientesController(InventarioContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes([FromQuery] string filtro="")
        {
            filtro = filtro.ToUpper();
            return await _context.Clientes
                .Include(c => c.Localidad)
                .ThenInclude(l => l.Provincia)
                .ThenInclude(p => p.Pais)
                .Where(c=>c.Firstname.ToUpper().Contains(filtro) || c.Lastname.ToUpper().Contains(filtro) || c.Dni.Contains(filtro) || c.Address.ToUpper().Contains(filtro))
                .ToListAsync();
        }

        // GET: api/Clientes los borrados
        [HttpGet("deleteds")]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetDeleteds()
        {
            return await _context.Clientes
                .IgnoreQueryFilters()  //
                .Include(c => c.Localidad)
                .ThenInclude(l => l.Provincia)
                .ThenInclude(p => p.Pais)
                .Where(c=>c.isDeleted)  // Filtramos solo los clientes eliminados   
                .ToListAsync();
        }

        // Devolvemos el total de clientes que no están eliminados
        [HttpGet("total")]
        public async Task<ActionResult<int>> GetTotalClientes()
        {
            var totalClientes = await _context.Clientes.CountAsync(c => !c.isDeleted);
            return Ok(totalClientes);
        }


        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Localidad)
                .ThenInclude(l => l.Provincia)
                .ThenInclude(p => p.Pais)
                .FirstOrDefaultAsync(c=>c.Id==id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/Clientes/5
        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.isDeleted = true;
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Clientes/5
        [HttpPut("restore/{id}")]
        public async Task<IActionResult> RestoreCliente(int id)
        {
            var cliente = await _context.Clientes
                                .IgnoreQueryFilters()
                                .FirstOrDefaultAsync(c => c.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }

            cliente.isDeleted = false;
            _context.Entry(cliente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
