using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PryRentaAutosBarrera
{
    public partial class frmContratos : Form
    {
        private readonly clsConexion _db;
        private int _idSeleccionado = 0;

        public frmContratos(clsConexion conexion)
        {
            InitializeComponent();
            _db = conexion;
        }

        private void frmContratos_Load(object sender, EventArgs e)
        {
            CargarGrilla();
            ModoAlta();
        }

        private void CargarGrilla()
        {
            dgvContratos.DataSource = _db.EjecutarConsulta(
                "SELECT Id_Contrato AS ID, Tipo, " +
                "CONVERT(varchar, Monto_Base, 1) AS [Monto Base], " +
                "Descripcion AS Descripción " +
                "FROM Contratos ORDER BY Id_Contrato");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (!Validar()) return;

            var p = new[]
            {
                new SqlParameter("@Tipo",        txtTipo.Text.Trim()),
                new SqlParameter("@MontoBase",   nudMonto.Value),
                new SqlParameter("@Descripcion", rtbDescripcion.Text.Trim())
            };

            if (_idSeleccionado == 0)
            {
                _db.EjecutarComando(
                    "INSERT INTO Contratos (Tipo, Monto_Base, Descripcion) " +
                    "VALUES (@Tipo, @MontoBase, @Descripcion)", p);
                MessageBox.Show("Contrato registrado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                var pUpd = new[] { p[0], p[1], p[2], new SqlParameter("@Id", _idSeleccionado) };
                _db.EjecutarComando(
                    "UPDATE Contratos SET Tipo=@Tipo, Monto_Base=@MontoBase, " +
                    "Descripcion=@Descripcion WHERE Id_Contrato=@Id", pUpd);
                MessageBox.Show("Contrato actualizado correctamente.", "Éxito",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            CargarGrilla();
            ModoAlta();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (_idSeleccionado == 0) { MessageBox.Show("Seleccione un contrato."); return; }

            if (MessageBox.Show("¿Eliminar el contrato seleccionado?", "Confirmar",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No) return;

            try
            {
                _db.EjecutarComando("DELETE FROM Contratos WHERE Id_Contrato = @Id",
                    new[] { new SqlParameter("@Id", _idSeleccionado) });
                MessageBox.Show("Contrato eliminado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarGrilla();
                ModoAlta();
            }
            catch
            {
                MessageBox.Show("No se puede eliminar: el contrato tiene alquileres asociados.",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e) => ModoAlta();

        private void dgvContratos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvContratos.Rows[e.RowIndex];
            _idSeleccionado = Convert.ToInt32(row.Cells["ID"].Value);
            txtTipo.Text = row.Cells["Tipo"].Value.ToString();
            rtbDescripcion.Text = row.Cells["Descripción"].Value?.ToString() ?? "";

            // Re-consultar monto original (sin formato de texto)
            var dt = _db.EjecutarConsulta(
                "SELECT Monto_Base FROM Contratos WHERE Id_Contrato = @Id",
                new[] { new SqlParameter("@Id", _idSeleccionado) });
            if (dt.Rows.Count > 0)
                nudMonto.Value = Convert.ToDecimal(dt.Rows[0]["Monto_Base"]);

            btnGuardar.Text = "Actualizar";
            btnEliminar.Enabled = true;
        }

        private void ModoAlta()
        {
            _idSeleccionado = 0;
            txtTipo.Clear(); nudMonto.Value = 0; rtbDescripcion.Clear();
            btnGuardar.Text = "Guardar";
            btnEliminar.Enabled = false;
            txtTipo.Focus();
        }

        private bool Validar()
        {
            if (string.IsNullOrWhiteSpace(txtTipo.Text))
            { MessageBox.Show("Ingrese el tipo de contrato."); txtTipo.Focus(); return false; }
            if (nudMonto.Value <= 0)
            { MessageBox.Show("El monto base debe ser mayor a 0."); nudMonto.Focus(); return false; }
            return true;
        }
    }
}