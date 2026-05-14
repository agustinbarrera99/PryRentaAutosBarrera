using System;
using System.Windows.Forms;

namespace PryRentaAutosBarrera
{
    public partial class frmPrincipal : Form
    {
        private const string CONNECTION_STRING =
            "Server=.\\SQLEXPRESS;Database=GestionFlotas;Integrated Security=True;";

        private clsConexion _conexion;

        // Instancias lazy de cada formulario hijo
        private frmVehiculos _frmVehiculos;
        private frmChoferes _frmChoferes;
        private frmContratos _frmContratos;
        private frmAlquileres _frmAlquileres;
        private frmReportes _frmReportes;

        public frmPrincipal()
        {
            InitializeComponent();
            _conexion = new clsConexion(CONNECTION_STRING);
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {
            if (!_conexion.ProbarConexion())
            {
                MessageBox.Show(
                    "No se pudo conectar a la base de datos.\nVerifique el servidor y las credenciales.",
                    "Error de conexión",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            lblEstado.Text = "● Conectado";
            lblEstado.ForeColor = System.Drawing.Color.Green;
            tabPrincipal.SelectedIndex = 0;
            CargarFormularioEnTab(tabVehiculos, ref _frmVehiculos, () => new frmVehiculos(_conexion));
        }

        private void tabPrincipal_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabPrincipal.SelectedIndex)
            {
                case 0:
                    CargarFormularioEnTab(tabVehiculos, ref _frmVehiculos, () => new frmVehiculos(_conexion));
                    break;
                case 1:
                    CargarFormularioEnTab(tabChoferes, ref _frmChoferes, () => new frmChoferes(_conexion));
                    break;
                case 2:
                    CargarFormularioEnTab(tabContratos, ref _frmContratos, () => new frmContratos(_conexion));
                    break;
                case 3:
                    CargarFormularioEnTab(tabAlquileres, ref _frmAlquileres, () => new frmAlquileres(_conexion));
                    break;
                case 4:
                    CargarFormularioEnTab(tabReportes, ref _frmReportes, () => new frmReportes(_conexion));
                    break;
            }
        }

        private void CargarFormularioEnTab<T>(TabPage tab, ref T instancia, Func<T> factory)
            where T : Form
        {
            if (instancia != null && !instancia.IsDisposed)
                return;

            instancia = factory();
            instancia.FormBorderStyle = FormBorderStyle.None;
            instancia.TopLevel = false;
            instancia.Dock = DockStyle.Fill;

            tab.Controls.Clear();
            tab.Controls.Add(instancia);
            instancia.Show();
        }
        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del sistema?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }

            _conexion?.Dispose();
        }
    }
}