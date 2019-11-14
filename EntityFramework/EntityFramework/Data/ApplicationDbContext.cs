using System;
using System.Collections.Generic;
using System.Text;
using EntityFramework.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Obra> Obras{ get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
