using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PryRentaAutosBarrera
{
    public partial class frmAlquileres : Form
    {
        private readonly clsConexion _db;
        private int _idSeleccionado = 0;

        public frmAlquileres(clsConexion conexion)
        {
            InitializeComponent();
            _db = conexion;
        }

        private void frmAlquileres_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarGrilla();
            ModoAlta();
        }

        // ── Carga de combos ──────────────────────────────────────
        private void CargarCombos()
        {
            // Vehículos disponibles
            var dtV = _db.EjecutarConsulta(
                "SELECT Id_Vehiculo, Patente + ' - ' + Modelo_Marca AS Descripcion " +
                "FROM Vehiculos WHERE Estado = 1 ORDER BY Patente");
            cmbVehiculo.DataSource = dtV;
            cmbVehiculo.DisplayMember = "Descripcion";
            cmbVehiculo.ValueMember = "Id_Vehiculo";
            cmbVehiculo.SelectedIndex = -1;

            // Choferes
            var dtC = _db.EjecutarConsulta(
                "SELECT Id_Chofer, Nombre_Completo FROM Choferes ORDER BY Nombre_Completo");
            cmbChofer.DataSource = dtC;
            cmbChofer.DisplayMember = "Nombre_Completo";
            cmbChofer.ValueMember = "Id_Chofer";
            cmbChofer.SelectedIndex = -1;

            // Contratos
            var dtCt = _db.EjecutarConsulta(
                "SELECT Id_Contrato, Tipo + ' ($' + CONVERT(varchar,Monto_Base,1) + ')' AS Descripcion, Monto_Base " +
                "FROM Contratos ORDER BY Tipo");
            cmbContrato.DataSource = dtCt;
            cmbContrato.DisplayMember = "Descripcion";
            cmbContrato.ValueMember = "Id_Contrato";
            cmbContrato.SelectedIndex = -1;

            // Estado de cobro
            cmbEstadoCobro.Items.Clear();
            cmbEstadoCobro.Items.AddRange(new object[] { "Pendiente", "Pagado", "Cancelado" });
            cmbEstadoCobro.SelectedIndex = 0;
        }

        // ── Carga grilla ─────────────────────────────────────────
        private void CargarGrilla()
        {
            dgvAlquileres.DataSource = _db.EjecutarConsulta(
                "SELECT Id_Alquiler AS ID, Patente, Modelo_Marca AS [Modelo/Marca], Chofer, " +
                "TipoContrato AS Contrato, " +
                "CONVERT(varchar, Fecha_Inicio, 103) AS [F. Inicio], " +
                "ISNULL(CONVERT(varchar, Fecha_Fin, 103), '—') AS [F. Fin], " +
                "Costo_Total AS [Costo ($)], Estado_Cobro AS [Estado Cobro] " +
                "FROM vw_AlquileresDetalle ORDER BY Id_Alquiler DESC");
        }

        // ── Guardar ──────────────────────────────────────────────
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            int estadoCobro = cmbEstadoCobro.SelectedIndex; // 0,1,2

            var p = new[]
            {
                new SqlParameter("@IdVehiculo",  cmbVehiculo.SelectedValue),
                new SqlParameter("@IdChofer",    cmbChofer.SelectedValue),
                new SqlParameter("@IdContrato",  cmbContrato.SelectedValue),
                new SqlParameter("@FechaInicio", dtpFechaInicio.Value.Date),
                new SqlParameter("@FechaFin",    chkFechaFin.Checked ? (object)dtpFechaFin.Value.Date : DBNull.Value),
                new SqlParameter("@CostoTotal",  nudCosto.Value),
                new SqlParameter("@EstadoCobro", estadoCobro)
            };

            if (_idSeleccionado == 0)
            {
                _db.EjecutarComando(
                    "INSERT INTO Alquileres_Registros " +
                    "(Id_Vehiculo, Id_Chofer, Id_Contratos, Fecha_Inicio, Fecha_Fin, Costo_Total, Estado_Cobro) " +
                    "VALUES (@IdVehiculo, @IdChofer, @IdContrato, @FechaInicio, @FechaFin, @CostoTotal, @EstadoCobro)", p);
                MessageBox.Show("Alquiler registrado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var pUpd = new[]
                {
                    p[0], p[1], p[2], p[3], p[4], p[5], p[6],
                    new SqlParameter("@Id", _idSeleccionado)
                };
                _db.EjecutarComando(
                    "UPDATE Alquileres_Registros SET Id_Vehiculo=@IdVehiculo, Id_Chofer=@IdChofer, " +
                    "Id_Contratos=@IdContrato, Fecha_Inicio=@FechaInicio, Fecha_Fin=@FechaFin, " +
                    "Costo_Total=@CostoTotal, Estado_Cobro=@EstadoCobro WHERE Id_Alquiler=@Id", pUpd);
                MessageBox.Show("Alquiler actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarGrilla();
            ModoAlta();
        }

        // ── Eliminar ─────────────────────────────────────────────
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0) { MessageBox.Show("Seleccione un alquiler."); return; }

            if (MessageBox.Show("¿Eliminar el alquiler seleccionado?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            _db.EjecutarComando("DELETE FROM Alquileres_Registros WHERE Id_Alquiler = @Id",
                new[] { new SqlParameter("@Id", _idSeleccionado) });
            MessageBox.Show("Alquiler eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            CargarGrilla();
            ModoAlta();
        }

        private void btnNuevo_Click(object sender, EventArgs e) => ModoAlta();

        // ── Auto-completar costo al seleccionar contrato ─────────
        private void cmbContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbContrato.SelectedValue == null || cmbContrato.SelectedIndex < 0) return;
            var dt = (DataTable)cmbContrato.DataSource;
            var row = dt.Rows[cmbContrato.SelectedIndex];
            nudCosto.Value = Convert.ToDecimal(row["Monto_Base"]);
        }

        // ── Selección en grilla ──────────────────────────────────
        private void dgvAlquileres_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvAlquileres.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(row.Cells["ID"].Value);

            // Re-consultar fila completa para cargar IDs en combos
            var dt = _db.EjecutarConsulta(
                "SELECT * FROM Alquileres_Registros WHERE Id_Alquiler = @Id",
                new[] { new SqlParameter("@Id", _idSeleccionado) });

            if (dt.Rows.Count == 0) return;
            var r = dt.Rows[0];

            cmbVehiculo.SelectedValue = r["Id_Vehiculo"];
            cmbChofer.SelectedValue = r["Id_Chofer"];
            cmbContrato.SelectedValue = r["Id_Contratos"];
            dtpFechaInicio.Value = Convert.ToDateTime(r["Fecha_Inicio"]);
            nudCosto.Value = Convert.ToDecimal(r["Costo_Total"]);
            cmbEstadoCobro.SelectedIndex = Convert.ToInt32(r["Estado_Cobro"]);

            if (r["Fecha_Fin"] != DBNull.Value)
            { chkFechaFin.Checked = true; dtpFechaFin.Value = Convert.ToDateTime(r["Fecha_Fin"]); }
            else chkFechaFin.Checked = false;

            btnGuardar.Text = "Actualizar";
            btnEliminar.Enabled = true;
        }

        private void chkFechaFin_CheckedChanged(object sender, EventArgs e)
            => dtpFechaFin.Enabled = chkFechaFin.Checked;

        // ── Helpers ──────────────────────────────────────────────
        private void ModoAlta()
        {
            _idSeleccionado = 0;
            cmbVehiculo.SelectedIndex = -1;
            cmbChofer.SelectedIndex = -1;
            cmbContrato.SelectedIndex = -1;
            dtpFechaInicio.Value = DateTime.Today;
            chkFechaFin.Checked = false;
            dtpFechaFin.Value = DateTime.Today;
            dtpFechaFin.Enabled = false;
            nudCosto.Value = 0;
            cmbEstadoCobro.SelectedIndex = 0;
            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false;
        }

        private bool Validar()
        {
            if (cmbVehiculo.SelectedIndex < 0)
            { MessageBox.Show("Seleccione un vehículo."); cmbVehiculo.Focus(); return false; }
            if (cmbChofer.SelectedIndex < 0)
            { MessageBox.Show("Seleccione un chofer."); cmbChofer.Focus(); return false; }
            if (cmbContrato.SelectedIndex < 0)
            { MessageBox.Show("Seleccione un contrato."); cmbContrato.Focus(); return false; }
            return true;
        }
    }
}