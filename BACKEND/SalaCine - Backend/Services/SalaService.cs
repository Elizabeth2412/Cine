using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalaCine___Backend.Model;
using SalaCine___Backend.Repository;

namespace SalaCine___Backend.Services
{
   
    public class SalaService : ControllerBase
    {
        public SalaRepository _salaRepository;
        public SalaService(SalaRepository salaRepository)
        {

            _salaRepository = salaRepository;
        }

    //Listar Peliculas
        public async Task<ActionResult<IEnumerable<Pelicula>>> GetPeliculas()
        {
            return await _salaRepository.GetSalaCines();
        }

        //Buscar Pelicula por nombre
        public async Task<ActionResult<Pelicula>> GetPelicula(string nombre)
        {
            return await _salaRepository.GetSala(nombre);
        }


        //Crear Pelicula

        public async Task<ActionResult<Pelicula>> PostPelicula(Pelicula pelicula)
        {
            return await _salaRepository.PostPelicula(pelicula);
        }


        //Eliminar Pelicula
        public async Task<ActionResult<Pelicula>> DeletePelicula(int id)
        {
            return await _salaRepository.DeletePelicula(id);
        }


        //Editar Pelicula

        public async Task<ActionResult<Pelicula>> PutPelicula(int id, Pelicula pelicula)
        {
            return await _salaRepository.PutPelicula(id, pelicula);
        }
    }
