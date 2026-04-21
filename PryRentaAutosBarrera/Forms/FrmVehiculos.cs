using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using PryRentaAutosBarrera.Controllers;
using PryRentaAutosBarrera.Entities;

namespace PryRentaAutosBarrera.Forms
{
    public partial class FrmVehiculos : Form
    {
        private readonly VehiculoController _controller;
        private List<Vehiculo> _listaVehiculos;

        public FrmVehiculos()
        {
            InitializeComponent();
            _controller = new VehiculoController();

            // Conectar eventos manualmente
            this.Load += FrmVehiculos_Load;
            btnBuscar.Click += btnBuscar_Click;
            btnNuevo.Click += btnNuevo_Click;
            btnEditar.Click += btnEditar_Click;
            btnEliminar.Click += btnEliminar_Click;
        }

        private void FrmVehiculos_Load(object sender, EventArgs e)
        {
            CargarGrilla();
        }

        private void CargarGrilla(string filtro = "")
        {
            try
            {
                _listaVehiculos = _controller.ObtenerTodos();

                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    _listaVehiculos = _listaVehiculos
                        .Where(v => v.Patente.ToUpper().Contains(filtro.ToUpper()) ||
                                    v.Marca.ToUpper().Contains(filtro.ToUpper()) ||
                                    v.Modelo.ToUpper().Contains(filtro.ToUpper()))
                        .ToList();
                }

                dgvVehiculos.DataSource = _listaVehiculos.Select(v => new
                {
                    v.Id,
                    v.Patente,
                    v.Marca,
                    v.Modelo,
                    v.Anio,
                    v.Color,
                    PrecioPorDia = v.PrecioPorDia.ToString("C2"),
                    Estado = v.Estado.ToString()
                }).ToList();

                dgvVehiculos.Columns["Id"].HeaderText = "ID";
                dgvVehiculos.Columns["Patente"].HeaderText = "Patente";
                dgvVehiculos.Columns["Marca"].HeaderText = "Marca";
                dgvVehiculos.Columns["Modelo"].HeaderText = "Modelo";
                dgvVehiculos.Columns["Anio"].HeaderText = "Año";
                dgvVehiculos.Columns["Color"].HeaderText = "Color";
                dgvVehiculos.Columns["PrecioPorDia"].HeaderText = "Precio/Día";
                dgvVehiculos.Columns["Estado"].HeaderText = "Estado";
                dgvVehiculos.Columns["Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar vehículos: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            CargarGrilla(txtBuscar.Text);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmVehiculoDetalle x = new FrmVehiculoDetalle();
            x.ShowDialog();
            CargarGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvVehiculos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un vehículo para editar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = ObtenerIdSeleccionado();
            var vehiculo = _controller.ObtenerPorId(id);

            FrmVehiculoDetalle x = new FrmVehiculoDetalle(vehiculo);
            x.ShowDialog();
            CargarGrilla();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvVehiculos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Seleccioná un vehículo para eliminar.",
                    "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show(
                "¿Estás seguro que querés eliminar este vehículo?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (resultado == DialogResult.Yes)
            {
                try
                {
                    int id = ObtenerIdSeleccionado();
                    _controller.Eliminar(id);
                    MessageBox.Show("Vehículo eliminado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarGrilla();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al eliminar: {ex.Message}",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int ObtenerIdSeleccionado()
        {
            int index = dgvVehiculos.SelectedRows[0].Index;
            return _listaVehiculos[index].Id;
        }
    }
}