using Bombones.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Intefaces
{
    public interface IServiciosProveedores
    {
        void Borrar(int ProveedorId);
        bool EstaRelacionado(int Id);
        bool Existe(Proveedores proveedores);
        void Guardar(Proveedores proveedor);
        Proveedores? GetProveedoresPorId(int proveedorId);
        int GetCantidad();

    }
}
