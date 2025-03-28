using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaCine___Backend.Model;

namespace SalaCine___Backend.Repository
{
    public class SalaRepository : ControllerBase
    {
        public DbCineContext _context;

        public SalaRepository(DbCineContext context)
        {
            _context = context;
        }
        //Listar Sala
        public async Task<ActionResult<IEnumerable<SalaCine>>> GetSalaCines()
        {
            return await _context.SalaCines.FromSqlRaw("EXEC sp_listasala").ToListAsync();
        }

        //Buscar SalaCine por nombre 
        public async Task<ActionResult<SalaCine>> GetSala(string nombre)
        {
            //var SalaCine = await _context.SalaCines.FromSqlRaw("EXEC sp_buscarSalaCine @nombre = {0}", nombre).ToListAsync();

            //if (SalaCine == null || SalaCine.Count == 0)
            //{
            //    return NotFound("No se encontró la película");
            //}
            //return Ok(SalaCine);

            var SalaCines = await _context.SalaCines.FromSqlRaw("EXEC sp_buscarSalaCine @nombre = {0}", nombre).ToListAsync();

            if (SalaCines == null || !SalaCines.Any())
            {
                return NotFound("No se encontró la película");
            }

            return Ok(SalaCines);

        }

        //Crear SalaCine
        public async Task<ActionResult<SalaCine>> PostSalaCine(SalaCine SalaCine)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_crearsala @nombre = {0}, @duracion = {1}", SalaCine.Nombre, SalaCine.Duracion);

            if (result > 0)
            {
                return CreatedAtAction(nameof(PostSalaCine), new { nombre = SalaCine.Nombre }, SalaCine);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo crear la película.");
            }
        }

        //Editar SalaCine
        public async Task<ActionResult<SalaCine>> PutSalaCine(int id, SalaCine SalaCine)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_editarsala @id_SalaCine = {0}, @nombre = {1}, @duracion = {2}", id, SalaCine.Nombre, SalaCine.Duracion);
            if (result > 0)
            {
                return Ok("Actualizado correctamente");
            }
            else
            {
                return NotFound("No se pudo actualizar la SalaCine");
            }

        }

        //Eliminar SalaCine

        public async Task<ActionResult<SalaCine>> DeleteSalaCine(int id)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_eliminarsala @id_SalaCine = {0}", id);

            if (result > 0)
            {
                return Ok("Eliminado correctamente");
            }
            else
            {
                return NotFound("No se pudo eliminar la SalaCine");
            }
        }
    }
}

