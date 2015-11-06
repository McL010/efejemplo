using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio01.mibd
{
    public class demoEF :DbContext
    {
       public DbSet<Empleado> Empleados {get; set;}//instancia para crear tablas dentro de la base de datos
       public DbSet<Departamento> Departamentos { get; set; }

    }
}
