namespace NLayer.Formularios
{
    partial class FrmAbmHabitaciones
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
            this.lblIidHabitacion = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtCategoria = new System.Windows.Forms.TextBox();
            this.lblCategoria = new System.Windows.Forms.Label();
            this.lblCantidadPlazas = new System.Windows.Forms.Label();
            this.lblCancelable = new System.Windows.Forms.Label();
            this.lblPrecio = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblResultado = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnCancelar = new FontAwesome.Sharp.IconButton();
            this.btnGuardar = new FontAwesome.Sharp.IconButton();
            this.btnBuscarHaitacion = new FontAwesome.Sharp.IconButton();
            this.cbCancelable = new System.Windows.Forms.CheckBox();
            this.btnBuscarHotel = new FontAwesome.Sharp.IconButton();
            this.lblIidHotel = new System.Windows.Forms.Label();
            this.txtIdHotel = new NLayer.Formularios.TextoNumerico();
            this.txtIdHabitacion = new NLayer.Formularios.TextoNumerico();
            this.txtCantidadPlazas = new NLayer.Formularios.TextoNumerico();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblIidHabitacion
            // 
            this.lblIidHabitacion.AutoSize = true;
            this.lblIidHabitacion.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIidHabitacion.Location = new System.Drawing.Point(22, 67);
            this.lblIidHabitacion.Name = "lblIidHabitacion";
            this.lblIidHabitacion.Size = new System.Drawing.Size(125, 23);
            this.lblIidHabitacion.TabIndex = 0;
            this.lblIidHabitacion.Text = "Nro Habitacion";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPrecio.Location = new System.Drawing.Point(178, 207);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(236, 29);
            this.txtPrecio.TabIndex = 5;
            // 
            // txtCategoria
            // 
            this.txtCategoria.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCategoria.Location = new System.Drawing.Point(178, 100);
            this.txtCategoria.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtCategoria.Name = "txtCategoria";
            this.txtCategoria.Size = new System.Drawing.Size(236, 29);
            this.txtCategoria.TabIndex = 2;
            // 
            // lblCategoria
            // 
            this.lblCategoria.AutoSize = true;
            this.lblCategoria.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCategoria.Location = new System.Drawing.Point(22, 103);
            this.lblCategoria.Name = "lblCategoria";
            this.lblCategoria.Size = new System.Drawing.Size(83, 23);
            this.lblCategoria.TabIndex = 8;
            this.lblCategoria.Text = "Categoria";
            // 
            // lblCantidadPlazas
            // 
            this.lblCantidadPlazas.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidadPlazas.Location = new System.Drawing.Point(20, 142);
            this.lblCantidadPlazas.Name = "lblCantidadPlazas";
            this.lblCantidadPlazas.Size = new System.Drawing.Size(165, 31);
            this.lblCantidadPlazas.TabIndex = 9;
            this.lblCantidadPlazas.Text = "Cantidad de Plazas";
            // 
            // lblCancelable
            // 
            this.lblCancelable.AutoSize = true;
            this.lblCancelable.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCancelable.Location = new System.Drawing.Point(22, 177);
            this.lblCancelable.Name = "lblCancelable";
            this.lblCancelable.Size = new System.Drawing.Size(92, 23);
            this.lblCancelable.TabIndex = 10;
            this.lblCancelable.Text = "Cancelable";
            // 
            // lblPrecio
            // 
            this.lblPrecio.AutoSize = true;
            this.lblPrecio.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrecio.Location = new System.Drawing.Point(22, 211);
            this.lblPrecio.Name = "lblPrecio";
            this.lblPrecio.Size = new System.Drawing.Size(58, 23);
            this.lblPrecio.TabIndex = 11;
            this.lblPrecio.Text = "Precio";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblResultado});
            this.statusStrip1.Location = new System.Drawing.Point(0, 340);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(509, 22);
            this.statusStrip1.TabIndex = 14;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblResultado
            // 
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 16);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Transparent;
            this.btnCancelar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCancelar.IconColor = System.Drawing.Color.Red;
            this.btnCancelar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCancelar.IconSize = 40;
            this.btnCancelar.Location = new System.Drawing.Point(300, 254);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(156, 53);
            this.btnCancelar.TabIndex = 7;
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
            this.btnGuardar.Location = new System.Drawing.Point(138, 254);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(156, 53);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnBuscarHaitacion
            // 
            this.btnBuscarHaitacion.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarHaitacion.IconColor = System.Drawing.Color.CornflowerBlue;
            this.btnBuscarHaitacion.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarHaitacion.IconSize = 18;
            this.btnBuscarHaitacion.Location = new System.Drawing.Point(372, 62);
            this.btnBuscarHaitacion.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarHaitacion.Name = "btnBuscarHaitacion";
            this.btnBuscarHaitacion.Size = new System.Drawing.Size(44, 32);
            this.btnBuscarHaitacion.TabIndex = 20;
            this.btnBuscarHaitacion.UseVisualStyleBackColor = true;
            this.btnBuscarHaitacion.Visible = false;
            // 
            // cbCancelable
            // 
            this.cbCancelable.AutoSize = true;
            this.cbCancelable.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCancelable.Location = new System.Drawing.Point(178, 175);
            this.cbCancelable.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cbCancelable.Name = "cbCancelable";
            this.cbCancelable.Size = new System.Drawing.Size(47, 27);
            this.cbCancelable.TabIndex = 4;
            this.cbCancelable.Text = "SI";
            this.cbCancelable.UseVisualStyleBackColor = true;
            // 
            // btnBuscarHotel
            // 
            this.btnBuscarHotel.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.btnBuscarHotel.IconColor = System.Drawing.Color.CornflowerBlue;
            this.btnBuscarHotel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBuscarHotel.IconSize = 18;
            this.btnBuscarHotel.Location = new System.Drawing.Point(372, 22);
            this.btnBuscarHotel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnBuscarHotel.Name = "btnBuscarHotel";
            this.btnBuscarHotel.Size = new System.Drawing.Size(44, 32);
            this.btnBuscarHotel.TabIndex = 25;
            this.btnBuscarHotel.UseVisualStyleBackColor = true;
            this.btnBuscarHotel.Visible = false;
            // 
            // lblIidHotel
            // 
            this.lblIidHotel.AutoSize = true;
            this.lblIidHotel.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIidHotel.Location = new System.Drawing.Point(22, 28);
            this.lblIidHotel.Name = "lblIidHotel";
            this.lblIidHotel.Size = new System.Drawing.Size(71, 23);
            this.lblIidHotel.TabIndex = 24;
            this.lblIidHotel.Text = "Id Hotel";
            // 
            // txtIdHotel
            // 
            this.txtIdHotel.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdHotel.Location = new System.Drawing.Point(178, 22);
            this.txtIdHotel.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdHotel.Name = "txtIdHotel";
            this.txtIdHotel.ReadOnly = true;
            this.txtIdHotel.Size = new System.Drawing.Size(171, 30);
            this.txtIdHotel.TabIndex = 27;
            // 
            // txtIdHabitacion
            // 
            this.txtIdHabitacion.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIdHabitacion.Location = new System.Drawing.Point(178, 62);
            this.txtIdHabitacion.Margin = new System.Windows.Forms.Padding(4);
            this.txtIdHabitacion.Name = "txtIdHabitacion";
            this.txtIdHabitacion.ReadOnly = true;
            this.txtIdHabitacion.Size = new System.Drawing.Size(171, 30);
            this.txtIdHabitacion.TabIndex = 1;
            // 
            // txtCantidadPlazas
            // 
            this.txtCantidadPlazas.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadPlazas.Location = new System.Drawing.Point(178, 137);
            this.txtCantidadPlazas.Margin = new System.Windows.Forms.Padding(4);
            this.txtCantidadPlazas.Name = "txtCantidadPlazas";
            this.txtCantidadPlazas.Size = new System.Drawing.Size(171, 30);
            this.txtCantidadPlazas.TabIndex = 3;
            // 
            // FrmAbmHabitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 362);
            this.Controls.Add(this.txtCantidadPlazas);
            this.Controls.Add(this.txtIdHabitacion);
            this.Controls.Add(this.txtIdHotel);
            this.Controls.Add(this.btnBuscarHotel);
            this.Controls.Add(this.lblIidHotel);
            this.Controls.Add(this.cbCancelable);
            this.Controls.Add(this.btnBuscarHaitacion);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.lblPrecio);
            this.Controls.Add(this.lblCancelable);
            this.Controls.Add(this.lblCantidadPlazas);
            this.Controls.Add(this.lblCategoria);
            this.Controls.Add(this.txtCategoria);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lblIidHabitacion);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(527, 409);
            this.Name = "FrmAbmHabitaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Habitaciones";
            this.Load += new System.EventHandler(this.FrmAbmHabitaciones_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblIidHabitacion;
        private System.Windows.Forms.Label lblCategoria;
        private System.Windows.Forms.Label lblCantidadPlazas;
        private System.Windows.Forms.Label lblCancelable;
        private System.Windows.Forms.Label lblPrecio;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblResultado;
        private FontAwesome.Sharp.IconButton btnCancelar;
        private FontAwesome.Sharp.IconButton btnGuardar;
        private FontAwesome.Sharp.IconButton btnBuscarHaitacion;
        public System.Windows.Forms.TextBox txtPrecio;
        public System.Windows.Forms.TextBox txtCategoria;
        public System.Windows.Forms.CheckBox cbCancelable;
        private FontAwesome.Sharp.IconButton btnBuscarHotel;
        private System.Windows.Forms.Label lblIidHotel;
        public TextoNumerico txtIdHotel;
        public TextoNumerico txtIdHabitacion;
        public TextoNumerico txtCantidadPlazas;
    }
}