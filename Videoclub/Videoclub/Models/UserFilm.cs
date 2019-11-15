using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Videoclub.Models
{
    public class UserFilm
    {
        public int Id { get; set; }
        public DateTime DateRented { get; set; }
        public DateTime? DateReturned { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
        public int FilmId { get; set; }
        public Film Film { get; set; }
    }
}
