namespace PryRentaAutosBarrera
{
    partial class frmReportes
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
            this.grpFiltros = new System.Windows.Forms.GroupBox();
            this.lblDesde = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.lblHasta = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.lblEstadoF = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.grpRapidos = new System.Windows.Forms.GroupBox();
            this.btnRptContratos = new System.Windows.Forms.Button();
            this.btnRptChoferes = new System.Windows.Forms.Button();
            this.btnRptCobros = new System.Windows.Forms.Button();
            this.btnRptVehiculos = new System.Windows.Forms.Button();
            this.grpResultados = new System.Windows.Forms.GroupBox();
            this.lblTituloReporte = new System.Windows.Forms.Label();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.lblResumen = new System.Windows.Forms.Label();
            this.grpFiltros.SuspendLayout();
            this.grpRapidos.SuspendLayout();
            this.grpResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFiltros
            // 
            this.grpFiltros.Controls.Add(this.lblDesde);
            this.grpFiltros.Controls.Add(this.dtpDesde);
            this.grpFiltros.Controls.Add(this.lblHasta);
            this.grpFiltros.Controls.Add(this.dtpHasta);
            this.grpFiltros.Controls.Add(this.lblEstadoF);
            this.grpFiltros.Controls.Add(this.cmbEstado);
            this.grpFiltros.Controls.Add(this.btnFiltrar);
            this.grpFiltros.Controls.Add(this.btnLimpiar);
            this.grpFiltros.Location = new System.Drawing.Point(12, 12);
            this.grpFiltros.Name = "grpFiltros";
            this.grpFiltros.Size = new System.Drawing.Size(620, 60);
            this.grpFiltros.TabIndex = 0;
            this.grpFiltros.TabStop = false;
            this.grpFiltros.Text = "Filtrar por fecha";
            // 
            // lblDesde
            // 
            this.lblDesde.AutoSize = true;
            this.lblDesde.Location = new System.Drawing.Point(8, 26);
            this.lblDesde.Name = "lblDesde";
            this.lblDesde.Size = new System.Drawing.Size(41, 13);
            this.lblDesde.TabIndex = 0;
            this.lblDesde.Text = "Desde:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(58, 23);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(110, 20);
            this.dtpDesde.TabIndex = 0;
            // 
            // lblHasta
            // 
            this.lblHasta.AutoSize = true;
            this.lblHasta.Location = new System.Drawing.Point(178, 26);
            this.lblHasta.Name = "lblHasta";
            this.lblHasta.Size = new System.Drawing.Size(38, 13);
            this.lblHasta.TabIndex = 1;
            this.lblHasta.Text = "Hasta:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(222, 23);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(110, 20);
            this.dtpHasta.TabIndex = 1;
            // 
            // lblEstadoF
            // 
            this.lblEstadoF.AutoSize = true;
            this.lblEstadoF.Location = new System.Drawing.Point(345, 26);
            this.lblEstadoF.Name = "lblEstadoF";
            this.lblEstadoF.Size = new System.Drawing.Size(43, 13);
            this.lblEstadoF.TabIndex = 2;
            this.lblEstadoF.Text = "Estado:";
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.Items.AddRange(new object[] {
            "Todos",
            "Pendiente",
            "Pagado",
            "Cancelado"});
            this.cmbEstado.Location = new System.Drawing.Point(395, 22);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(100, 21);
            this.cmbEstado.TabIndex = 2;
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.Location = new System.Drawing.Point(506, 20);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(50, 26);
            this.btnFiltrar.TabIndex = 3;
            this.btnFiltrar.Text = "Filtrar";
            this.btnFiltrar.UseVisualStyleBackColor = true;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(562, 20);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(50, 26);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // grpRapidos
            // 
            this.grpRapidos.Controls.Add(this.btnRptContratos);
            this.grpRapidos.Controls.Add(this.btnRptChoferes);
            this.grpRapidos.Controls.Add(this.btnRptCobros);
            this.grpRapidos.Controls.Add(this.btnRptVehiculos);
            this.grpRapidos.Location = new System.Drawing.Point(642, 12);
            this.grpRapidos.Name = "grpRapidos";
            this.grpRapidos.Size = new System.Drawing.Size(269, 60);
            this.grpRapidos.TabIndex = 1;
            this.grpRapidos.TabStop = false;
            this.grpRapidos.Text = "Reportes rápidos";
            // 
            // btnRptContratos
            // 
            this.btnRptContratos.Location = new System.Drawing.Point(6, 20);
            this.btnRptContratos.Name = "btnRptContratos";
            this.btnRptContratos.Size = new System.Drawing.Size(56, 30);
            this.btnRptContratos.TabIndex = 5;
            this.btnRptContratos.Text = "Contratos";
            this.btnRptContratos.UseVisualStyleBackColor = true;
            this.btnRptContratos.Click += new System.EventHandler(this.btnRptContratos_Click);
            // 
            // btnRptChoferes
            // 
            this.btnRptChoferes.Location = new System.Drawing.Point(68, 20);
            this.btnRptChoferes.Name = "btnRptChoferes";
            this.btnRptChoferes.Size = new System.Drawing.Size(56, 30);
            this.btnRptChoferes.TabIndex = 6;
            this.btnRptChoferes.Text = "Choferes";
            this.btnRptChoferes.UseVisualStyleBackColor = true;
            this.btnRptChoferes.Click += new System.EventHandler(this.btnRptChoferes_Click);
            // 
            // btnRptCobros
            // 
            this.btnRptCobros.Location = new System.Drawing.Point(130, 20);
            this.btnRptCobros.Name = "btnRptCobros";
            this.btnRptCobros.Size = new System.Drawing.Size(56, 30);
            this.btnRptCobros.TabIndex = 7;
            this.btnRptCobros.Text = "Cobros";
            this.btnRptCobros.UseVisualStyleBackColor = true;
            this.btnRptCobros.Click += new System.EventHandler(this.btnRptCobros_Click);
            // 
            // btnRptVehiculos
            // 
            this.btnRptVehiculos.Location = new System.Drawing.Point(192, 20);
            this.btnRptVehiculos.Name = "btnRptVehiculos";
            this.btnRptVehiculos.Size = new System.Drawing.Size(71, 30);
            this.btnRptVehiculos.TabIndex = 8;
            this.btnRptVehiculos.Text = "Vehículos";
            this.btnRptVehiculos.UseVisualStyleBackColor = true;
            this.btnRptVehiculos.Click += new System.EventHandler(this.btnRptVehiculos_Click);
            // 
            // grpResultados
            // 
            this.grpResultados.Controls.Add(this.lblTituloReporte);
            this.grpResultados.Controls.Add(this.dgvReporte);
            this.grpResultados.Controls.Add(this.lblResumen);
            this.grpResultados.Location = new System.Drawing.Point(12, 82);
            this.grpResultados.Name = "grpResultados";
            this.grpResultados.Size = new System.Drawing.Size(880, 370);
            this.grpResultados.TabIndex = 2;
            this.grpResultados.TabStop = false;
            this.grpResultados.Text = "Resultados";
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTituloReporte.Location = new System.Drawing.Point(6, 18);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(868, 22);
            this.lblTituloReporte.TabIndex = 0;
            this.lblTituloReporte.Text = "Historial completo de alquileres";
            this.lblTituloReporte.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.Location = new System.Drawing.Point(6, 44);
            this.dgvReporte.MultiSelect = false;
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.RowHeadersVisible = false;
            this.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporte.Size = new System.Drawing.Size(868, 300);
            this.dgvReporte.TabIndex = 0;
            this.dgvReporte.DataSourceChanged += new System.EventHandler(this.dgvReporte_DataSourceChanged);
            // 
            // lblResumen
            // 
            this.lblResumen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblResumen.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.lblResumen.Location = new System.Drawing.Point(6, 348);
            this.lblResumen.Name = "lblResumen";
            this.lblResumen.Size = new System.Drawing.Size(868, 18);
            this.lblResumen.TabIndex = 1;
            this.lblResumen.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(923, 464);
            this.Controls.Add(this.grpFiltros);
            this.Controls.Add(this.grpRapidos);
            this.Controls.Add(this.grpResultados);
            this.Name = "frmReportes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reportes";
            this.Load += new System.EventHandler(this.frmReportes_Load);
            this.grpFiltros.ResumeLayout(false);
            this.grpFiltros.PerformLayout();
            this.grpRapidos.ResumeLayout(false);
            this.grpResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox grpFiltros;
        private System.Windows.Forms.Label lblDesde;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label lblHasta;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label lblEstadoF;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.GroupBox grpRapidos;
        private System.Windows.Forms.Button btnRptContratos;
        private System.Windows.Forms.Button btnRptChoferes;
        private System.Windows.Forms.Button btnRptCobros;
        private System.Windows.Forms.Button btnRptVehiculos;
        private System.Windows.Forms.GroupBox grpResultados;
        private System.Windows.Forms.Label lblTituloReporte;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Label lblResumen;
    }
}