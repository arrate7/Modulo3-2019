using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Videoclub.Models
{
    public class Film
    {
        public int Id { get; set; }
        [MaxLength(60)]
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Sinospsis { get; set; }
        [MaxLength(15)]
        [Required]
        public string Genero { get; set; }
        public string Imagen { get; set; }
        public bool Rented { get; set; }

        public List<UserFilm> UserFilms { get; set; }
    }
}
