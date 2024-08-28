using Bombones.Entidades.Entidades;

namespace Bombones.Windows.Formularios
{
    public partial class frmProveedoresAE : Form
    {
        private Proveedores? proveedores;
        public frmProveedoresAE()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (proveedores != null)
            {
                txtProveedor.Text = proveedores.NombreProveedor;
            }
        }
        public void setProveedores(Proveedores? proveedores)
        {
            this.proveedores = proveedores;
        }

        public Proveedores? GetProveedor()
        {
            return proveedores;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (ValidarDatos())
            {
                if (proveedores == null)
                {
                    proveedores = new Proveedores();
                }
                proveedores.NombreProveedor = txtProveedor.Text;

                DialogResult = DialogResult.OK;
            }
        }

        private bool ValidarDatos()
        {
            bool valido = true;
            errorProvider1.Clear();
            if (string.IsNullOrEmpty(txtProveedor.Text))
            {
                valido = false;
                errorProvider1.SetError(txtProveedor, "El país es requerido");
            }
            return valido;
        }
    }
}
