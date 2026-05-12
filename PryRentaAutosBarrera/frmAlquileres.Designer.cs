namespace PryRentaAutosBarrera
{
    partial class frmAlquileres
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            this.grpDatos = new System.Windows.Forms.GroupBox();
            this.lblVehiculo = new System.Windows.Forms.Label();
            this.cmbVehiculo = new System.Windows.Forms.ComboBox();
            this.lblChofer = new System.Windows.Forms.Label();
            this.cmbChofer = new System.Windows.Forms.ComboBox();
            this.lblContrato = new System.Windows.Forms.Label();
            this.cmbContrato = new System.Windows.Forms.ComboBox();
            this.lblFechaInicio = new System.Windows.Forms.Label();
            this.dtpFechaInicio = new System.Windows.Forms.DateTimePicker();
            this.chkFechaFin = new System.Windows.Forms.CheckBox();
            this.dtpFechaFin = new System.Windows.Forms.DateTimePicker();
            this.lblCosto = new System.Windows.Forms.Label();
            this.nudCosto = new System.Windows.Forms.NumericUpDown();
            this.lblEstadoCobro = new System.Windows.Forms.Label();
            this.cmbEstadoCobro = new System.Windows.Forms.ComboBox();
            this.grpAcciones = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.grpListado = new System.Windows.Forms.GroupBox();
            this.dgvAlquileres = new System.Windows.Forms.DataGridView();
            this.grpDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCosto)).BeginInit();
            this.grpAcciones.SuspendLayout();
            this.grpListado.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquileres)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDatos
            // 
            this.grpDatos.Controls.Add(this.lblVehiculo);
            this.grpDatos.Controls.Add(this.cmbVehiculo);
            this.grpDatos.Controls.Add(this.lblChofer);
            this.grpDatos.Controls.Add(this.cmbChofer);
            this.grpDatos.Controls.Add(this.lblContrato);
            this.grpDatos.Controls.Add(this.cmbContrato);
            this.grpDatos.Controls.Add(this.lblFechaInicio);
            this.grpDatos.Controls.Add(this.dtpFechaInicio);
            this.grpDatos.Controls.Add(this.chkFechaFin);
            this.grpDatos.Controls.Add(this.dtpFechaFin);
            this.grpDatos.Controls.Add(this.lblCosto);
            this.grpDatos.Controls.Add(this.nudCosto);
            this.grpDatos.Controls.Add(this.lblEstadoCobro);
            this.grpDatos.Controls.Add(this.cmbEstadoCobro);
            this.grpDatos.Location = new System.Drawing.Point(12, 12);
            this.grpDatos.Name = "grpDatos";
            this.grpDatos.Size = new System.Drawing.Size(560, 210);
            this.grpDatos.TabIndex = 2;
            this.grpDatos.TabStop = false;
            this.grpDatos.Text = "Datos del alquiler";
            // 
            // lblVehiculo
            // 
            this.lblVehiculo.AutoSize = true;
            this.lblVehiculo.Location = new System.Drawing.Point(10, 25);
            this.lblVehiculo.Name = "lblVehiculo";
            this.lblVehiculo.Size = new System.Drawing.Size(57, 13);
            this.lblVehiculo.TabIndex = 0;
            this.lblVehiculo.Text = "Vehículo *";
            // 
            // cmbVehiculo
            // 
            this.cmbVehiculo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVehiculo.Location = new System.Drawing.Point(160, 22);
            this.cmbVehiculo.Name = "cmbVehiculo";
            this.cmbVehiculo.Size = new System.Drawing.Size(180, 21);
            this.cmbVehiculo.TabIndex = 0;
            // 
            // lblChofer
            // 
            this.lblChofer.AutoSize = true;
            this.lblChofer.Location = new System.Drawing.Point(10, 59);
            this.lblChofer.Name = "lblChofer";
            this.lblChofer.Size = new System.Drawing.Size(45, 13);
            this.lblChofer.TabIndex = 1;
            this.lblChofer.Text = "Chofer *";
            // 
            // cmbChofer
            // 
            this.cmbChofer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChofer.Location = new System.Drawing.Point(160, 56);
            this.cmbChofer.Name = "cmbChofer";
            this.cmbChofer.Size = new System.Drawing.Size(180, 21);
            this.cmbChofer.TabIndex = 1;
            // 
            // lblContrato
            // 
            this.lblContrato.AutoSize = true;
            this.lblContrato.Location = new System.Drawing.Point(10, 93);
            this.lblContrato.Name = "lblContrato";
            this.lblContrato.Size = new System.Drawing.Size(54, 13);
            this.lblContrato.TabIndex = 2;
            this.lblContrato.Text = "Contrato *";
            // 
            // cmbContrato
            // 
            this.cmbContrato.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbContrato.Location = new System.Drawing.Point(160, 90);
            this.cmbContrato.Name = "cmbContrato";
            this.cmbContrato.Size = new System.Drawing.Size(180, 21);
            this.cmbContrato.TabIndex = 2;
            this.cmbContrato.SelectedIndexChanged += new System.EventHandler(this.cmbContrato_SelectedIndexChanged);
            // 
            // lblFechaInicio
            // 
            this.lblFechaInicio.AutoSize = true;
            this.lblFechaInicio.Location = new System.Drawing.Point(10, 127);
            this.lblFechaInicio.Name = "lblFechaInicio";
            this.lblFechaInicio.Size = new System.Drawing.Size(72, 13);
            this.lblFechaInicio.TabIndex = 3;
            this.lblFechaInicio.Text = "Fecha Inicio *";
            // 
            // dtpFechaInicio
            // 
            this.dtpFechaInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaInicio.Location = new System.Drawing.Point(160, 124);
            this.dtpFechaInicio.Name = "dtpFechaInicio";
            this.dtpFechaInicio.Size = new System.Drawing.Size(130, 20);
            this.dtpFechaInicio.TabIndex = 3;
            // 
            // chkFechaFin
            // 
            this.chkFechaFin.AutoSize = true;
            this.chkFechaFin.Location = new System.Drawing.Point(300, 127);
            this.chkFechaFin.Name = "chkFechaFin";
            this.chkFechaFin.Size = new System.Drawing.Size(73, 17);
            this.chkFechaFin.TabIndex = 4;
            this.chkFechaFin.Text = "Fecha Fin";
            this.chkFechaFin.CheckedChanged += new System.EventHandler(this.chkFechaFin_CheckedChanged);
            // 
            // dtpFechaFin
            // 
            this.dtpFechaFin.Enabled = false;
            this.dtpFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFin.Location = new System.Drawing.Point(430, 124);
            this.dtpFechaFin.Name = "dtpFechaFin";
            this.dtpFechaFin.Size = new System.Drawing.Size(120, 20);
            this.dtpFechaFin.TabIndex = 5;
            // 
            // lblCosto
            // 
            this.lblCosto.AutoSize = true;
            this.lblCosto.Location = new System.Drawing.Point(10, 163);
            this.lblCosto.Name = "lblCosto";
            this.lblCosto.Size = new System.Drawing.Size(76, 13);
            this.lblCosto.TabIndex = 6;
            this.lblCosto.Text = "Costo Total ($)";
            // 
            // nudCosto
            // 
            this.nudCosto.DecimalPlaces = 2;
            this.nudCosto.Location = new System.Drawing.Point(160, 160);
            this.nudCosto.Maximum = new decimal(new int[] {
            99999999,
            0,
            0,
            0});
            this.nudCosto.Name = "nudCosto";
            this.nudCosto.Size = new System.Drawing.Size(130, 20);
            this.nudCosto.TabIndex = 6;
            this.nudCosto.ThousandsSeparator = true;
            // 
            // lblEstadoCobro
            // 
            this.lblEstadoCobro.AutoSize = true;
            this.lblEstadoCobro.Location = new System.Drawing.Point(300, 163);
            this.lblEstadoCobro.Name = "lblEstadoCobro";
            this.lblEstadoCobro.Size = new System.Drawing.Size(71, 13);
            this.lblEstadoCobro.TabIndex = 7;
            this.lblEstadoCobro.Text = "Estado Cobro";
            // 
            // cmbEstadoCobro
            // 
            this.cmbEstadoCobro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstadoCobro.Location = new System.Drawing.Point(390, 160);
            this.cmbEstadoCobro.Name = "cmbEstadoCobro";
            this.cmbEstadoCobro.Size = new System.Drawing.Size(130, 21);
            this.cmbEstadoCobro.TabIndex = 7;
            // 
            // grpAcciones
            // 
            this.grpAcciones.Controls.Add(this.btnGuardar);
            this.grpAcciones.Controls.Add(this.btnNuevo);
            this.grpAcciones.Controls.Add(this.btnEliminar);
            this.grpAcciones.Location = new System.Drawing.Point(580, 12);
            this.grpAcciones.Name = "grpAcciones";
            this.grpAcciones.Size = new System.Drawing.Size(120, 210);
            this.grpAcciones.TabIndex = 1;
            this.grpAcciones.TabStop = false;
            this.grpAcciones.Text = "Acciones";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(10, 30);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 30);
            this.btnGuardar.TabIndex = 0;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(10, 75);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(100, 30);
            this.btnNuevo.TabIndex = 1;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Enabled = false;
            this.btnEliminar.Location = new System.Drawing.Point(10, 120);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(100, 30);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // grpListado
            // 
            this.grpListado.Controls.Add(this.dgvAlquileres);
            this.grpListado.Location = new System.Drawing.Point(12, 232);
            this.grpListado.Name = "grpListado";
            this.grpListado.Size = new System.Drawing.Size(880, 230);
            this.grpListado.TabIndex = 0;
            this.grpListado.TabStop = false;
            this.grpListado.Text = "Historial de alquileres";
            // 
            // dgvAlquileres
            // 
            this.dgvAlquileres.AllowUserToAddRows = false;
            this.dgvAlquileres.AllowUserToDeleteRows = false;
            this.dgvAlquileres.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAlquileres.Location = new System.Drawing.Point(3, 16);
            this.dgvAlquileres.MultiSelect = false;
            this.dgvAlquileres.Name = "dgvAlquileres";
            this.dgvAlquileres.ReadOnly = true;
            this.dgvAlquileres.RowHeadersVisible = false;
            this.dgvAlquileres.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAlquileres.Size = new System.Drawing.Size(874, 211);
            this.dgvAlquileres.TabIndex = 0;
            this.dgvAlquileres.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAlquileres_CellClick);
            // 
            // frmAlquileres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 478);
            this.Controls.Add(this.grpListado);
            this.Controls.Add(this.grpAcciones);
            this.Controls.Add(this.grpDatos);
            this.Name = "frmAlquileres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gestión de Alquileres";
            this.Load += new System.EventHandler(this.frmAlquileres_Load);
            this.grpDatos.ResumeLayout(false);
            this.grpDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCosto)).EndInit();
            this.grpAcciones.ResumeLayout(false);
            this.grpListado.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAlquileres)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox grpDatos;
        private System.Windows.Forms.Label lblVehiculo, lblChofer, lblContrato;
        private System.Windows.Forms.Label lblFechaInicio, lblCosto, lblEstadoCobro;
        private System.Windows.Forms.ComboBox cmbVehiculo, cmbChofer, cmbContrato, cmbEstadoCobro;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio, dtpFechaFin;
        private System.Windows.Forms.CheckBox chkFechaFin;
        private System.Windows.Forms.NumericUpDown nudCosto;
        private System.Windows.Forms.GroupBox grpAcciones;
        private System.Windows.Forms.Button btnGuardar, btnNuevo, btnEliminar;
        private System.Windows.Forms.GroupBox grpListado;
        private System.Windows.Forms.DataGridView dgvAlquileres;
    }
}