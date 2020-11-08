namespace NLayer.Formularios
{
    partial class FrmBuscarCliente
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
            this.btnCerrar = new FontAwesome.Sharp.IconButton();
            this.btnSeleccionar = new FontAwesome.Sharp.IconButton();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnCerrar
            // 
            this.btnCerrar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnCerrar.IconChar = FontAwesome.Sharp.IconChar.Times;
            this.btnCerrar.IconColor = System.Drawing.Color.Black;
            this.btnCerrar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCerrar.IconSize = 26;
            this.btnCerrar.Location = new System.Drawing.Point(577, 12);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Rotation = 0D;
            this.btnCerrar.Size = new System.Drawing.Size(44, 31);
            this.btnCerrar.TabIndex = 37;
            this.btnCerrar.UseVisualStyleBackColor = true;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.Color.Transparent;
            this.btnSeleccionar.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            this.btnSeleccionar.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeleccionar.IconChar = FontAwesome.Sharp.IconChar.Check;
            this.btnSeleccionar.IconColor = System.Drawing.Color.Black;
            this.btnSeleccionar.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSeleccionar.IconSize = 40;
            this.btnSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSeleccionar.Location = new System.Drawing.Point(443, 308);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Rotation = 0D;
            this.btnSeleccionar.Size = new System.Drawing.Size(178, 53);
            this.btnSeleccionar.TabIndex = 38;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSeleccionar.UseVisualStyleBackColor = false;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // listBox1
            // 
            this.listBox1.Font = new System.Drawing.Font("Calibri", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 22;
            this.listBox1.Location = new System.Drawing.Point(12, 48);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(609, 246);
            this.listBox1.TabIndex = 39;
            this.listBox1.DoubleClick += new System.EventHandler(this.listBox1_doubleClick);
            // 
            // FrmBuscarCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(633, 373);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.btnCerrar);
            this.Name = "FrmBuscarCliente";
            this.Text = "FrmBuscarCliente";
            this.Load += new System.EventHandler(this.FrmBuscarCliente_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnCerrar;
        private FontAwesome.Sharp.IconButton btnSeleccionar;
        private System.Windows.Forms.ListBox listBox1;
    }
}