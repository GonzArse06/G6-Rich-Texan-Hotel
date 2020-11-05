namespace NLayer.Formularios
{
    partial class FrmClientes
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
            this.btnNuevo = new FontAwesome.Sharp.IconButton();
            this.btnEditar = new FontAwesome.Sharp.IconButton();
            this.iconButton2 = new FontAwesome.Sharp.IconButton();
            this.btnExportarExcel = new FontAwesome.Sharp.IconButton();
            this.lstClientes = new System.Windows.Forms.ListView();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNombre = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chApellido = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chDireccion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chMail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTelefono = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chFechaAlta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // btnNuevo
            // 
            this.btnNuevo.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnNuevo.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnNuevo.IconColor = System.Drawing.Color.Black;
            this.btnNuevo.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNuevo.IconSize = 48;
            this.btnNuevo.Location = new System.Drawing.Point(931, 90);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Rotation = 0D;
            this.btnNuevo.Size = new System.Drawing.Size(219, 61);
            this.btnNuevo.TabIndex = 0;
            this.btnNuevo.Text = "NUEVO";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnEditar.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnEditar.IconColor = System.Drawing.Color.Black;
            this.btnEditar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnEditar.IconSize = 48;
            this.btnEditar.Location = new System.Drawing.Point(931, 169);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Rotation = 0D;
            this.btnEditar.Size = new System.Drawing.Size(219, 61);
            this.btnEditar.TabIndex = 1;
            this.btnEditar.Text = "EDITAR";
            this.btnEditar.UseVisualStyleBackColor = true;
            // 
            // iconButton2
            // 
            this.iconButton2.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.iconButton2.IconChar = FontAwesome.Sharp.IconChar.None;
            this.iconButton2.IconColor = System.Drawing.Color.Black;
            this.iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton2.IconSize = 48;
            this.iconButton2.Location = new System.Drawing.Point(931, 248);
            this.iconButton2.Name = "iconButton2";
            this.iconButton2.Rotation = 0D;
            this.iconButton2.Size = new System.Drawing.Size(219, 61);
            this.iconButton2.TabIndex = 2;
            this.iconButton2.Text = "ELIMINAR";
            this.iconButton2.UseVisualStyleBackColor = true;
            // 
            // btnExportarExcel
            // 
            this.btnExportarExcel.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnExportarExcel.IconChar = FontAwesome.Sharp.IconChar.None;
            this.btnExportarExcel.IconColor = System.Drawing.Color.Black;
            this.btnExportarExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnExportarExcel.IconSize = 48;
            this.btnExportarExcel.Location = new System.Drawing.Point(931, 330);
            this.btnExportarExcel.Name = "btnExportarExcel";
            this.btnExportarExcel.Rotation = 0D;
            this.btnExportarExcel.Size = new System.Drawing.Size(219, 61);
            this.btnExportarExcel.TabIndex = 3;
            this.btnExportarExcel.Text = "EXPORTAR A EXCEL";
            this.btnExportarExcel.UseVisualStyleBackColor = true;
            // 
            // lstClientes
            // 
            this.lstClientes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chNombre,
            this.chApellido,
            this.chDireccion,
            this.chMail,
            this.chTelefono,
            this.chFechaAlta});
            this.lstClientes.HideSelection = false;
            this.lstClientes.Location = new System.Drawing.Point(12, 90);
            this.lstClientes.Name = "lstClientes";
            this.lstClientes.Size = new System.Drawing.Size(913, 501);
            this.lstClientes.TabIndex = 4;
            this.lstClientes.UseCompatibleStateImageBehavior = false;
            this.lstClientes.View = System.Windows.Forms.View.Details;
            // 
            // txtBuscador
            // 
            this.txtBuscador.Location = new System.Drawing.Point(12, 62);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(562, 22);
            this.txtBuscador.TabIndex = 5;
            // 
            // btnCerrar
            // 
            this.btnCerrar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCerrar.IconColor = System.Drawing.Color.Black;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 28;
            this.btnCerrar.Location = new System.Drawing.Point(1097, 36);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Rotation = 0D;
            this.btnCerrar.Size = new System.Drawing.Size(53, 38);
            this.btnCerrar.TabIndex = 6;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // chId
            // 
            this.chId.Text = "Id";
            // 
            // chNombre
            // 
            this.chNombre.Text = "Nombre";
            this.chNombre.Width = 90;
            // 
            // chApellido
            // 
            this.chApellido.Text = "Apellido";
            this.chApellido.Width = 161;
            // 
            // chDireccion
            // 
            this.chDireccion.Text = "Direccion";
            this.chDireccion.Width = 182;
            // 
            // chMail
            // 
            this.chMail.Text = "Mail";
            this.chMail.Width = 119;
            // 
            // chTelefono
            // 
            this.chTelefono.Text = "Telefono";
            this.chTelefono.Width = 142;
            // 
            // chFechaAlta
            // 
            this.chFechaAlta.Text = "Fecha Alta";
            // 
            // FrmClientes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1162, 696);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.txtBuscador);
            this.Controls.Add(this.lstClientes);
            this.Controls.Add(this.btnExportarExcel);
            this.Controls.Add(this.iconButton2);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnNuevo);
            this.Name = "FrmClientes";
            this.Text = "Clientes";
            this.Load += new System.EventHandler(this.FrmClientes_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnNuevo;
        private FontAwesome.Sharp.IconButton btnEditar;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton btnExportarExcel;
        private System.Windows.Forms.ListView lstClientes;
        private System.Windows.Forms.TextBox txtBuscador;
        private FontAwesome.Sharp.IconButton btnCerrar;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chNombre;
        private System.Windows.Forms.ColumnHeader chApellido;
        private System.Windows.Forms.ColumnHeader chDireccion;
        private System.Windows.Forms.ColumnHeader chMail;
        private System.Windows.Forms.ColumnHeader chTelefono;
        private System.Windows.Forms.ColumnHeader chFechaAlta;
    }
}