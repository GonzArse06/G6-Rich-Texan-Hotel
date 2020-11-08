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

namespace NLayer.Formularios
{
    public partial class FrmBuscarHabitacion : Form
    {
        List<Habitacion> _lista;
        HabitacionServicios _habitacionServicios;
        int _idHotel;
        public FrmBuscarHabitacion(int idHotel)
        {
            InitializeComponent();
            _habitacionServicios = new HabitacionServicios();
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
