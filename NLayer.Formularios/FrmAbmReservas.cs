using NLayer.Entidades;
using NLayer.Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace NLayer.Formularios
{
    public partial class FrmAbmReservas : Form
    {
        
       
        HotelServicios hotelServicios;
        AbmTipo _tipo;
        int _idHotel;
        Habitacion hh;

        
        public FrmAbmReservas(AbmTipo tipo, int idHotel,  HotelServicios htlserv)
        {
            InitializeComponent();
            _tipo = tipo;
            _idHotel = idHotel;
           
            hotelServicios = htlserv;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
                Guardar();
            
        }
        private void Guardar()
        {
           
            lblResultado.Text = string.Empty;
            Reserva reserva = new Reserva();
            string mensaje = Estaticas.Validaciones(Controls);
            if (mensaje != "")
            {
                MessageBox.Show(mensaje);
                
            }
            else
            {
                try
                {
                    if (_tipo != AbmTipo.Alta)
                        reserva.Id = int.Parse(txtIdReserva.Text);
                    reserva.IdHabitacion = int.Parse(txtIdHabitacion.Text);
                    reserva.IdCliente = int.Parse(txtIdCliente.Text);
                    reserva.CantidadHuespedes = int.Parse(txtNroHuespedes.Text);
                    reserva.FechaIngreso = dtFechaIngreso.Value;
                    reserva.FechaEgreso = dtFechaEgreso.Value;
                  
                    int resultado = -1;
                    switch (_tipo)
                    {
                        case AbmTipo.Alta:
                            resultado = hotelServicios.IngresarReserva(reserva, hh);
                            LogResultado(resultado, "Ingresar Reserva");
                            break;
                        case AbmTipo.Modificacion:
                            resultado = hotelServicios.ModificarReserva(reserva, hh);
                            LogResultado(resultado, "Modificar Reserva");
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
        private void LogResultado(int resultado, string mensaje)
        {
            if (resultado == -1)
                lblResultado.Text = "ERROR -> " + mensaje;
            else
            {
                lblResultado.Text = "OK -> " + mensaje + ". ID: " + resultado;
                Estaticas.LimpiarTextBox(Controls); 
            }
        }
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            //if (MessageBox.Show("Esta seguro que desea cancelar?", "Cancelar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //    this.Close();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscarCliente formulario = new FrmBuscarCliente(hotelServicios);
            formulario.Owner = this;
            formulario.ShowDialog();
            var obj = formulario.Tag;
            if (obj != null && obj is Cliente)
            {
                txtIdCliente.Text = ((Cliente)obj).Id.ToString();
            }
        }

        private void btnBuscarHabitacion_Click(object sender, EventArgs e)
        {
            FrmBuscarHabitacion formulario = new FrmBuscarHabitacion(_idHotel);
            formulario.Owner = this;
            formulario.ShowDialog();
            var obj = formulario.Tag;
            if (obj != null && obj is Habitacion)
            {
                hh = ((Habitacion)obj);
               
            }
           
        }

        private void btnBuscarHotel_Click(object sender, EventArgs e)
        {
            FrmBuscar formulario = new FrmBuscar(hotelServicios);
            formulario.Owner = this;
            formulario.ShowDialog();
            var obj = formulario.Tag;
            //var obj = this.Tag;
            if (obj != null && obj is Hotel)
            {
                _idHotel = ((Hotel)obj).Id;
                this.txtIdHotel.Text = _idHotel.ToString();
                this.txtIdHabitacion.Text = string.Empty;
            }
        }

        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hwnd, int wMsg, int wParam, int lParam);
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }
    }
}
