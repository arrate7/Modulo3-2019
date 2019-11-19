using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Hamburgueseria.Models
{
    public class Principal
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string Nombre { get; set; }
        [MaxLength(300)]
        public string Descripcion { get; set; }
        [MaxLength(200)]
        public string Ingredientes { get; set; }
        [MaxLength(450)]
        public string Imagen { get; set; }
        public double Precio { get; set; }
    }
}
