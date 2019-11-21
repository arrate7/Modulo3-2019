using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Services.Models;

    public class ServicesContext : DbContext
    {
        public ServicesContext (DbContextOptions<ServicesContext> options)
            : base(options)
        {
        }

        public DbSet<Services.Models.Videojuego> Videojuegos { get; set; }
    }
