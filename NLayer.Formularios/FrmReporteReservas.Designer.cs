namespace NLayer.Formularios
{
    partial class FrmReporteReservas
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
            this.lstReporte = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFechaIngreso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFechaEgreso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chHabitacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCantidadHuespedes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChPrecio = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtIdCliente = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblResultado = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.btnExportarExcel = new FontAwesome.Sharp.IconButton();
            this.lblIidCliente = new System.Windows.Forms.Label();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.btnBuscar = new FontAwesome.Sharp.IconButton();
            this.lblImporteTotal = new System.Windows.Forms.Label();
            this.txtImporteTotal = new System.Windows.Forms.TextBox();
            this.btnEjecutar = new FontAwesome.Sharp.IconButton();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstReporte
            // 
            this.lstReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstReporte.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chFechaIngreso,
            this.chFechaEgreso,
            this.chHabitacion,
            this.columnHeader1,
            this.chCantidadHuespedes,
            this.ChPrecio});
            this.lstReporte.FullRowSelect = true;
            this.lstReporte.HideSelection = false;
            this.lstReporte.Location = new System.Drawing.Point(21, 79);
            this.lstReporte.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstReporte.Name = "lstReporte";
            this.lstReporte.Size = new System.Drawing.Size(780, 249);
            this.lstReporte.TabIndex = 4;
            this.lstReporte.UseCompatibleStateImageBehavior = false;
            this.lstReporte.View = System.Windows.Forms.View.Details;
            this.lstReporte.SelectedIndexChanged += new System.EventHandler(this.lstReporte_SelectedIndexChanged);
            // 
            // chId
            // 
            this.chId.Text = "Id Reserva";
            this.chId.Width = 92;
            // 
            // chFechaIngreso
            // 
            this.chFechaIngreso.Text = "Fecha de Ingreso";
            this.chFechaIngreso.Width = 120;
            // 
            // chFechaEgreso
            // 
            this.chFechaEgreso.Text = "Fecha de Egreso";
            this.chFechaEgreso.Width = 120;
            // 
            // chHabitacion
            // 
            this.chHabitacion.Text = "Nro Habitacion";
            this.chHabitacion.Width = 159;
            // 
            // chCantidadHuespedes
            // 
            this.chCantidadHuespedes.Text = "Cantidad de huespedes";
            this.chCantidadHuespedes.Width = 132;
            // 
            // ChPrecio
            // 
            this.ChPrecio.Text = "Precio estadia completa";
            this.ChPrecio.Width = 169;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(83, 9);
            this.txtIdCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.Size = new System.Drawing.Size(121, 25);
            this.txtIdCliente.TabIndex = 5;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblResultado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 441);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(828, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblResultado
            // 
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 17);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCerrar.IconColor = System.Drawing.Color.Black;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 28;
            this.btnCerrar.Location = new System.Drawing.Point(761, 9);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(40, 31);
            this.btnCerrar.TabIndex = 12;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnExportarExcel.IconColor = System.Drawing.Color.Black;
            this.btnExportarExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportarExcel.Location = new System.Drawing.Point(637, 345);
            this.btnExportarExcel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Size = new System.Drawing.Size(164, 50);
            this.btnExportarExcel.TabIndex = 11;
            this.btnExportarExcel.Text = "EXPORTAR A EXCEL";
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // lblIidCliente
            // 
            this.lblIidCliente.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIidCliente.Location = new System.Drawing.Point(9, 11);
            this.lblIidCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIidCliente.Name = "lblIidCliente";
            this.lblIidCliente.Size = new System.Drawing.Size(70, 19);
            this.lblIidCliente.TabIndex = 25;
            this.lblIidCliente.Text = "Id Cliente";
            // 
            // lblNombre
            // 
            this.lblNombre.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(9, 38);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(70, 19);
            this.lblNombre.TabIndex = 27;
            this.lblNombre.Text = "Nombre";
            // 
            // txtNombreCliente
            // 
            this.txtNombreCliente.Enabled = false;
            this.txtNombreCliente.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreCliente.Location = new System.Drawing.Point(83, 36);
            this.txtNombreCliente.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.Size = new System.Drawing.Size(158, 25);
            this.txtNombreCliente.TabIndex = 26;
            // 
            // btnBuscar
            // 
            this.btnBuscar.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscar.IconColor = System.Drawing.Color.CornflowerBlue;
            this.btnBuscar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscar.IconSize = 18;
            this.btnBuscar.Location = new System.Drawing.Point(208, 8);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(33, 26);
            this.btnBuscar.TabIndex = 28;
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblImporteTotal
            // 
            this.lblImporteTotal.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImporteTotal.Location = new System.Drawing.Point(248, 41);
            this.lblImporteTotal.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblImporteTotal.Name = "lblImporteTotal";
            this.lblImporteTotal.Size = new System.Drawing.Size(92, 19);
            this.lblImporteTotal.TabIndex = 30;
            this.lblImporteTotal.Text = "Importe Total";
            // 
            // txtImporteTotal
            // 
            this.txtImporteTotal.Enabled = false;
            this.txtImporteTotal.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporteTotal.Location = new System.Drawing.Point(344, 38);
            this.txtImporteTotal.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtImporteTotal.Name = "txtImporteTotal";
            this.txtImporteTotal.Size = new System.Drawing.Size(121, 25);
            this.txtImporteTotal.TabIndex = 29;
            // 
            // btnEjecutar
            // 
            this.btnEjecutar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEjecutar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEjecutar.IconColor = System.Drawing.Color.Black;
            this.btnEjecutar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEjecutar.Location = new System.Drawing.Point(344, 6);
            this.btnEjecutar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEjecutar.Name = "btnEjecutar";
            this.btnEjecutar.Size = new System.Drawing.Size(121, 24);
            this.btnEjecutar.TabIndex = 31;
            this.btnEjecutar.Text = "Ejecutar";
            this.btnEjecutar.UseVisualStyleBackColor = true;
            this.btnEjecutar.Click += new System.EventHandler(this.btnEjecutar_Click);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Categoria";
            // 
            // FrmReporteReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 463);
            this.Controls.Add(this.btnEjecutar);
            this.Controls.Add(this.lblImporteTotal);
            this.Controls.Add(this.txtImporteTotal);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.lblNombre);
            this.Controls.Add(this.txtNombreCliente);
            this.Controls.Add(this.lblIidCliente);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.lstReporte);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmReporteReservas";
            this.Text = "Reporte de Reservas";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListView lstReporte;
        private System.Windows.Forms.TextBox txtIdCliente;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chHabitacion;
        private System.Windows.Forms.ColumnHeader chCantidadHuespedes;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblResultado;
        private System.Windows.Forms.ColumnHeader ChPrecio;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private FontAwesome.Sharp.IconButton btnExportarExcel;
        private System.Windows.Forms.Label lblIidCliente;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.ColumnHeader chFechaIngreso;
        private System.Windows.Forms.ColumnHeader chFechaEgreso;
        private FontAwesome.Sharp.IconButton btnBuscar;
        private System.Windows.Forms.Label lblImporteTotal;
        private System.Windows.Forms.TextBox txtImporteTotal;
        private FontAwesome.Sharp.IconButton btnEjecutar;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}