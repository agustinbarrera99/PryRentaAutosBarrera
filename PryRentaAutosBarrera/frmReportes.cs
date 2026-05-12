using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PryRentaAutosBarrera
{
    public partial class frmReportes : Form
    {
        private readonly clsConexion _db;

        public frmReportes(clsConexion conexion)
        {
            InitializeComponent();
            _db = conexion;
        }

        private void frmReportes_Load(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpHasta.Value = DateTime.Today;
            CargarReporteGeneral();
        }

        // ── Reporte general (sin filtros) ────────────────────────
        private void CargarReporteGeneral()
        {
            dgvReporte.DataSource = _db.EjecutarConsulta(
                "SELECT Id_Alquiler AS ID, Patente, Modelo_Marca AS [Modelo/Marca], " +
                "Chofer, TipoContrato AS Contrato, " +
                "CONVERT(varchar, Fecha_Inicio, 103) AS [F. Inicio], " +
                "ISNULL(CONVERT(varchar, Fecha_Fin, 103), '—') AS [F. Fin], " +
                "Costo_Total AS [Costo ($)], Estado_Cobro AS [Estado Cobro] " +
                "FROM vw_AlquileresDetalle ORDER BY Fecha_Inicio DESC");

            lblTituloReporte.Text = "Historial completo de alquileres";
            ActualizarResumen();
        }

        // ── Filtrar por rango de fechas ──────────────────────────
        private void btnFiltrar_Click(object sender, EventArgs e)
        {
            if (dtpDesde.Value > dtpHasta.Value)
            {
                MessageBox.Show("La fecha 'Desde' no puede ser mayor que 'Hasta'.",
                    "Rango inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var p = new[]
            {
                new SqlParameter("@Desde", dtpDesde.Value.Date),
                new SqlParameter("@Hasta", dtpHasta.Value.Date)
            };

            string filtroEstado = cmbEstado.SelectedIndex > 0
                ? $"AND Estado_Cobro = '{cmbEstado.Text}'"
                : "";

            dgvReporte.DataSource = _db.EjecutarConsulta(
                "SELECT Id_Alquiler AS ID, Patente, Modelo_Marca AS [Modelo/Marca], " +
                "Chofer, TipoContrato AS Contrato, " +
                "CONVERT(varchar, Fecha_Inicio, 103) AS [F. Inicio], " +
                "ISNULL(CONVERT(varchar, Fecha_Fin, 103), '—') AS [F. Fin], " +
                "Costo_Total AS [Costo ($)], Estado_Cobro AS [Estado Cobro] " +
                "FROM vw_AlquileresDetalle " +
                $"WHERE Fecha_Inicio >= @Desde AND Fecha_Inicio <= @Hasta {filtroEstado} " +
                "ORDER BY Fecha_Inicio DESC", p);

            ActualizarResumen();
        }

        // ── Limpiar filtros ──────────────────────────────────────
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            dtpDesde.Value = new DateTime(DateTime.Today.Year, 1, 1);
            dtpHasta.Value = DateTime.Today;
            cmbEstado.SelectedIndex = 0;
            CargarReporteGeneral();
        }

        // ── Reporte: Ingresos por contrato ───────────────────────
        private void btnRptContratos_Click(object sender, EventArgs e)
        {
            dgvReporte.DataSource = _db.EjecutarConsulta(
                "SELECT ct.Tipo AS Contrato, " +
                "COUNT(*) AS [Cant. Alquileres], " +
                "SUM(ar.Costo_Total) AS [Total ($)] " +
                "FROM Alquileres_Registros ar " +
                "INNER JOIN Contratos ct ON ar.Id_Contratos = ct.Id_Contrato " +
                "GROUP BY ct.Tipo ORDER BY [Total ($)] DESC");
            lblTituloReporte.Text = "Ingresos por tipo de contrato";
        }

        // ── Reporte: Alquileres por chofer ───────────────────────
        private void btnRptChoferes_Click(object sender, EventArgs e)
        {
            dgvReporte.DataSource = _db.EjecutarConsulta(
                "SELECT c.Nombre_Completo AS Chofer, " +
                "COUNT(*) AS [Cant. Alquileres], " +
                "SUM(ar.Costo_Total) AS [Total Facturado ($)] " +
                "FROM Alquileres_Registros ar " +
                "INNER JOIN Choferes c ON ar.Id_Chofer = c.Id_Chofer " +
                "GROUP BY c.Nombre_Completo ORDER BY [Cant. Alquileres] DESC");
            lblTituloReporte.Text = "Alquileres por chofer";
        }

        // ── Reporte: Estado de cobro ─────────────────────────────
        private void btnRptCobros_Click(object sender, EventArgs e)
        {
            dgvReporte.DataSource = _db.EjecutarConsulta(
                "SELECT " +
                "CASE Estado_Cobro WHEN 0 THEN 'Pendiente' WHEN 1 THEN 'Pagado' WHEN 2 THEN 'Cancelado' END AS Estado, " +
                "COUNT(*) AS Cantidad, " +
                "SUM(Costo_Total) AS [Monto Total ($)] " +
                "FROM Alquileres_Registros " +
                "GROUP BY Estado_Cobro ORDER BY Estado_Cobro");
            lblTituloReporte.Text = "Resumen por estado de cobro";
        }

        // ── Reporte: Vehículos más alquilados ────────────────────
        private void btnRptVehiculos_Click(object sender, EventArgs e)
        {
            dgvReporte.DataSource = _db.EjecutarConsulta(
                "SELECT v.Patente, v.Modelo_Marca AS [Modelo/Marca], " +
                "COUNT(*) AS [Veces alquilado], " +
                "SUM(ar.Costo_Total) AS [Total generado ($)] " +
                "FROM Alquileres_Registros ar " +
                "INNER JOIN Vehiculos v ON ar.Id_Vehiculo = v.Id_Vehiculo " +
                "GROUP BY v.Patente, v.Modelo_Marca " +
                "ORDER BY [Veces alquilado] DESC");
            lblTituloReporte.Text = "Vehículos más alquilados";
        }

        // ── Totales en pie de grilla ─────────────────────────────
        private void ActualizarResumen()
        {
            var dt = dgvReporte.DataSource as DataTable;
            if (dt == null) return;

            int cant = dt.Rows.Count;
            decimal total = 0;
            if (dt.Columns.Contains("Costo ($)"))
                foreach (DataRow row in dt.Rows)
                    if (row["Costo ($)"] != DBNull.Value)
                        total += Convert.ToDecimal(row["Costo ($)"]);

            lblResumen.Text = $"Registros: {cant}   |   Total: $ {total:N2}";
        }

        private void dgvReporte_DataSourceChanged(object sender, EventArgs e)
            => ActualizarResumen();
    }
}