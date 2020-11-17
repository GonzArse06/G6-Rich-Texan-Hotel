namespace NLayer.Formularios
{
    partial class FrmReporteHabitaciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lstHabitaciones = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCategoria = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCantidadPlaza = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCancelacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chPrecio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblResultado = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblIdHotel = new System.Windows.Forms.Label();
            this.cbxHoteles = new System.Windows.Forms.ComboBox();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.btnExportarExcel = new FontAwesome.Sharp.IconButton();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstHabitaciones
            // 
            this.lstHabitaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstHabitaciones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chCategoria,
            this.chCantidadPlaza,
            this.chCancelacion,
            this.chPrecio});
            this.lstHabitaciones.FullRowSelect = true;
            this.lstHabitaciones.HideSelection = false;
            this.lstHabitaciones.Location = new System.Drawing.Point(12, 66);
            this.lstHabitaciones.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lstHabitaciones.Name = "lstHabitaciones";
            this.lstHabitaciones.Size = new System.Drawing.Size(906, 457);
            this.lstHabitaciones.TabIndex = 4;
            this.lstHabitaciones.UseCompatibleStateImageBehavior = false;
            this.lstHabitaciones.View = System.Windows.Forms.View.Details;
            // 
            // chId
            // 
            this.chId.Text = "Id";
            this.chId.Width = 40;
            // 
            // chCategoria
            // 
            this.chCategoria.Text = "Categoria";
            this.chCategoria.Width = 90;
            // 
            // chCantidadPlaza
            // 
            this.chCantidadPlaza.Text = "Cantidad de Plazas";
            this.chCantidadPlaza.Width = 161;
            // 
            // chCancelacion
            // 
            this.chCancelacion.Text = "Cancelacion";
            this.chCancelacion.Width = 182;
            // 
            // chPrecio
            // 
            this.chPrecio.Text = "Precio";
            this.chPrecio.Width = 138;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblResultado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 632);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(930, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblResultado
            // 
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 16);
            // 
            // lblIdHotel
            // 
            this.lblIdHotel.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdHotel.Location = new System.Drawing.Point(12, 23);
            this.lblIdHotel.Name = "lblIdHotel";
            this.lblIdHotel.Size = new System.Drawing.Size(81, 26);
            this.lblIdHotel.TabIndex = 8;
            this.lblIdHotel.Text = "Hotel";
            // 
            // cbxHoteles
            // 
            this.cbxHoteles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxHoteles.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxHoteles.FormattingEnabled = true;
            this.cbxHoteles.Location = new System.Drawing.Point(99, 18);
            this.cbxHoteles.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbxHoteles.Name = "cbxHoteles";
            this.cbxHoteles.Size = new System.Drawing.Size(228, 30);
            this.cbxHoteles.TabIndex = 9;
            this.cbxHoteles.SelectedIndexChanged += new System.EventHandler(this.cbxHoteles_SelectedIndexChanged);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCerrar.IconColor = System.Drawing.Color.Black;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 28;
            this.btnCerrar.Location = new System.Drawing.Point(865, 11);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(53, 38);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Visible = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnExportarExcel.IconColor = System.Drawing.Color.Black;
            this.btnExportarExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportarExcel.Location = new System.Drawing.Point(699, 553);
            this.btnExportarExcel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(219, 62);
            this.btnExportarExcel.TabIndex = 12;
            this.btnExportarExcel.Text = "EXPORTAR A EXCEL";
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // FrmReporteHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 654);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.cbxHoteles);
            this.Controls.Add(this.lblIdHotel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lstHabitaciones);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmReporteHabitaciones";
            this.Text = "Reporte de Habitaciones";
            this.Load += new System.EventHandler(this.FrmHabitacion_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lstHabitaciones;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chCategoria;
        private System.Windows.Forms.ColumnHeader chCantidadPlaza;
        private System.Windows.Forms.ColumnHeader chCancelacion;
        private System.Windows.Forms.ColumnHeader chPrecio;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblResultado;
        private System.Windows.Forms.Label lblIdHotel;
        private System.Windows.Forms.ComboBox cbxHoteles;
        private FontAwesome.Sharp.IconButton btnExportarExcel;
    }
}