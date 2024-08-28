using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Dapper;
using System.Data.SqlClient;

namespace Bombones.Datos.Repositorios
{
    public class RepositorioProveedores: IRepositorioProveedores
    {
        public RepositorioProveedores(){}


        public void Agregar(Proveedores tipo, SqlConnection conn, SqlTransaction? tran = null)
        {
            string insertQuery = @"INSERT INTO Proveedores (NombreProveedor) 
                    VALUES(@NombreProveedor); SELECT CAST(SCOPE_IDENTITY() as int)";

            var primaryKey = conn.QuerySingle<int>(insertQuery, tipo, tran);
            if (primaryKey > 0)
            {

                tipo.ProveedorId = primaryKey;
                return;
            }

            throw new Exception("No se pudo agregar el Proveedor");
        }
        public void Borrar(int tipoId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string deleteQuery = @"DELETE FROM Proveedores 
                    WHERE PRoveedorId=@TipoId";
            int registrosAfectados = conn
                .Execute(deleteQuery, new { tipoId }, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo borrar el Proveedor");
            }
        }
        public int GetCantidad(SqlConnection conn, SqlTransaction? tran)
        {
            string selectQuery = @"SELECT COUNT(*) FROM Proveedores";
            return conn.ExecuteScalar<int>(selectQuery);
        }
        public void Editar(Proveedores tipo, SqlConnection conn, SqlTransaction? tran = null)
        {
            string updateQuery = @"UPDATE Proveedores SET Nombreproveedor=@Nombreproveedor 
                    WHERE ProveedorId=@ProveedorId";

            int registrosAfectados = conn.Execute(updateQuery, tipo, tran);
            if (registrosAfectados == 0)
            {
                throw new Exception("No se pudo editar el Proveedor");
            }
        }

        public bool EstaRelacionado(int tipoId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) 
                            FROM Bombones 
                                WHERE TipoDeChocolateId=@TipoId";
            return conn.
                QuerySingle<int>(selectQuery, new { tipoId }) > 0;

        }

        public bool Existe(Proveedores tipo, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT COUNT(*) FROM Proveedores ";
            string finalQuery = string.Empty;
            string conditional = string.Empty;
            if (tipo.ProveedorId == 0)
            {
                conditional = "WHERE NombreProveedor = @NombreProveedor";
            }
            else
            {
                conditional = @"WHERE NombreProveedor = @NombreProveedor
                                AND ProveedorId<>@ProveedorId";
            }
            finalQuery = string.Concat(selectQuery, conditional);
            return conn.QuerySingle<int>(finalQuery, tipo) > 0;
        }

        public List<Proveedores> GetLista(SqlConnection conn, SqlTransaction? tran = null)
        {
            var selectQuery = @"SELECT ProveedorId,NombreProveedor,Telefono,Email FROM 
                    Proveedores ORDER BY NombreProveedores";
            return conn.Query<Proveedores>(selectQuery).ToList();
        }
        public Proveedores? GetproveedoresPorId(int proveedorId, SqlConnection conn, SqlTransaction? tran = null)
        {
            string selectQuery = @"SELECT PaisId, NombrePais, 
                 FROM Paises 
                WHERE PaisId=@PaisId";
            return conn.QuerySingleOrDefault<Proveedores>(
                selectQuery, new { ProveedorId = proveedorId });
        }




    }
}
