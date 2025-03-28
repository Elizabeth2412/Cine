using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalaCine___Backend.Model;
using SalaCine___Backend.Services;

namespace SalaCine___Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PeliculaController : ControllerBase
    {
        public readonly PeliculaService _peliculaService;
        public PeliculaController(PeliculaService peliculaService)
        {
            _peliculaService = peliculaService;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pelicula>>> ListarPeliculas()
        {
            var peliculas = await _peliculaService.GetPeliculas();
            return Ok(peliculas);
        }

        [HttpGet("{nombre}")]
        public async Task<ActionResult<IEnumerable<Pelicula>>> BuscarPeliculas([FromRoute]string nombre)
        {
            var pelicula = await _peliculaService.GetPelicula(nombre);
            return Ok(pelicula);
        }


        [HttpPost]
        public async Task<ActionResult<Pelicula>> CrearPelicula([FromBody]Pelicula pelicula)
        {
            await _peliculaService.PostPelicula(pelicula);
            return StatusCode(StatusCodes.Status201Created, pelicula);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pelicula>> ActualizarPelicula(int id, [FromBody] Pelicula pelicula)
        {
            var peliculatualiza = await _peliculaService.PutPelicula(id, pelicula);

            if (peliculatualiza == null)
            {
                return NotFound("No se pudo actualizar");
            }
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pelicula>> BorrarPelicula(int id)
        {
            var pelicula = await _peliculaService.DeletePelicula(id);
            if (pelicula == null)
            {
                return NotFound("No se pudo eliminar");
            }
            return NoContent();
        }
    }
}
