using System;
using System.Windows.Forms;
using PryRentaAutosBarrera.Controllers;
using PryRentaAutosBarrera.Entities;

namespace PryRentaAutosBarrera.Forms
{
    public partial class FrmVehiculoDetalle : Form
    {
        private readonly VehiculoController _controller;
        private Vehiculo _vehiculo;
        private bool _esEdicion;

        // ─── CONSTRUCTOR NUEVO ───────────────────────────────────────
        public FrmVehiculoDetalle()
        {
            InitializeComponent();
            _controller = new VehiculoController();
            _esEdicion = false;

            this.Load += FrmVehiculoDetalle_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        // ─── CONSTRUCTOR EDITAR ──────────────────────────────────────
        public FrmVehiculoDetalle(Vehiculo vehiculo)
        {
            InitializeComponent();
            _controller = new VehiculoController();
            _vehiculo = vehiculo;
            _esEdicion = true;

            this.Load += FrmVehiculoDetalle_Load;
            btnGuardar.Click += btnGuardar_Click;
            btnCancelar.Click += btnCancelar_Click;
        }

        // ─── CARGA INICIAL ───────────────────────────────────────────
        private void FrmVehiculoDetalle_Load(object sender, EventArgs e)
        {
            cmbEstado.DataSource = Enum.GetValues(typeof(EstadoVehiculo));

            if (_esEdicion)
            {
                this.Text = "Editar Vehículo";
                txtPatente.Text = _vehiculo.Patente;
                txtMarca.Text = _vehiculo.Marca;
                txtModelo.Text = _vehiculo.Modelo;
                txtAnio.Text = _vehiculo.Anio.ToString();
                txtColor.Text = _vehiculo.Color;
                txtPrecio.Text = _vehiculo.PrecioPorDia.ToString();
                cmbEstado.SelectedItem = _vehiculo.Estado;
            }
            else
            {
                this.Text = "Nuevo Vehículo";
                cmbEstado.SelectedIndex = 0;
            }
        }

        // ─── GUARDAR ─────────────────────────────────────────────────
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(txtAnio.Text, out int anio))
                {
                    MessageBox.Show("El año debe ser un número entero.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAnio.Focus();
                    return;
                }

                if (!decimal.TryParse(txtPrecio.Text, out decimal precio))
                {
                    MessageBox.Show("El precio debe ser un número válido.",
                        "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPrecio.Focus();
                    return;
                }

                var vehiculo = new Vehiculo
                {
                    Patente = txtPatente.Text.Trim().ToUpper(),
                    Marca = txtMarca.Text.Trim(),
                    Modelo = txtModelo.Text.Trim(),
                    Anio = anio,
                    Color = txtColor.Text.Trim(),
                    PrecioPorDia = precio,
                    Estado = (EstadoVehiculo)cmbEstado.SelectedItem,
                    Activo = true
                };

                if (_esEdicion)
                {
                    vehiculo.Id = _vehiculo.Id;
                    _controller.Editar(vehiculo);
                    MessageBox.Show("Vehículo actualizado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    _controller.Agregar(vehiculo);
                    MessageBox.Show("Vehículo agregado correctamente.",
                        "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ─── CANCELAR ────────────────────────────────────────────────
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}