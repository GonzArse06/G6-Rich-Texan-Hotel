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
    public partial class FrmAbmHabitaciones : Form
    {
        AbmTipo _tipo;
        int _idHotel;
        public FrmAbmHabitaciones(AbmTipo tipo, int idHotel)
        {
            InitializeComponent();
            _tipo = tipo;
            _idHotel = idHotel;
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
            Text = "Nueva Habitacion";
        }

        private void InicializarModificacion()
        {
            Text = "Modificar Habitacion";
        }
        private void Guardar()
        {
            lblResultado.Text = "";
            Habitacion habitacion = new Habitacion();
            string mensaje = Estaticas.Validaciones(Controls);
            if (mensaje != "")
                MessageBox.Show(mensaje);
            else
            {
                try
                {
                    if (_tipo != AbmTipo.Alta)
                        habitacion.Id = int.Parse(txtIdHabitacion.Text);
                    habitacion.IdHotel = _idHotel;
                    habitacion.Categoria = txtCategoria.Text;
                    habitacion.CantidadPlazas = int.Parse(txtCantidadPlazas.Text);
                    habitacion.Cancelable = cbCancelable.Checked;
                    habitacion.Precio = double.Parse(txtPrecio.Text);

                    HotelServicios habitacionServicios = new HotelServicios();
                    int resultado = -1;
                    switch (_tipo)
                    {
                        case AbmTipo.Alta:
                            resultado = habitacionServicios.IngresarHabitacion(habitacion);
                            LogHelper.LogResultado(lblResultado, resultado, "Ingresar Habitacion");
                            break;
                        case AbmTipo.Modificacion:
                            resultado = habitacionServicios.ModificarHabitacion(habitacion);
                            LogHelper.LogResultado(lblResultado, resultado, "Modificar Habitacion");
                            break;
                    }
                    this.DialogResult = DialogResult.OK;
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
        private void FrmAbmHabitaciones_Load(object sender, EventArgs e)
        {
            txtIdHotel.Text = _idHotel.ToString();
        }

        ////drag Form
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
