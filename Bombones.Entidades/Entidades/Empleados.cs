using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Entidades.Entidades
{
    public class Empleados
    {
        public int EmpleadoId { get; set; }
        public string Nombre { get; set; } 
        public string Apellido { get; set; }
        public DateTime FechaContratacion { get; set; }
        
        public double Direccion { get; set; }
        public int CiudadId { get; set; }
        public int ProvinciaEstadoId { get; set; }
        public int PaisId { get; set; }
    }
}
