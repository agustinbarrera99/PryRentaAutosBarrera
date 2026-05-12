using System;
using System.Windows.Forms;

namespace PryRentaAutosBarrera
{
    public partial class frmPrincipal : Form
    {
        private const string CONNECTION_STRING =
            "Server=.\\SQLEXPRESS;Database=GestionFlotas;Integrated Security=True;";

        private clsConexion _conexion;

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
        }

        // ── Vehículos ──
        private void gestionVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
            => AbrirMDI(new frmVehiculos(_conexion));

        // ── Choferes ──
        private void gestionChoferesToolStripMenuItem_Click(object sender, EventArgs e)
            => AbrirMDI(new frmChoferes(_conexion));

        // ── Contratos ──
        private void gestionContratosToolStripMenuItem_Click(object sender, EventArgs e)
            => AbrirMDI(new frmContratos(_conexion));

        // ── Alquileres ──
        private void gestionAlquileresToolStripMenuItem_Click(object sender, EventArgs e)
            => AbrirMDI(new frmAlquileres(_conexion));

        // ── Reportes ──
        private void reportesToolStripMenuItem_Click(object sender, EventArgs e)
            => AbrirMDI(new frmReportes(_conexion));

        // ── Salir ──
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea salir del sistema?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        // ── Helper MDI ──
        private void AbrirMDI(Form frm)
        {
            frm.MdiParent = this;
            frm.Show();
        }

        private void frmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
            => _conexion?.Dispose();
    }
}