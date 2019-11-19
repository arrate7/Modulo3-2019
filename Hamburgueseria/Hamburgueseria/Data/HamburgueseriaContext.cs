using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hamburgueseria.Models;

    public class HamburgueseriaContext : DbContext
    {
        public HamburgueseriaContext (DbContextOptions<HamburgueseriaContext> options)
            : base(options)
        {
        }

        public DbSet<Hamburgueseria.Models.Menu> Menus { get; set; }
        public DbSet<Hamburgueseria.Models.Principal> Principales { get; set; }
        public DbSet<Hamburgueseria.Models.Entrante> Entrantes { get; set; }
        public DbSet<Hamburgueseria.Models.Postre> Postres { get; set; }
    }
