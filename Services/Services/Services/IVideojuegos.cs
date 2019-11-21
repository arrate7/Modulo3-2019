using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Services.Services
{
    public interface IVideojuegos
    {
        public Task<List<Videojuego>> GetVideojuegosAsync();
        public Task<Videojuego> GetVideojuegoByIdAsync(int? id);
        public Task CreateVideojuegoAsync(Videojuego videojuego);
        public Task UpdateVideojuegoAsync(Videojuego videojuego);
        public Task DeleteVideojuegoAsync(Videojuego videojuego);

        public bool VideojuegoExists(int id);
    }
}
