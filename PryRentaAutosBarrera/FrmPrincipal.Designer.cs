namespace PryRentaAutosBarrera
{
    partial class frmPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPrincipal));
            this.tabPrincipal = new System.Windows.Forms.TabControl();
            this.tabVehiculos = new System.Windows.Forms.TabPage();
            this.tabChoferes = new System.Windows.Forms.TabPage();
            this.tabContratos = new System.Windows.Forms.TabPage();
            this.tabAlquileres = new System.Windows.Forms.TabPage();
            this.tabReportes = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblEstado = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPrincipal.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.tabVehiculos);
            this.tabPrincipal.Controls.Add(this.tabChoferes);
            this.tabPrincipal.Controls.Add(this.tabContratos);
            this.tabPrincipal.Controls.Add(this.tabAlquileres);
            this.tabPrincipal.Controls.Add(this.tabReportes);
            this.tabPrincipal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabPrincipal.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabPrincipal.ItemSize = new System.Drawing.Size(130, 28);
            this.tabPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.SelectedIndex = 0;
            this.tabPrincipal.Size = new System.Drawing.Size(972, 506);
            this.tabPrincipal.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabPrincipal.TabIndex = 0;
            this.tabPrincipal.SelectedIndexChanged += new System.EventHandler(this.tabPrincipal_SelectedIndexChanged);
            // 
            // tabVehiculos
            // 
            this.tabVehiculos.BackColor = System.Drawing.Color.Transparent;
            this.tabVehiculos.Location = new System.Drawing.Point(4, 32);
            this.tabVehiculos.Name = "tabVehiculos";
            this.tabVehiculos.Padding = new System.Windows.Forms.Padding(3);
            this.tabVehiculos.Size = new System.Drawing.Size(900, 624);
            this.tabVehiculos.TabIndex = 0;
            this.tabVehiculos.Text = "🚗  Vehículos";
            this.tabVehiculos.UseVisualStyleBackColor = true;
            // 
            // tabChoferes
            // 
            this.tabChoferes.BackColor = System.Drawing.Color.Transparent;
            this.tabChoferes.Location = new System.Drawing.Point(4, 32);
            this.tabChoferes.Name = "tabChoferes";
            this.tabChoferes.Padding = new System.Windows.Forms.Padding(3);
            this.tabChoferes.Size = new System.Drawing.Size(900, 624);
            this.tabChoferes.TabIndex = 1;
            this.tabChoferes.Text = "👤  Choferes";
            this.tabChoferes.UseVisualStyleBackColor = true;
            // 
            // tabContratos
            // 
            this.tabContratos.BackColor = System.Drawing.Color.Transparent;
            this.tabContratos.Location = new System.Drawing.Point(4, 32);
            this.tabContratos.Name = "tabContratos";
            this.tabContratos.Padding = new System.Windows.Forms.Padding(3);
            this.tabContratos.Size = new System.Drawing.Size(900, 624);
            this.tabContratos.TabIndex = 2;
            this.tabContratos.Text = "📄  Contratos";
            this.tabContratos.UseVisualStyleBackColor = true;
            // 
            // tabAlquileres
            // 
            this.tabAlquileres.BackColor = System.Drawing.Color.Transparent;
            this.tabAlquileres.Location = new System.Drawing.Point(4, 32);
            this.tabAlquileres.Name = "tabAlquileres";
            this.tabAlquileres.Padding = new System.Windows.Forms.Padding(3);
            this.tabAlquileres.Size = new System.Drawing.Size(900, 624);
            this.tabAlquileres.TabIndex = 3;
            this.tabAlquileres.Text = "🔑  Alquileres";
            this.tabAlquileres.UseVisualStyleBackColor = true;
            // 
            // tabReportes
            // 
            this.tabReportes.BackColor = System.Drawing.Color.Transparent;
            this.tabReportes.Location = new System.Drawing.Point(4, 32);
            this.tabReportes.Name = "tabReportes";
            this.tabReportes.Padding = new System.Windows.Forms.Padding(3);
            this.tabReportes.Size = new System.Drawing.Size(964, 470);
            this.tabReportes.TabIndex = 4;
            this.tabReportes.Text = "📊  Reportes";
            this.tabReportes.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblEstado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 506);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(972, 22);
            this.statusStrip1.TabIndex = 1;
            // 
            // lblEstado
            // 
            this.lblEstado.ForeColor = System.Drawing.Color.Red;
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(84, 17);
            this.lblEstado.Text = "● Sin conexión";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 528);
            this.Controls.Add(this.tabPrincipal);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión de Flotas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmPrincipal_FormClosing);
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.tabPrincipal.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.TabControl tabPrincipal;
        private System.Windows.Forms.TabPage tabVehiculos;
        private System.Windows.Forms.TabPage tabChoferes;
        private System.Windows.Forms.TabPage tabContratos;
        private System.Windows.Forms.TabPage tabAlquileres;
        private System.Windows.Forms.TabPage tabReportes;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblEstado;
    }
}