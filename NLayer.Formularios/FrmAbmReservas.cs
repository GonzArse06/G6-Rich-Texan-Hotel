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

/// <summary>
/// El formulario de ABM realiza las operaciones de Alta y Modificacion. (La baja se gestiona en el form de transaccion.)
/// En el contructor pasamos un enum para identificar el tipo de operacion y el objeto de hotelservicio para no instanciar uno nuevo.
/// Ademas se pasa el ID del hotel seleccionado en el combobox.
/// Usamos un metodo estatico para validar los input y un controlador de usuarios personalizado de tipo TextBox para los campos numericos.
/// 
/// </summary>

namespace NLayer.Formularios
{
    public partial class FrmAbmReservas : Form
    {
        HotelServicios _hotelServicios;
        AbmTipo _tipo;
        int _idHotel;
        Habitacion _hh;
        
        public FrmAbmReservas(AbmTipo tipo, int idHotel,  HotelServicios htlserv)
        {
            InitializeComponent();
            _tipo = tipo;
            _idHotel = idHotel;           
            _hotelServicios = htlserv;
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
            Text = "Nueva Reserva";
        }

        private void InicializarModificacion()
        {
            Text = "Modificar Reserva";
            txtIdHotel.Text = _idHotel.ToString();
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
                    if (_hh == null)
                    {
                        _hh = _hotelServicios.TraerTodoPorId(int.Parse(txtIdHotel.Text)).SingleOrDefault(x=>x.Id == reserva.IdHabitacion);
                        if (_hh == null)
                            throw new ReservasException("Debe seleccionar una habitacion valida.");
                    }
                  
                    int resultado = -1;
                    switch (_tipo)
                    {
                        case AbmTipo.Alta:
                            resultado = _hotelServicios.IngresarReserva(reserva, _hh);
                            LogHelper.LogResultado(lblResultado, resultado, "Ingresar Reserva");
                            break;
                        case AbmTipo.Modificacion:
                            resultado = _hotelServicios.ModificarReserva(reserva, _hh);
                            LogHelper.LogResultado(lblResultado, resultado, "Modificar Reserva");
                            break;
                    }
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception e)
                {
                    LogHelper.LogResultado(lblResultado, false, e.Message);
                    //lblResultado.Text = "ERROR -> Debe seleccionar una fila poder eliminar.";
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
        }
        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {
            FrmBuscarCliente formulario = new FrmBuscarCliente(_hotelServicios);
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
            FrmBuscarHabitacion formulario = new FrmBuscarHabitacion(_idHotel, _hotelServicios);
            formulario.Owner = this;
            formulario.ShowDialog();
            var obj = formulario.Tag;
            if (obj != null && obj is Habitacion)
            {
                _hh = ((Habitacion)obj);               
            }           
        }
        private void btnBuscarHotel_Click(object sender, EventArgs e)
        {
            FrmBuscarHotel formulario = new FrmBuscarHotel(_hotelServicios);
            formulario.Owner = this;
            formulario.ShowDialog();
            var obj = formulario.Tag;
            if (obj != null && obj is Hotel)
            {
                _idHotel = ((Hotel)obj).Id;
                this.txtIdHotel.Text = _idHotel.ToString();
                this.txtIdHabitacion.Text = string.Empty;
            }
        }
    }
}
