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

namespace NLayer.Formularios
{
    public partial class FrmInicio : Form
    {
        private IconButton currentBtn;
        private Panel leftBorderBtn;
        private Form currentChildForm;
        
        ReservaServicios _reservaServicios;
        HotelServicios _hotelServicios;
        ClienteServicios _clienteServicios;
        HabitacionServicios _habitacionServicios;

        public FrmInicio()
        {
            InitializeComponent();
            currentBtn = new IconButton();
            leftBorderBtn = new Panel();
            leftBorderBtn.Size = new Size(7, 60);
            panelMenu.Controls.Add(leftBorderBtn);
            this.Text = string.Empty;
            this.ControlBox = false;
            this.DoubleBuffered = true;
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            _hotelServicios = new HotelServicios();
            _clienteServicios = new ClienteServicios();
            _habitacionServicios = new HabitacionServicios();
            _reservaServicios = new ReservaServicios();
        }

        private void ActivateButton(object senderBtn, Color color)
        {
            if (senderBtn != null)
            {
                DisableButton();
                currentBtn = (IconButton)senderBtn;
                currentBtn.BackColor = Color.FromArgb(37, 37, 81);
                currentBtn.ForeColor = color;
                currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                currentBtn.IconColor = color;
                currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                currentBtn.ImageAlign = ContentAlignment.MiddleCenter;

                leftBorderBtn.BackColor = color;
                leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                leftBorderBtn.Visible = true;
                leftBorderBtn.BringToFront();

                imgFormularioActual.IconChar = currentBtn.IconChar;
                imgFormularioActual.IconColor = color;
                LblTitulo.Text = currentBtn.Text;
            }
        }

        private void DisableButton()
        {
            currentBtn.BackColor = Color.White;
            currentBtn.ForeColor = Color.CornflowerBlue;
            currentBtn.TextAlign = ContentAlignment.MiddleLeft;
            currentBtn.IconColor = Color.CornflowerBlue;
            currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
        }

        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
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
            OpenChildForm(new FrmClientes(_clienteServicios));
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.LightBlue);
            OpenChildForm(new FrmReservas( _reservaServicios,_hotelServicios,_clienteServicios));
        }

        private void btnHoteles_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.LightBlue);
            OpenChildForm(new FrmHoteles(_hotelServicios));
        }

        private void btnHabitaciones_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.LightBlue);
            OpenChildForm(new FrmHabitaciones(_habitacionServicios) );
        }

        private void btnReporteClientes_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.LightBlue);
        }

        private void btnReporteHabitaciones_Click(object sender, EventArgs e)
        {
            ActivateButton(sender, Color.LightBlue);
        }

        private void btnInicio_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void Reset()
        {
            DisableButton();
            leftBorderBtn.Visible = false;
            imgFormularioActual.IconChar = IconChar.Home;
            imgFormularioActual.IconColor = Color.CornflowerBlue;
            LblTitulo.Text = "Inicio";
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
            if (MessageBox.Show("Desea cerrar la aplicacion?", "Salir", MessageBoxButtons.YesNo) == DialogResult.Yes)
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

        private void panelFormularioHijo_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
