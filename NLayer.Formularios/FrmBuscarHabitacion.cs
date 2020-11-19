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

/// <summary>
/// El formulario de Busqueda. Tiene un listBox con todas las habitaciones del hotel seleccionado. Esto se agrega por si el usuario no conoce el id.
/// Para seleccionar se puede usar el boton o un dobleclick.
/// El dato elegido lo lleva al formulario de ABM.
/// Se pasa el objeto de HotelServicio para no instanciarlo nuevamente.
/// </summary>

namespace NLayer.Formularios
{
    public partial class FrmBuscarHabitacion : Form
    {
        List<Habitacion> _lista;
        HotelServicios _habitacionServicios;
        int _idHotel;
        public FrmBuscarHabitacion(int idHotel, HotelServicios serv)
        {
            InitializeComponent();
            _habitacionServicios = serv; 
            _lista = new List<Habitacion>();
            _idHotel = idHotel;
        }
        private void listBox1_doubleClick(object sender, EventArgs e)
        {
            Seleccionar();
        }
        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }
        private void Seleccionar() 
        {
            if (listBox1.SelectedIndex < 0)
            {
                MessageBox.Show("Seleccione una opcion.");
            }
            else
            {
                int idHabitacion = ((Habitacion)listBox1.SelectedItem).Id;
                this.Tag = listBox1.SelectedItem;
                ((FrmAbmReservas)Owner).txtIdHabitacion.Text = idHabitacion.ToString();
                this.Close();
            }
        }

        private void FrmBuscarCliente_Load(object sender, EventArgs e)
        {
            listBox1.DataSource = null;
            listBox1.DataSource = _habitacionServicios.TraerTodoPorId(_idHotel);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
