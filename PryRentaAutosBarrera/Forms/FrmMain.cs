using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PryRentaAutosBarrera.Forms
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        // ─── MENÚ: Gestión de Vehículos ──────────────────────────────
        private void gestionDeVehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormulario(new FrmVehiculos());
        }

        // ─── MENÚ: Salir ─────────────────────────────────────────────
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var resultado = MessageBox.Show(
                "¿Estás seguro que querés salir?",
                "Salir",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (resultado == DialogResult.Yes)
                Application.Exit();
        }

        // ─── HELPER: Abre un form como hijo MDI ──────────────────────
        private void AbrirFormulario(Form formulario)
        {
            // Si ya está abierto, lo trae al frente
            foreach (Form f in this.MdiChildren)
            {
                if (f.GetType() == formulario.GetType())
                {
                    f.BringToFront();
                    formulario.Dispose();
                    return;
                }
            }

            formulario.MdiParent = this;
            formulario.Show();
        }
    }
}