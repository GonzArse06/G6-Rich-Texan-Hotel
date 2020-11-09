namespace NLayer.Formularios
{
    partial class FrmReservas
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
            this.lstReservas = new System.Windows.Forms.ListView();
            this.chIdReserva = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIdHabitacion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chIdCliente = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chClienteNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChCantidadHuespedes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFechaIngreso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFechaEgreso = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblResultado = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblIdHotel = new System.Windows.Forms.Label();
            this.cbxHoteles = new System.Windows.Forms.ComboBox();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.btnExportarExcel = new FontAwesome.Sharp.IconButton();
            this.btnEliminar = new FontAwesome.Sharp.IconButton();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstReservas
            // 
            this.lstReservas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstReservas.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chIdReserva,
            this.chIdHabitacion,
            this.chIdCliente,
            this.chClienteNombre,
            this.ChCantidadHuespedes,
            this.chFechaIngreso,
            this.chFechaEgreso});
            this.lstReservas.FullRowSelect = true;
            this.lstReservas.HideSelection = false;
            this.lstReservas.Location = new System.Drawing.Point(9, 54);
            this.lstReservas.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.lstReservas.Name = "lstReservas";
            this.lstReservas.Size = new System.Drawing.Size(631, 408);
            this.lstReservas.TabIndex = 4;
            this.lstReservas.UseCompatibleStateImageBehavior = false;
            this.lstReservas.View = System.Windows.Forms.View.Details;
            this.lstReservas.DoubleClick += new System.EventHandler(this.btnEditar_Click);
            // 
            // chIdReserva
            // 
            this.chIdReserva.Text = "Id";
            this.chIdReserva.Width = 40;
            // 
            // chIdHabitacion
            // 
            this.chIdHabitacion.Text = "idHabitacion";
            this.chIdHabitacion.Width = 84;
            // 
            // chIdCliente
            // 
            this.chIdCliente.Text = "IdCliente";
            this.chIdCliente.Width = 103;
            // 
            // chClienteNombre
            // 
            this.chClienteNombre.Text = "Nombre cliente";
            this.chClienteNombre.Width = 175;
            // 
            // ChCantidadHuespedes
            // 
            this.ChCantidadHuespedes.Text = "Cantidad de huespedes";
            this.ChCantidadHuespedes.Width = 137;
            // 
            // chFechaIngreso
            // 
            this.chFechaIngreso.Text = "Fecha de Ingreso";
            this.chFechaIngreso.Width = 148;
            // 
            // chFechaEgreso
            // 
            this.chFechaEgreso.Text = "Fecha Egreso";
            this.chFechaEgreso.Width = 162;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblResultado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 509);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(847, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblResultado
            // 
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 17);
            // 
            // lblIdHotel
            // 
            this.lblIdHotel.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdHotel.Location = new System.Drawing.Point(9, 20);
            this.lblIdHotel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdHotel.Name = "lblIdHotel";
            this.lblIdHotel.Size = new System.Drawing.Size(61, 21);
            this.lblIdHotel.TabIndex = 8;
            this.lblIdHotel.Text = "ID Hotel";
            // 
            // cbxHoteles
            // 
            this.cbxHoteles.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxHoteles.FormattingEnabled = true;
            this.cbxHoteles.Location = new System.Drawing.Point(74, 16);
            this.cbxHoteles.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cbxHoteles.Name = "cbxHoteles";
            this.cbxHoteles.Size = new System.Drawing.Size(172, 25);
            this.cbxHoteles.TabIndex = 9;
            this.cbxHoteles.SelectedIndexChanged += new System.EventHandler(this.cbxHoteles_SelectedIndexChanged);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCerrar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCerrar.IconColor = System.Drawing.Color.Black;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 28;
            this.btnCerrar.Location = new System.Drawing.Point(798, 10);
            this.btnCerrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Rotation = 0D;
            this.btnCerrar.Size = new System.Drawing.Size(40, 31);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportarExcel.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnExportarExcel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnExportarExcel.IconColor = System.Drawing.Color.Black;
            this.btnExportarExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportarExcel.IconSize = 48;
            this.btnExportarExcel.Location = new System.Drawing.Point(674, 249);
            this.btnExportarExcel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Rotation = 0D;
            this.btnExportarExcel.Size = new System.Drawing.Size(164, 50);
            this.btnExportarExcel.TabIndex = 3;
            this.btnExportarExcel.Text = "EXPORTAR A EXCEL";
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            this.btnExportarExcel.Click += new System.EventHandler(this.btnExportarExcel_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEliminar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnEliminar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEliminar.IconColor = System.Drawing.Color.Black;
            this.btnEliminar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEliminar.IconSize = 48;
            this.btnEliminar.Location = new System.Drawing.Point(674, 182);
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Rotation = 0D;
            this.btnEliminar.Size = new System.Drawing.Size(164, 50);
            this.btnEliminar.TabIndex = 2;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnEditar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEditar.IconColor = System.Drawing.Color.Black;
            this.btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar.IconSize = 48;
            this.btnEditar.Location = new System.Drawing.Point(674, 118);
            this.btnEditar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Rotation = 0D;
            this.btnEditar.Size = new System.Drawing.Size(164, 50);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnNuevo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnNuevo.IconColor = System.Drawing.Color.Black;
            this.btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo.IconSize = 48;
            this.btnNuevo.Location = new System.Drawing.Point(674, 54);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Rotation = 0D;
            this.btnNuevo.Size = new System.Drawing.Size(164, 50);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // FrmReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 531);
            this.Controls.Add(this.cbxHoteles);
            this.Controls.Add(this.lblIdHotel);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.lstReservas);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmReservas";
            this.Text = "Reservas";
            this.Load += new System.EventHandler(this.FrmReservas_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton btnEliminar;
        private FontAwesome.Sharp.IconButton btnExportarExcel;
        private System.Windows.Forms.ListView lstReservas;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Windows.Forms.ColumnHeader chIdReserva;
        private System.Windows.Forms.ColumnHeader chIdCliente;
        private System.Windows.Forms.ColumnHeader chClienteNombre;
        private System.Windows.Forms.ColumnHeader ChCantidadHuespedes;
        private System.Windows.Forms.ColumnHeader chFechaIngreso;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblResultado;
        private System.Windows.Forms.Label lblIdHotel;
        private System.Windows.Forms.ComboBox cbxHoteles;
        private System.Windows.Forms.ColumnHeader chFechaEgreso;
        private System.Windows.Forms.ColumnHeader chIdHabitacion;
    }
}