﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFramework.Models
{
    public class Obra
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public DateTime AnioPublicacion { get; set; }
        public string  Imagen { get; set; }

        public int AutorId { get; set; }
        public Autor Autor { get; set; }
    }
}
