using NLayer.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NLayer.Negocios;
using System.Runtime.InteropServices;

namespace NLayer.Formularios
{
    public partial class FrmAbmHoteles : Form
    {
        AbmTipo _tipo;
        HotelServicios _hotelServicios ;
        public FrmAbmHoteles(AbmTipo tipo, HotelServicios serv )
        {
            InitializeComponent();
            _tipo = tipo;
            _hotelServicios =serv;
            switch (_tipo)
            {
                case AbmTipo.Alta:
                    InicializarAlta();
                    break;
                case AbmTipo.Modificacion:
                    InicializarModificacion();
                    break;
            }
        }
        private void InicializarAlta()
        {
            Text = "Nuevo Hotel";
        }
        private void InicializarModificacion()
        {
            Text = "Modificar Hotel";
        }
        private void Guardar()
        {
            lblResultado.Text = "";
            Hotel hotel = new Hotel();
            string mensaje = Estaticas.Validaciones(Controls);
            if (mensaje != "")
                MessageBox.Show(mensaje);
            else
            {
                try
                {
                    if (_tipo != AbmTipo.Alta)
                        hotel.Id = int.Parse(txtIdHotel.Text);
                    hotel.Nombre = txtNombre.Text;
                    hotel.Direccion = txtDireccion.Text;
                    hotel.Amenities = cbAmenities.Checked;
                    hotel.Estrellas = int.Parse(nuEstrellas.Value.ToString());                   
                    int resultado = -1;
                    switch (_tipo)
                    {
                        case AbmTipo.Alta:
                            resultado = _hotelServicios.IngresarHotel(hotel);
                            LogHelper.LogResultado(lblResultado, resultado, "Ingresar Hotel");
                            break;
                        case AbmTipo.Modificacion:
                            resultado = _hotelServicios.ModificarHotel(hotel);
                            LogHelper.LogResultado(lblResultado, resultado, "Modificar Hotel");
                            break;
                    }
                    this.DialogResult = DialogResult.OK; //cierra
                }
                catch (Exception e)
                {
                    lblResultado.Text = "ERROR -> " + e.Message;
                }
            }
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            if (MessageBox.Show("Esta seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes)
                this.Close();
        }

        //drag Form
        //[DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        //private extern static void ReleaseCapture();

        //[DllImport("user32.DLL", EntryPoint = "SendMessage")]
        //private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);
        //private void panelTop_MouseDown(object sender, MouseEventArgs e)
        //{
        //    ReleaseCapture();
        //    SendMessage(this.Handle, 0x112, 0xf012, 0);
        //}
    }
}
