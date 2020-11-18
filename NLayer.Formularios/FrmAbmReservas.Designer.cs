namespace NLayer.Formularios
{
    partial class FrmAbmReservas
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
            this.lblFechaIngreso = new System.Windows.Forms.Label();
            this.lblCantidadHuespedes = new System.Windows.Forms.Label();
            this.lblIdHabitacion = new System.Windows.Forms.Label();
            this.lblIdCliente = new System.Windows.Forms.Label();
            this.lblFechaEgreso = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblResultado = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnBuscarCliente = new FontAwesome.Sharp.IconButton();
            this.btnBuscarHabitacion = new FontAwesome.Sharp.IconButton();
            this.dtFechaIngreso = new System.Windows.Forms.DateTimePicker();
            this.dtFechaEgreso = new System.Windows.Forms.DateTimePicker();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.lblIdReserva = new System.Windows.Forms.Label();
            this.btnBuscarHotel = new FontAwesome.Sharp.IconButton();
            this.lblIidHotel = new System.Windows.Forms.Label();
            this.txtNroHuespedes = new NLayer.Formularios.TextoNumerico();
            this.txtIdHabitacion = new NLayer.Formularios.TextoNumerico();
            this.txtIdCliente = new NLayer.Formularios.TextoNumerico();
            this.txtIdHotel = new NLayer.Formularios.TextoNumerico();
            this.txtIdReserva = new NLayer.Formularios.TextoNumerico();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblFechaIngreso
            // 
            this.lblFechaIngreso.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaIngreso.Location = new System.Drawing.Point(68, 185);
            this.lblFechaIngreso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaIngreso.Name = "lblFechaIngreso";
            this.lblFechaIngreso.Size = new System.Drawing.Size(95, 19);
            this.lblFechaIngreso.TabIndex = 23;
            this.lblFechaIngreso.Text = "Fecha Ingreso";
            // 
            // lblCantidadHuespedes
            // 
            this.lblCantidadHuespedes.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadHuespedes.Location = new System.Drawing.Point(68, 154);
            this.lblCantidadHuespedes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCantidadHuespedes.Name = "lblCantidadHuespedes";
            this.lblCantidadHuespedes.Size = new System.Drawing.Size(105, 28);
            this.lblCantidadHuespedes.TabIndex = 22;
            this.lblCantidadHuespedes.Text = "Nro Huespedes";
            // 
            // lblIdHabitacion
            // 
            this.lblIdHabitacion.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdHabitacion.Location = new System.Drawing.Point(68, 122);
            this.lblIdHabitacion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdHabitacion.Name = "lblIdHabitacion";
            this.lblIdHabitacion.Size = new System.Drawing.Size(120, 24);
            this.lblIdHabitacion.TabIndex = 21;
            this.lblIdHabitacion.Text = "Nro Habitacion";
            // 
            // lblIdCliente
            // 
            this.lblIdCliente.AutoSize = true;
            this.lblIdCliente.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdCliente.Location = new System.Drawing.Point(68, 91);
            this.lblIdCliente.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdCliente.Name = "lblIdCliente";
            this.lblIdCliente.Size = new System.Drawing.Size(68, 18);
            this.lblIdCliente.TabIndex = 14;
            this.lblIdCliente.Text = "Id Cliente";
            // 
            // lblFechaEgreso
            // 
            this.lblFechaEgreso.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFechaEgreso.Location = new System.Drawing.Point(68, 216);
            this.lblFechaEgreso.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFechaEgreso.Name = "lblFechaEgreso";
            this.lblFechaEgreso.Size = new System.Drawing.Size(95, 24);
            this.lblFechaEgreso.TabIndex = 24;
            this.lblFechaEgreso.Text = "Fecha Egreso";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblResultado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 323);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip1.Size = new System.Drawing.Size(439, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "`";
            // 
            // lblResultado
            // 
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 17);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarCliente.IconColor = System.Drawing.Color.CornflowerBlue;
            this.btnBuscarCliente.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarCliente.IconSize = 18;
            this.btnBuscarCliente.Location = new System.Drawing.Point(311, 86);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(33, 26);
            this.btnBuscarCliente.TabIndex = 5;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // btnBuscarHabitacion
            // 
            this.btnBuscarHabitacion.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarHabitacion.IconColor = System.Drawing.Color.CornflowerBlue;
            this.btnBuscarHabitacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarHabitacion.IconSize = 18;
            this.btnBuscarHabitacion.Location = new System.Drawing.Point(311, 119);
            this.btnBuscarHabitacion.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarHabitacion.Name = "btnBuscarHabitacion";
            this.btnBuscarHabitacion.Size = new System.Drawing.Size(33, 26);
            this.btnBuscarHabitacion.TabIndex = 7;
            this.btnBuscarHabitacion.UseVisualStyleBackColor = true;
            this.btnBuscarHabitacion.Click += new System.EventHandler(this.btnBuscarHabitacion_Click);
            // 
            // dtFechaIngreso
            // 
            this.dtFechaIngreso.CalendarFont = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaIngreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaIngreso.Location = new System.Drawing.Point(178, 184);
            this.dtFechaIngreso.Margin = new System.Windows.Forms.Padding(2);
            this.dtFechaIngreso.Name = "dtFechaIngreso";
            this.dtFechaIngreso.Size = new System.Drawing.Size(129, 20);
            this.dtFechaIngreso.TabIndex = 9;
            // 
            // dtFechaEgreso
            // 
            this.dtFechaEgreso.CalendarFont = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtFechaEgreso.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaEgreso.Location = new System.Drawing.Point(178, 215);
            this.dtFechaEgreso.Margin = new System.Windows.Forms.Padding(2);
            this.dtFechaEgreso.Name = "dtFechaEgreso";
            this.dtFechaEgreso.Size = new System.Drawing.Size(129, 20);
            this.dtFechaEgreso.TabIndex = 10;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCancelar.IconColor = System.Drawing.Color.Red;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 40;
            this.btnCancelar.Location = new System.Drawing.Point(208, 256);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(117, 43);
            this.btnCancelar.TabIndex = 12;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.IconChar = FontAwesome.Sharp.IconChar.Save;
            this.btnGuardar.IconColor = System.Drawing.Color.DarkBlue;
            this.btnGuardar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGuardar.IconSize = 40;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(86, 256);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(117, 43);
            this.btnGuardar.TabIndex = 11;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // lblIdReserva
            // 
            this.lblIdReserva.AutoSize = true;
            this.lblIdReserva.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIdReserva.Location = new System.Drawing.Point(68, 26);
            this.lblIdReserva.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdReserva.Name = "lblIdReserva";
            this.lblIdReserva.Size = new System.Drawing.Size(73, 18);
            this.lblIdReserva.TabIndex = 38;
            this.lblIdReserva.Text = "ID Reserva";
            // 
            // btnBuscarHotel
            // 
            this.btnBuscarHotel.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarHotel.IconColor = System.Drawing.Color.CornflowerBlue;
            this.btnBuscarHotel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarHotel.IconSize = 18;
            this.btnBuscarHotel.Location = new System.Drawing.Point(311, 54);
            this.btnBuscarHotel.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscarHotel.Name = "btnBuscarHotel";
            this.btnBuscarHotel.Size = new System.Drawing.Size(33, 27);
            this.btnBuscarHotel.TabIndex = 3;
            this.btnBuscarHotel.UseVisualStyleBackColor = true;
            this.btnBuscarHotel.Click += new System.EventHandler(this.btnBuscarHotel_Click);
            // 
            // lblIidHotel
            // 
            this.lblIidHotel.AutoSize = true;
            this.lblIidHotel.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIidHotel.Location = new System.Drawing.Point(68, 58);
            this.lblIidHotel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIidHotel.Name = "lblIidHotel";
            this.lblIidHotel.Size = new System.Drawing.Size(57, 18);
            this.lblIidHotel.TabIndex = 39;
            this.lblIidHotel.Text = "Id Hotel";
            // 
            // txtNroHuespedes
            // 
            this.txtNroHuespedes.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNroHuespedes.Location = new System.Drawing.Point(178, 150);
            this.txtNroHuespedes.Name = "txtNroHuespedes";
            this.txtNroHuespedes.Size = new System.Drawing.Size(129, 26);
            this.txtNroHuespedes.TabIndex = 8;
            // 
            // txtIdHabitacion
            // 
            this.txtIdHabitacion.Enabled = false;
            this.txtIdHabitacion.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdHabitacion.Location = new System.Drawing.Point(178, 118);
            this.txtIdHabitacion.Name = "txtIdHabitacion";
            this.txtIdHabitacion.ReadOnly = true;
            this.txtIdHabitacion.Size = new System.Drawing.Size(129, 26);
            this.txtIdHabitacion.TabIndex = 6;
            // 
            // txtIdCliente
            // 
            this.txtIdCliente.Enabled = false;
            this.txtIdCliente.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdCliente.Location = new System.Drawing.Point(178, 86);
            this.txtIdCliente.Name = "txtIdCliente";
            this.txtIdCliente.ReadOnly = true;
            this.txtIdCliente.Size = new System.Drawing.Size(129, 26);
            this.txtIdCliente.TabIndex = 4;
            // 
            // txtIdHotel
            // 
            this.txtIdHotel.Enabled = false;
            this.txtIdHotel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdHotel.Location = new System.Drawing.Point(178, 54);
            this.txtIdHotel.Name = "txtIdHotel";
            this.txtIdHotel.ReadOnly = true;
            this.txtIdHotel.Size = new System.Drawing.Size(129, 26);
            this.txtIdHotel.TabIndex = 2;
            this.txtIdHotel.TextChanged += new System.EventHandler(this.txtIdHotel_TextChanged);
            // 
            // txtIdReserva
            // 
            this.txtIdReserva.Enabled = false;
            this.txtIdReserva.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdReserva.Location = new System.Drawing.Point(178, 22);
            this.txtIdReserva.Name = "txtIdReserva";
            this.txtIdReserva.ReadOnly = true;
            this.txtIdReserva.Size = new System.Drawing.Size(129, 26);
            this.txtIdReserva.TabIndex = 1;
            // 
            // FrmAbmReservas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 345);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtNroHuespedes);
            this.Controls.Add(this.txtIdHabitacion);
            this.Controls.Add(this.txtIdCliente);
            this.Controls.Add(this.txtIdHotel);
            this.Controls.Add(this.txtIdReserva);
            this.Controls.Add(this.btnBuscarHotel);
            this.Controls.Add(this.lblIidHotel);
            this.Controls.Add(this.lblIdReserva);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.dtFechaEgreso);
            this.Controls.Add(this.dtFechaIngreso);
            this.Controls.Add(this.btnBuscarHabitacion);
            this.Controls.Add(this.btnBuscarCliente);
            this.Controls.Add(this.lblFechaEgreso);
            this.Controls.Add(this.lblFechaIngreso);
            this.Controls.Add(this.lblCantidadHuespedes);
            this.Controls.Add(this.lblIdHabitacion);
            this.Controls.Add(this.lblIdCliente);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(454, 383);
            this.Name = "FrmAbmReservas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reservas";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblFechaIngreso;
        private System.Windows.Forms.Label lblCantidadHuespedes;
        private System.Windows.Forms.Label lblIdHabitacion;
        private System.Windows.Forms.Label lblIdCliente;
        private System.Windows.Forms.Label lblFechaEgreso;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblResultado;
        private FontAwesome.Sharp.IconButton btnBuscarCliente;
        private FontAwesome.Sharp.IconButton btnBuscarHabitacion;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        public System.Windows.Forms.DateTimePicker dtFechaIngreso;
        public System.Windows.Forms.DateTimePicker dtFechaEgreso;
        private System.Windows.Forms.Label lblIdReserva;
        private FontAwesome.Sharp.IconButton btnBuscarHotel;
        private System.Windows.Forms.Label lblIidHotel;
        public TextoNumerico txtIdReserva;
        public TextoNumerico txtIdHotel;
        public TextoNumerico txtIdCliente;
        public TextoNumerico txtIdHabitacion;
        public TextoNumerico txtNroHuespedes;
    }
}