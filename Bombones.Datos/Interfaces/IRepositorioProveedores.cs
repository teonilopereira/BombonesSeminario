using Bombones.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Datos.Interfaces
{
    public interface IRepositorioProveedores
    {
        int GetCantidad(SqlConnection conn, SqlTransaction? tran = null);
        void Agregar(Proveedores proveedores, SqlConnection conn, SqlTransaction? tran = null);
        void Borrar(int proveedoresId, SqlConnection conn, SqlTransaction? tran = null);
        void Editar(Proveedores proveedores, SqlConnection conn, SqlTransaction? tran = null);
        bool EstaRelacionado(int tipoId, SqlConnection conn, SqlTransaction? tran = null);
        bool Existe(Proveedores proveedores, SqlConnection conn, SqlTransaction? tran = null);
        Proveedores? GetproveedoresPorId(int proveedorId, SqlConnection conn, SqlTransaction? tran = null);
        List<Proveedores> GetLista(SqlConnection conn, SqlTransaction? tran = null);
    }
}
