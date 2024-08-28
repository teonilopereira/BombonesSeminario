using Bombones.Entidades.Entidades;
using Bombones.Servicios.Intefaces;
using Bombones.Windows.Helpers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bombones.Windows.Formularios
{
    public partial class frmProveedores : Form

    {
        private readonly IServiciosProveedores? _servicio;
        private List<Proveedores>? lista;
        public frmProveedores(IServiceProvider? serviceProvider)
        {
            InitializeComponent();
            _servicio = serviceProvider?.GetService<IServiciosProveedores>()
       ?? throw new ApplicationException("Dependencias no cargadas!!!"); ;
        }

        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmProveedoresAE frm = new frmProveedoresAE() { Text = "Agregar Proveedor" };
            DialogResult dr = frm.ShowDialog(this);
            try
            {
                if (dr == DialogResult.Cancel)
                {
                    return;
                }
                Proveedores? Proveedor = frm.GetProveedor();
                if (Proveedor is null)
                {
                    return;
                }

                if (!_servicio!.Existe(Proveedor))
                {
                    _servicio!.Guardar(Proveedor);
                    LoadData();
                    int row = GridHelper.ObtenerRowIndex(dgvDatos, Proveedor.ProveedorId);
                    GridHelper.MarcarRow(dgvDatos, row);

                    MessageBox.Show("Registro agregado",
                        "Mensaje",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                }
                else
                {
                    MessageBox.Show("Proveedor Duplicado!!!",
                        "Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,
                            "Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

            }
        }

        private void LoadData()
        {
            MostrarDatosEnGrilla(lista);
        }
        private void MostrarDatosEnGrilla(List<Proveedores>? lista)
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            if (lista is not null)
            {
                foreach (var item in lista)
                {
                    var r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, item);
                    GridHelper.AgregarFila(r, dgvDatos);
                }

            }
        }

        private void frmProveedores_Load(object sender, EventArgs e)
        {

            try
            {
                LoadData();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

