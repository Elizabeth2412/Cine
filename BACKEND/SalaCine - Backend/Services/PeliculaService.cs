using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaCine___Backend.Model;
using SalaCine___Backend.Repository;

namespace SalaCine___Backend.Services
{
    public class PeliculaService : ControllerBase
    {
        public PeliculaRepository _peliculaRepository;

        public PeliculaService(PeliculaRepository peliculaRepository)
        {
            _peliculaRepository = peliculaRepository;
        }


        //Listar Peliculas
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas()
        {
            return await _peliculaRepository.GetPeliculas();
        }

        //Buscar Pelicula por nombre
        public async Task<ActionResult<Pelicula>> GetPelicula(string nombre)
        {
            return await _peliculaRepository.GetPelicula(nombre);
        }


        //Crear Pelicula

        public async Task<ActionResult<Pelicula>> PostPelicula(Pelicula pelicula)
        {
            return await _peliculaRepository.PostPelicula(pelicula);
        }


        //Eliminar Pelicula
        public async Task<ActionResult<Pelicula>> DeletePelicula(int id)
        {
            return await _peliculaRepository.DeletePelicula(id);
        }


        //Editar Pelicula

        public async Task<ActionResult<Pelicula>> PutPelicula(int id, Pelicula pelicula)
        {
            return await _peliculaRepository.PutPelicula(id, pelicula);
        }
    }
}
