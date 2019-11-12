using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Prueba.Models;

namespace Prueba.Controllers
{
    public class EmpleadosController : Controller
    {
        public List<Empleado> Empleados { get; set; }

        public EmpleadosController()
        {
            Empleados = new List<Empleado>
            {
                new Empleado{ Id=1,Nombre="Maura",Apellido="Rayo",FechaNacimiento =Convert.ToDateTime("23/09/2000"), Imagen="https://media.metrolatam.com/2018/08/23/mujer1-234853dc0e0619b7be7317871413304c-600x400.jpg"},
                new Empleado{ Id=3,Nombre="Rober",Apellido="Bermúdez",FechaNacimiento =Convert.ToDateTime("29/10/1971"), Imagen="https://ep01.epimg.net/elpais/imagenes/2018/11/06/gente/1541494541_621304_1541494790_noticia_normal.jpg"},
                new Empleado{ Id=4,Nombre="Raúl",Apellido="López",FechaNacimiento =Convert.ToDateTime("29/10/1986"), Imagen="https://www.novalaser.com/wp-content/uploads/2018/08/Depilacion-Hombre.jpg"},
                new Empleado{ Id=5,Nombre="Raúl",Apellido="Maturano",FechaNacimiento =Convert.ToDateTime("29/10/1992"), Imagen="https://hombresconestilo.com/wp-content/uploads/2018/08/Peinados-modernos-hombre.jpg"},

            };
        }

        public IActionResult Index(string nombre)
        {
            if (String.IsNullOrEmpty(nombre))
            {
                return View(Empleados);
            }

            Empleados = Empleados.Where(x => x.Nombre.ToLower()
            .Contains(nombre.ToLower())).ToList();

            return View(Empleados);
        }

        public IActionResult Detalle()
        {
            Empleado empleado = new Empleado
            {
                Id = 1,
                Nombre = "Arrate",
                Apellido = "Ortiz de Zarate",
                FechaNacimiento = Convert.ToDateTime("25/06/1993"),
                Imagen = "https://fotos02.levante-emv.com/2019/11/09/328x206/dolera.jpg"
            };

            return View(empleado);
        }
    }
}