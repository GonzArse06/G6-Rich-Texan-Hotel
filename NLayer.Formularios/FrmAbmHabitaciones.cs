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
    /// <summary>
    /// El formulario de ABM realiza las operaciones de Alta y Modificacion. (La baja se gestiona en el form de transaccion.)
    /// En el contructor pasamos un enum para identificar el tipo de operacion y el objeto de hotelservicio para no instanciar uno nuevo.
    /// Ademas se pasa el ID del hotel seleccionado en el combobox.
    /// Usamos un metodo estatico para validar los input y un controlador de usuarios personalizado de tipo TextBox para los campos numericos.
    /// 
    /// </summary>
    public partial class FrmAbmHabitaciones : Form
    {
        AbmTipo _tipo;
        int _idHotel;
        HotelServicios _hotelServicios;
        public FrmAbmHabitaciones(AbmTipo tipo, int idHotel,HotelServicios serv)
        {
            InitializeComponent();
            _tipo = tipo;
            _idHotel = idHotel;
            _hotelServicios = serv;
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

                    int resultado = -1;
                    switch (_tipo)
                    {
                        case AbmTipo.Alta:
                            resultado = _hotelServicios.IngresarHabitacion(habitacion);
                            LogHelper.LogResultado(lblResultado, resultado, "Ingresar Habitacion");
                            break;
                        case AbmTipo.Modificacion:
                            resultado = _hotelServicios.ModificarHabitacion(habitacion);
                            LogHelper.LogResultado(lblResultado, resultado, "Modificar Habitacion");
                            break;
                    }
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception e)
                {
                    LogHelper.LogResultado(lblResultado, false, e.Message);
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
        private void FrmAbmHabitaciones_Load(object sender, EventArgs e)
        {
            txtIdHotel.Text = _idHotel.ToString();
        }
    }
}
