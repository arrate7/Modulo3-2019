using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videoclub.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Sinospsis { get; set; }
        public string Genero { get; set; }
        public string Imagen { get; set; }
        public bool Rented { get; set; }

        public List<UserFilm> UserFilms { get; set; }
    }
}
