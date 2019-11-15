using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Videoclub.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(20)]
        [Required]
        public string Name { get; set; }
        public string LastName { get; set; }
        [EmailAddress (ErrorMessage ="Formato de email incorrecto.")]
        public string Email { get; set; }
        public string ProfilePicture { get; set; }

        public List<UserFilm> UserFilms { get; set; }

    }
}
