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

/// <summary>
/// El formulario de ABM realiza las operaciones de Alta y Modificacion. (La baja se gestiona en el form de transaccion.)
/// En el contructor pasamos un enum para identificar el tipo de operacion y el objeto de hotelservicio para no instanciar uno nuevo.
/// Usamos un metodo estatico para validar los input y un controlador de usuarios personalizado de tipo TextBox para los campos numericos.
/// 
/// </summary>

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
    }
}
