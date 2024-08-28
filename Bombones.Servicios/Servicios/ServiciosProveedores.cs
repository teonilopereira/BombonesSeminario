using Bombones.Datos.Interfaces;
using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bombones.Servicios.Servicios
{
    public class ServiciosProveedores : IServiciosProveedores
    {
        private readonly IRepositorioProveedores? _repositorio;
        private readonly string? _cadena;
        public ServiciosProveedores(IRepositorioProveedores? repositorio, string? cadena) 
        {
            _repositorio = repositorio ?? throw new ApplicationException("Dependencias no cargadas!!!"); ;
            _cadena = cadena;
        }
        public void Borrar(int ProveedorId)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        _repositorio!.Borrar(ProveedorId, conn, tran);
                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
        public bool EstaRelacionado(int ProveedorId)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.EstaRelacionado(ProveedorId, conn);
            }
        }
        public void Guardar(Proveedores proveedor)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                using (var tran = conn.BeginTransaction())
                {
                    try
                    {
                        if (proveedor.ProveedorId == 0)
                        {
                            _repositorio!.Agregar(proveedor, conn, tran);
                        }
                        else
                        {
                            _repositorio!.Editar(proveedor, conn, tran);
                        }

                        tran.Commit();
                    }
                    catch (Exception)
                    {
                        tran.Rollback();
                        throw;
                    }
                }
            }
        }
        public bool Existe(Proveedores proveedores)
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.Existe(proveedores, conn);
            }
        }
        public int GetCantidad()
        {
            using (var conn = new SqlConnection(_cadena))
            {
                conn.Open();
                return _repositorio!.GetCantidad(conn);
            }

        }

        public Proveedores? GetProveedoresPorId(int proveedoresId)
        {

            using (var conn = new SqlConnection(_cadena))
            {
                return _repositorio!.GetproveedoresPorId(proveedoresId, conn);
            }
        }



    }

}
