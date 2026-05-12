using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PryRentaAutosBarrera
{
    public partial class frmChoferes : Form
    {
        private readonly clsConexion _db;
        private int _idSeleccionado = 0;

        public frmChoferes(clsConexion conexion)
        {
            InitializeComponent();
            _db = conexion;
        }

        private void frmChoferes_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            ModoAlta();
        }

        private void CargarGrilla()
        {
            dgvChoferes.DataSource = _db.EjecutarConsulta(
                "SELECT Id_Chofer AS ID, Nombre_Completo AS [Nombre Completo], " +
                "DNI_Pasaporte AS [DNI/Pasaporte], Telefono AS Teléfono, " +
                "Licencia_Conducir AS Licencia " +
                "FROM Choferes ORDER BY Nombre_Completo");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            var p = new[]
            {
                new SqlParameter("@Nombre",   txtNombre.Text.Trim()),
                new SqlParameter("@DNI",      txtDNI.Text.Trim()),
                new SqlParameter("@Telefono", txtTelefono.Text.Trim()),
                new SqlParameter("@Licencia", txtLicencia.Text.Trim())
            };

            if (_idSeleccionado == 0)
            {
                _db.EjecutarComando(
                    "INSERT INTO Choferes (Nombre_Completo, DNI_Pasaporte, Telefono, Licencia_Conducir) " +
                    "VALUES (@Nombre, @DNI, @Telefono, @Licencia)", p);
                MessageBox.Show("Chofer registrado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var pUpd = new[] { p[0], p[1], p[2], p[3], new SqlParameter("@Id", _idSeleccionado) };
                _db.EjecutarComando(
                    "UPDATE Choferes SET Nombre_Completo=@Nombre, DNI_Pasaporte=@DNI, " +
                    "Telefono=@Telefono, Licencia_Conducir=@Licencia WHERE Id_Chofer=@Id", pUpd);
                MessageBox.Show("Chofer actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarGrilla();
            ModoAlta();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0) { MessageBox.Show("Seleccione un chofer."); return; }

            if (MessageBox.Show("¿Eliminar el chofer seleccionado?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            try
            {
                _db.EjecutarComando("DELETE FROM Choferes WHERE Id_Chofer = @Id",
                    new[] { new SqlParameter("@Id", _idSeleccionado) });
                MessageBox.Show("Chofer eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                ModoAlta();
            }
            catch
            {
                MessageBox.Show("No se puede eliminar: el chofer tiene alquileres asociados.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e) => ModoAlta();

        private void dgvChoferes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvChoferes.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(row.Cells["ID"].Value);
            txtNombre.Text = row.Cells["Nombre Completo"].Value.ToString();
            txtDNI.Text = row.Cells["DNI/Pasaporte"].Value.ToString();
            txtTelefono.Text = row.Cells["Teléfono"].Value?.ToString() ?? "";
            txtLicencia.Text = row.Cells["Licencia"].Value?.ToString() ?? "";
            btnGuardar.Text = "Actualizar";
            btnEliminar.Enabled = true;
        }

        private void ModoAlta()
        {
            _idSeleccionado = 0;
            txtNombre.Clear(); txtDNI.Clear(); txtTelefono.Clear(); txtLicencia.Clear();
            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false;
            txtNombre.Focus();
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            { MessageBox.Show("Ingrese el nombre completo."); txtNombre.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtDNI.Text))
            { MessageBox.Show("Ingrese el DNI / Pasaporte."); txtDNI.Focus(); return false; }
            return true;
        }
    }
}