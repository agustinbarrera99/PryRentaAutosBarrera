using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PryRentaAutosBarrera
{
    public partial class frmVehiculos : Form
    {
        private readonly clsConexion _db;
        private int _idSeleccionado = 0;

        public frmVehiculos(clsConexion conexion)
        {
            InitializeComponent();
            _db = conexion;
        }

        private void frmVehiculos_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            ModoAlta();
        }

        // ── Cargar DataGridView ──────────────────────────────────
        private void CargarGrilla()
        {
            var dt = _db.EjecutarConsulta(
                "SELECT Id_Vehiculo AS ID, Patente, Modelo_Marca AS [Modelo/Marca], " +
                "CONVERT(varchar,Mantenimiento,103) AS Mantenimiento, " +
                "CONVERT(varchar,Seguro,103) AS Seguro, " +
                "CASE Estado WHEN 1 THEN 'Disponible' ELSE 'No disponible' END AS Estado " +
                "FROM Vehiculos ORDER BY Id_Vehiculo");
            dgvVehiculos.DataSource = dt;
        }

        // ── Guardar (Insert o Update) ────────────────────────────
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            var p = new[]
            {
                new SqlParameter("@Patente",       txtPatente.Text.Trim().ToUpper()),
                new SqlParameter("@Modelo_Marca",  txtModelo.Text.Trim()),
                new SqlParameter("@Mantenimiento", dtpMantenimiento.Checked ? (object)dtpMantenimiento.Value.Date : DBNull.Value),
                new SqlParameter("@Seguro",        dtpSeguro.Checked        ? (object)dtpSeguro.Value.Date        : DBNull.Value),
                new SqlParameter("@Estado",        chkEstado.Checked ? 1 : 0)
            };

            if (_idSeleccionado == 0)
            {
                _db.EjecutarComando(
                    "INSERT INTO Vehiculos (Patente, Modelo_Marca, Mantenimiento, Seguro, Estado) " +
                    "VALUES (@Patente, @Modelo_Marca, @Mantenimiento, @Seguro, @Estado)", p);
                MessageBox.Show("Vehículo registrado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var pUpd = new[]
                {
                    p[0], p[1], p[2], p[3], p[4],
                    new SqlParameter("@Id", _idSeleccionado)
                };
                _db.EjecutarComando(
                    "UPDATE Vehiculos SET Patente=@Patente, Modelo_Marca=@Modelo_Marca, " +
                    "Mantenimiento=@Mantenimiento, Seguro=@Seguro, Estado=@Estado " +
                    "WHERE Id_Vehiculo=@Id", pUpd);
                MessageBox.Show("Vehículo actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarGrilla();
            ModoAlta();
        }

        // ── Eliminar ─────────────────────────────────────────────
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0) { MessageBox.Show("Seleccione un vehículo."); return; }

            if (MessageBox.Show("¿Eliminar el vehículo seleccionado?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            try
            {
                _db.EjecutarComando("DELETE FROM Vehiculos WHERE Id_Vehiculo = @Id",
                    new[] { new SqlParameter("@Id", _idSeleccionado) });
                MessageBox.Show("Vehículo eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                ModoAlta();
            }
            catch
            {
                MessageBox.Show("No se puede eliminar: el vehículo tiene alquileres asociados.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ── Nuevo ────────────────────────────────────────────────
        private void btnNuevo_Click(object sender, EventArgs e) => ModoAlta();

        // ── Selección en grilla ──────────────────────────────────
        private void dgvVehiculos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvVehiculos.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(row.Cells["ID"].Value);
            txtPatente.Text = row.Cells["Patente"].Value.ToString();
            txtModelo.Text = row.Cells["Modelo/Marca"].Value.ToString();
            chkEstado.Checked = row.Cells["Estado"].Value.ToString() == "Disponible";

            if (DateTime.TryParse(row.Cells["Mantenimiento"].Value?.ToString(), out DateTime mant))
            { dtpMantenimiento.Checked = true; dtpMantenimiento.Value = mant; }
            else dtpMantenimiento.Checked = false;

            if (DateTime.TryParse(row.Cells["Seguro"].Value?.ToString(), out DateTime seg))
            { dtpSeguro.Checked = true; dtpSeguro.Value = seg; }
            else dtpSeguro.Checked = false;

            btnGuardar.Text = "Actualizar";
            btnEliminar.Enabled = true;
        }

        // ── Helpers ──────────────────────────────────────────────
        private void ModoAlta()
        {
            _idSeleccionado = 0;
            txtPatente.Clear();
            txtModelo.Clear();
            dtpMantenimiento.Checked = false;
            dtpSeguro.Checked = false;
            chkEstado.Checked = true;
            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false;
            txtPatente.Focus();
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtPatente.Text))
            { MessageBox.Show("Ingrese la patente."); txtPatente.Focus(); return false; }
            if (string.IsNullOrWhiteSpace(txtModelo.Text))
            { MessageBox.Show("Ingrese el modelo/marca."); txtModelo.Focus(); return false; }
            return true;
        }
    }
}