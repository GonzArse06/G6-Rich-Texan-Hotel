using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.Runtime.InteropServices;
using NLayer.Negocios;

/// <summary>
/// El formulario de inicio es un contenedor que cuenta con 3 secciones principales:
/// - Panel Top: imagen de inicio, con funcion de boton de inicio que reestablece valores; una barra que permite mover el form; y unas imagenes que minimizan, maximizan y cierran el form.
/// - Panel Izquierdo: botones con diseño que abre las transacciones
/// - Panel Central: contenedor donde se abren los formularios de las transacciones. 
/// </summary>

namespace NLayer.Formularios
{
    public partial class FrmInicio : Form
    {
        private IconButton _currentBtn;
        private Panel _leftBorderBtn;
        private Form _currentChildForm;
        
        HotelServicios _hotelServicios;

        public FrmInicio()
        {
            InitializeComponent();
            _currentBtn = new IconButton();
            _leftBorderBtn = new Panel();
            _leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(_leftBorderBtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            _hotelServicios = new HotelServicios();    
        }
        private void Reset()
        {
            if (_currentChildForm != null)
            {
                _currentChildForm.Close();
            }
            DisableButton();
            _leftBorderBtn.Visible = false;
            imgFormularioActual.IconChar = IconChar.Home;
            imgFormularioActual.IconColor = Color.CornflowerBlue;
            LblTitulo.Text = "Inicio";
        }
        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                _currentBtn = (IconButton)senderBtn;
                _currentBtn.BackColor = Color.FromArgb(37, 37, 81);
                _currentBtn.ForeColor = color;
                _currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                _currentBtn.IconColor = color;
                _currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                _currentBtn.ImageAlign = ContentAlignment.MiddleCenter;

                _leftBorderBtn.BackColor = color;
                _leftBorderBtn.Location = new Point(0, _currentBtn.Location.Y);
                _leftBorderBtn.Visible = true;
                _leftBorderBtn.BringToFront();

                imgFormularioActual.IconChar = _currentBtn.IconChar;
                imgFormularioActual.IconColor = color;
                LblTitulo.Text = _currentBtn.Text;
            }
        }
        private void DisableButton()
        {
            _currentBtn.BackColor = Color.White;
            _currentBtn.ForeColor = Color.Black;
            _currentBtn.TextAlign = ContentAlignment.MiddleLeft;
            _currentBtn.IconColor = Color.CornflowerBlue;
            _currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            _currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
        }
        private void OpenChildForm(Form childForm)
        {
            if (_currentChildForm != null)
            {
                _currentChildForm.Close();
            }
            _currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelFormularioHijo.Controls.Add(childForm);
            panelFormularioHijo.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            LblTitulo.Text = childForm.Text;
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.LightBlue);
            OpenChildForm(new FrmClientes(_hotelServicios));
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.LightBlue);
            OpenChildForm(new FrmReservas( _hotelServicios));
        }

        private void btnHoteles_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.LightBlue);
            OpenChildForm(new FrmHoteles(_hotelServicios));
        }

        private void btnHabitaciones_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.LightBlue);
            OpenChildForm(new FrmHabitaciones(_hotelServicios) );
        }

        private void btnReporteClientes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.LightBlue);
            OpenChildForm(new FrmReporteReservas(_hotelServicios));
        }

        private void btnReporteHabitaciones_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.LightBlue);
            OpenChildForm(new FrmReporteHabitaciones(_hotelServicios));
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Reset();
        }       

        //drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);

        private void panelBarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Desea cerrar la aplicacion?", "Salir", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Application.Exit();
        }

        private void btnMaximizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            btnRestore.Visible = true;
            btnMaximizar.Visible = false;
        }

        private void btnRestore_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            btnRestore.Visible = false;
            btnMaximizar.Visible = true;
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
    }
}
