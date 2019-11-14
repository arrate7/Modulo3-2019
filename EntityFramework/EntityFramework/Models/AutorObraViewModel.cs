using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class AutorObraViewModel
    {
        public string Titulo { get; set; }
        public DateTime AnioPublicacion { get; set; }
        public List<Autor> Autores { get; set; }
        public int AutorId { get; set; }
    }
}
