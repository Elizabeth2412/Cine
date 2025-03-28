using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaCine___Backend.Model;

namespace SalaCine___Backend.Repository
{
    public class PeliculaRepository : ControllerBase
    {
        public readonly DbCineContext _context;

        public PeliculaRepository(DbCineContext context)
        {
            _context = context;
        }

        //Listar Peliculas
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas()
        {
            return await _context.Peliculas.FromSqlRaw("EXEC sp_listapelicula").ToListAsync();
        }

        //Buscar Pelicula por nombre 
        public async Task<ActionResult<Pelicula>> GetPelicula(string nombre)
        {
            //var pelicula = await _context.Peliculas.FromSqlRaw("EXEC sp_buscarpelicula @nombre = {0}", nombre).ToListAsync();

            //if (pelicula == null || pelicula.Count == 0)
            //{
            //    return NotFound("No se encontró la película");
            //}
            //return Ok(pelicula);

            var peliculas = await _context.Peliculas.FromSqlRaw("EXEC sp_buscarpelicula @nombre = {0}", nombre).ToListAsync();

            if (peliculas == null || !peliculas.Any())
            {
                return NotFound("No se encontró la película");
            }

            return Ok(peliculas);

        }

        //Crear Pelicula
        public async Task<ActionResult<Pelicula>> PostPelicula(Pelicula pelicula)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_crearpelicula @nombre = {0}, @duracion = {1}", pelicula.Nombre, pelicula.Duracion);

            if (result > 0)
            {
                return CreatedAtAction(nameof(PostPelicula), new { nombre = pelicula.Nombre }, pelicula);
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "No se pudo crear la película.");
            }
        }

        //Editar Pelicula
        public async Task<ActionResult<Pelicula>> PutPelicula(int id,Pelicula pelicula)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_editarpelicula @id_pelicula = {0}, @nombre = {1}, @duracion = {2}", id, pelicula.Nombre, pelicula.Duracion);
            if(result > 0)
            {
                return Ok("Actualizado correctamente");
            }
            else
            {
                return NotFound("No se pudo actualizar la pelicula");
            }
                
        }

        //Eliminar Pelicula

        public async Task<ActionResult<Pelicula>> DeletePelicula(int id)
        {
            var result = await _context.Database.ExecuteSqlRawAsync("EXEC sp_eliminarpelicula @id_pelicula = {0}", id);
            
            if (result > 0)
            {
                return Ok("Eliminado correctamente");
            }
            else
            {
                return NotFound("No se pudo eliminar la pelicula");
            }
        }
    }
}
